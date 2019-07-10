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

namespace ProiectComenzi {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
           
        }

        private void Parteneri(object sender, RoutedEventArgs e) {
            Title = "Comenzi::Listă parteneri";
            this.ContentaArea.Content = new Parteneri.ParteneriPage(); 
        }


        private void Produse(object sender, RoutedEventArgs e) {
      
            Title = "Comenzi::Listă produse";
            this.ContentaArea.Content = new Produse.ProdusePage(); ;
          
        }
        private void Comenzi(object sender, RoutedEventArgs e) {
            Title = "Comenzi::Listă comanzi";
            this.ContentaArea.Content = new Comenzi.ComenziPage(); ;
            
        }


    }
}
