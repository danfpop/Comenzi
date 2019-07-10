

namespace ProiectComenzi.Produse {

    using System;
    using System.Windows;
    using System.Windows.Input;

    using Core;

    public class EditProdusVM : VMBase{
        public EditProdusVM(produse item) {
            Cancel = new RelayCommand(OnCancel);
            Save = new RelayCommand(OnSave);

            Item = item;

        }

        public Action<bool> CloseAction { get; set; }
        public produse Item { get; private set; }
        private void OnSave() {

            //validare
            if (string.IsNullOrWhiteSpace(Item.denumire)) {
                NotifyUser("Numele produsului este obligatoriu.\nSalvare abandonată");
                return;
            }
            //salvare

            //close dialog
            if (CloseAction != null) CloseAction(true);
          
        }

        private void OnCancel() {

            if (CloseAction != null) CloseAction(false);
        }
   
        public ICommand Cancel { get; private set; }
        public ICommand Save { get; private set; }
    }
}
