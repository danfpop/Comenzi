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

namespace ProiectComenzi.Parteneri {
    /// <summary>
    /// Interaction logic for EditPartener.xaml
    /// </summary>
    public partial class EditPartener : Window {
        public EditPartener(parteneri item) {
            InitializeComponent();

            var vm = new EditPartenerVM(item);
            //  vm.CloseAction = new Action<bool>((result) => this.DialogResult = result);
            vm.CloseAction = OnCloseRequest;

            this.DataContext = vm;
        }

        private void OnCloseRequest(bool result) {
            this.DialogResult = result;
        }
    }
}
