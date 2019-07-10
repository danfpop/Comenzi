/* 
 * Pagina de parteneri
 *   - permite filtrarea catalogului de produse + CRUD
 *   
 *  pop.danut@email.com
 *  
 *  15.06.2019  - upd reject changes la cancel
 *  
 */

namespace ProiectComenzi.Produse {

    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    using Core;

    public class ProduseVM : VMBase {
        public ProduseVM() {
            Add = new RelayCommand(OnAdd);
            Edit = new RelayCommand(OnEdit, OnIsSelectedItem);
            Delete = new RelayCommand(OnDelete, OnIsSelectedItem);

            Search = new RelayCommand(OnSearch);
        }

        bool OnIsSelectedItem(object param) { return SelectedItem != null; }


        public ICommand Add { get; private set; }
        private void OnAdd() {
            var item = new produse();
            var dlg = new EditProdus(item);
            if (dlg.ShowDialog() == true) {
                Utils.Ctx.produses.Add(item);
                Utils.Ctx.SaveChanges();
                RaisePropertyChanged("Items");
            }
        }

        public ICommand Edit { get; private set; }
        private void OnEdit() {

            var dlg = new EditProdus(SelectedItem);
            if (dlg.ShowDialog() == true) {
                Utils.Ctx.SaveChanges();
            }
            else {      // reject changes 
                Utils.Ctx.DbContextRejectChanges<parteneri>();
            }
            RaisePropertyChanged("Items");
        }



        public ICommand Delete { get; private set; }
        private void OnDelete() {

            // verificare daca produsul este cuprins intr-o comanda
            var cmds = Utils.Ctx.comenzi_detaliu
                .Where(c => c.id_produs == SelectedItem.id);

            if (cmds.Any()) {
                MessageBox.Show(
                    "Acest produs este cuprins in una sau mai multe comenzi.",
                    "Ștergere abandonată");
            }
            else if (Utils.Confirm("Confirmati ștergerea produsului: " + SelectedItem.denumire)) {
                Utils.Ctx.produses.Remove(SelectedItem);
                Utils.Ctx.SaveChanges();
                RaisePropertyChanged("Items");
            }
        }

        public ICommand Search { get; private set; }
        private void OnSearch() { RaisePropertyChanged("Items"); }

        public string SearchText { get; set; }

        public produse SelectedItem { get; set; }


        public IEnumerable<produse> Items {
            get {


                if (string.IsNullOrEmpty(SearchText)) {
                    return Utils.Ctx.produses
                        .ToList<produse>()
                        .OrderBy(p => p.denumire);
                }
                else {
                    return Utils.Ctx.produses
                        .Where(p => p.denumire.StartsWith(SearchText))
                        .ToList<produse>()
                        .OrderBy(p => p.denumire);
                }

            }
        }
    }
}
