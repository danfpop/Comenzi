

namespace ProiectComenzi.Comenzi {
    using Core;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;

    public class ComenziVM : VMBase {
        public ComenziVM() {
            Add = new RelayCommand(OnAdd);
            Edit = new RelayCommand(OnEdit, OnIsSelectedItem);
            Delete = new RelayCommand(OnDelete, OnIsSelectedItem);

            Search = new RelayCommand(OnSearch);

           

        }

        bool OnIsSelectedItem(object param) {
            return SelectedItem != null;
        }
        public ICommand Add { get; private set; }
        private void OnAdd() {
            var dlg = new Comenzi.EditComanda(0);
            if (dlg.ShowDialog() == true) {
                RaisePropertyChanged("Items");
                SelectedItem = Utils.Ctx.comenzis
                    .OrderByDescending(p => p.id)
                    .FirstOrDefault();
            }
        }

        public ICommand Edit { get; private set; }
        private void OnEdit() {
            var dlg = new Comenzi.EditComanda(SelectedItem.id);
            if (dlg.ShowDialog() == true) RaisePropertyChanged("Items");
        }

        public ICommand Delete { get; private set; }
        private void OnDelete() {
            var msg = "Sunteti sigur ca doriti stergerea ului: " + SelectedItem.nr;
            if (ConfirmWnd.Show(msg)) {
                Utils.Ctx.comenzis.Remove(SelectedItem);
                Utils.Ctx.SaveChanges();
                RaisePropertyChanged("Items");
            }
        }

       

        public ICommand Search { get; private set; }
        private void OnSearch() {
            RaisePropertyChanged("Items");
        }

        public string SearchText { get; set; }

        public comenzi SelectedItem { get; set; }


        public IEnumerable<comenzi> Items {
            get {
                var cmds = Utils.Ctx.comenzis
                    .Include("parteneri")
                    .Include("comenzi_detaliu");

                var items =  string.IsNullOrEmpty(SearchText) ?
                    cmds.ToList<comenzi>() :
                    cmds.Where(i => i.nr == SearchText).ToList<comenzi>();

                if (items.Count > 0) {
                    SelectedItem = items[0];
                    RaisePropertyChanged("SelectedItem");
                }

                return items;

            }
        }



 
    }
}
