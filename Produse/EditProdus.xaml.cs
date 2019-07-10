

namespace ProiectComenzi.Produse {

    using System;
    using System.Windows;


    /// <summary>
    /// Interaction logic for EditProdus.xaml
    /// </summary>
    public partial class EditProdus : Window {
        public EditProdus(produse item) {
            InitializeComponent();

            var vm = new EditProdusVM(item);
            vm.CloseAction = new Action<bool>((result) => this.DialogResult = result);
          
            this.DataContext = vm;
        }

    }
}
