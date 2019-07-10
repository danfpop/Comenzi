
namespace ProiectComenzi.Comenzi {

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using Core;


    public class EditItemComandaVM : VMBase {

        public EditItemComandaVM(comenzi_detaliu item) {
            PrepareData();

            Save = new RelayCommand(OnSave);
            Cancel = new RelayCommand(OnCancel);
            Item = item;

        }

        private void PrepareData() {
            Produse = Utils.Ctx.produses.OrderBy(p => p.denumire).ToList<produse>();
        }

        public Action<bool> CloseAction { get; set; }

        public IEnumerable<produse> Produse { get; private set; }
        public comenzi_detaliu Item { get; set; }

        public ICommand Save { get; private set; }
        private void OnSave() {

            //validare
            if (Item.produse == null) {
                NotifyUser("Vă rog selectați produsul.");
                return;
            }

            Item.id_produs = Item.produse.id;
            if (CloseAction != null) CloseAction(true);
        }

        public ICommand Cancel { get; private set; }
        private void OnCancel() {
            if (Item.id != 0) {
                var tt = Utils.Ctx.ChangeTracker.Entries().ToList();
                var item = Utils.Ctx.ChangeTracker.Entries<comenzi_detaliu>()
                    .Where(i => i.Entity.id == Item.id)
                    .FirstOrDefault();
                if (item != null) item.State = System.Data.Entity.EntityState.Unchanged;
            }
            if (CloseAction != null) CloseAction(false);

        }
    }
}
