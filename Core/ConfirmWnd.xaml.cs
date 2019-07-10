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

namespace ProiectComenzi.Core {
    /// <summary>
    /// Interaction logic for ConfirmWnd.xaml
    /// </summary>
    public partial class ConfirmWnd : Window {
        public ConfirmWnd(string message = null) {
            InitializeComponent();

            this.lblMessage.Text = message ?? "";
        }


        public static bool Show(string message) {
            var wnd = new ConfirmWnd(message);
            return wnd.ShowDialog() == true;
        }

        private void btnNu(object sender, RoutedEventArgs e) {
            this.DialogResult = false;
        }

        private void btnDa(object sender, RoutedEventArgs e) {
            this.DialogResult = true;
        }
    }
}
