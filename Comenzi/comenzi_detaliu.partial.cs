

namespace ProiectComenzi {
    using Core;

    public partial class comenzi_detaliu : EntityBase {

        public decimal? valoare {
            get {
                return this.cant * this.produse.pret;
            }
        }

        public void RefreshAll() {
            RaisePropertyChanged("produse");
            RaisePropertyChanged("cant");
            RaisePropertyChanged("valoare");
        }
        
    }
}
