

namespace ProiectComenzi.Comenzi {

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;


    /// <summary>
    /// Interaction logic for EditComanda.xaml
    /// </summary>
    public partial class EditComanda : Window {
        public EditComanda(int idComanda) {
            InitializeComponent();

            var vm = new EditComandaVM(idComanda);
            vm.CloseAction = OnCloseRequest;
            this.LayoutRoot.DataContext = vm;
        }

        private void OnCloseRequest(bool result) {
            this.DialogResult = result;
        }
    }
}
