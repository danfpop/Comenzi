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

namespace ProiectComenzi.Comenzi {
    /// <summary>
    /// Interaction logic for EditItemComanda.xaml
    /// </summary>
    public partial class EditItemComanda : Window {
        public EditItemComanda(comenzi_detaliu item) {

            InitializeComponent();

            var vm = new EditItemComandaVM(item);
            vm.CloseAction = OnCloseRequest;
            LayoutRoot.DataContext = vm;
            
        }

        private void OnCloseRequest(bool result) {
            this.DialogResult = result;
        }
    }

}
