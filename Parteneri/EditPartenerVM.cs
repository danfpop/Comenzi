

namespace ProiectComenzi.Parteneri {

    using System;
    using System.Windows;
    using System.Windows.Input;

    using Core;

    public class EditPartenerVM : VMBase{
        public EditPartenerVM(parteneri item) {
            Cancel = new RelayCommand(OnCancel);
            Save = new RelayCommand(OnSave);

            Item = item;

        }

        public Action<bool> CloseAction { get; set; }
        public parteneri Item { get; private set; }
        private void OnSave() {

            //validare
            if (string.IsNullOrWhiteSpace(Item.nume)) {
                MessageBox.Show("Numele partenerului este obligatoriu.\nSalvare abandonată");
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
