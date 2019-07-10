
namespace ProiectComenzi.Core {
    using System.ComponentModel;

    public class EntityBase : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName) {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
