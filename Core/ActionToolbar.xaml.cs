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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProiectComenzi.Core {
    /// <summary>
    /// Interaction logic for ActionToolbar.xaml
    /// </summary>
    public partial class ActionToolbar : UserControl {
        public ActionToolbar() {
            InitializeComponent();
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter && Search != null) Search.Execute(null);
        }


        // dp pt. acces 
        public ICommand Search {
            get { return (ICommand)GetValue(SearchProperty); }
            set { SetValue(SearchProperty, value); }
        }

        public static readonly DependencyProperty SearchProperty =
            DependencyProperty.Register("Search", typeof(ICommand), typeof(ActionToolbar), new PropertyMetadata(null));

    }
}
