using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FloodTracker
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        internal void TriggerEvent(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void OnPropertyChanged<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            field = value;
            TriggerEvent(propertyName);
        }
    }
}
