

namespace ProiectComenzi.Comenzi {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Core;
    public class EditComandaVM : VMBase {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idComanda">0 - pt comanda noua altfel editare</param>
        public EditComandaVM(int idComanda = 0) {

            this.IdComanda = idComanda;
            PrepareData();


            Save = new RelayCommand(OnSave);
            Cancel = new RelayCommand(OnCancel);

            // actiuni - detaliu comenzi 
            Add = new RelayCommand(OnAdd);
            Edit = new RelayCommand(OnEdit, (p) => SelectedDetaliu != null);
            Delete = new RelayCommand(OnDelete, (p) => SelectedDetaliu != null);

        }


        public Action<bool> CloseAction { get; set; }
        public IEnumerable<parteneri> Parteneri { get; private set; }
        public comenzi Item { get; set; }
        public comenzi_detaliu SelectedDetaliu { get; set; }
        public IEnumerable<comenzi_detaliu> Detalii {
            get {
                return Item.comenzi_detaliu;
            }
        }

        private void PrepareData() {
            Parteneri = Utils.Ctx.parteneris.OrderBy(p => p.nume).ToList<parteneri>();

            if (IdComanda == 0) {
                Item = new comenzi();
                Item.data = DateTime.Now;
            }
            else {
                Item = Utils.Ctx.comenzis
                    .Include("parteneri")
                    .Include("comenzi_detaliu")
                    .Where(c => c.id == IdComanda).FirstOrDefault();
                Debug.Assert(Item != null);
            }
        }

        public decimal? Total {
            get {
                //decimal? total = 0;
                //foreach (var r in Item.comenzi_detaliu) {
                //    total += r.cant * r.produse.pret;
                //}
                //return total;

                // mai simplu cu LINQ
                return Item.comenzi_detaliu.Sum(p => p.cant * p.produse.pret);
            }
        }
        private int IdComanda { get; set; }

        public ICommand Add { get; private set; }
        public ICommand Edit { get; private set; }
        public ICommand Delete { get; private set; }

        private void OnAdd() {
            var newItem = new comenzi_detaliu();
            var dlg = new EditItemComanda(newItem);
            if (dlg.ShowDialog() != true) return;

            //newItem.RaisePropertyChanged("valoare");
            Item.comenzi_detaliu.Add(newItem);
            RaisePropertyChanged("Total");
        }


        private void OnEdit() {
            var dlg = new EditItemComanda(SelectedDetaliu);
            if (dlg.ShowDialog() == true) {
                SelectedDetaliu.RaisePropertyChanged("valoare");
                SelectedDetaliu.RaisePropertyChanged("produse");
                SelectedDetaliu.RaisePropertyChanged("cant");
                RaisePropertyChanged("Total");
            }

            //RaisePropertyChanged("Detalii");
        }
        private void OnDelete() {
            var msg = string.Format("Eliminăm produsul:{0} din comandă", SelectedDetaliu.produse.denumire);
            if (!Utils.Confirm(msg)) return;

            SelectedDetaliu.produse = null;
            SelectedDetaliu.comenzi = null;
            Item.comenzi_detaliu.Remove(SelectedDetaliu);


            RaisePropertyChanged("Detalii");
            RaisePropertyChanged("Total");
        }


        public ICommand Save { get; private set; }
        public void OnSave() {

            //validare date
            if (!IsDataValid()) return;

            //is addNew ?
            if (IdComanda == 0) Utils.Ctx.comenzis.Add(Item);

            Utils.Ctx.SaveChanges();

            CloseAction?.Invoke(true);
        }

        private bool IsDataValid() {
            if (string.IsNullOrWhiteSpace(Item.nr)) return NotifyUser("Va rog introduceti nr. comanda");
            if (Item.data == null) return NotifyUser("Va rog introduceti data");
            if (Item.parteneri == null) return NotifyUser("Va rog selectati partenerul");
            if (Item.comenzi_detaliu.Count == 0) return NotifyUser("Vă rog introduceți cel puțin un produs pe comandă");

            return true;
        }

        public ICommand Cancel { get; private set; }
        public void OnCancel() {
            if (CloseAction != null) CloseAction(true);
        }


    }
}
