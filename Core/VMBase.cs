using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProiectComenzi.Core {
    public class VMBase : INotifyPropertyChanged {
        public VMBase() {
            //Ctx = new comenziEntities();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        /// <summary>
        /// Afiseaza un mesaj ...
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Always return false</returns>
        protected bool NotifyUser(string message) {
            MessageBox.Show(message);//, "Mesaj", MessageBoxButton.OK);
            return false;
        }

        //protected comenziEntities Ctx { get; set; }
    }
}   
