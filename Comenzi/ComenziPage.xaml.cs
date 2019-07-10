using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ParteneriWnd.xaml
    /// </summary>
    public partial class ComenziPage : UserControl {
        public ComenziPage() {
            InitializeComponent();

            // atasam vm la 
            var vm = new ComenziVM();
            this.LayoutRoot.DataContext = vm;
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e) {

            if (e.Key == Key.Enter) {
                var vm = this.LayoutRoot.DataContext as ComenziVM;
                Debug.Assert(vm != null);
                vm.Search.Execute(null);
            }

        }
    }
}
