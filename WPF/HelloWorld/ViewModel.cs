using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld{
    class ViewModel : INotifyPropertyChanged{

        public ViewModel() {
            ChangeMesageCommand = new DelegateCommand(
                () => GreetingMesage = "Bye-bye world");
        }

        private string _greetingMesage = "Hello World!";
        public string GreetingMesage {
            get => _greetingMesage;
            set {
                if (_greetingMesage != value) {
                    _greetingMesage = value;
                    PropertyChanged?.Invoke(
                        this, new PropertyChangedEventArgs(nameof(GreetingMesage)));
                }
            }
        }

        public DelegateCommand ChangeMesageCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
