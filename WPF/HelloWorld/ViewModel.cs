using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld{
    class ViewModel :　BindableBase{

        public ViewModel() {
            ChangeMesageCommand = new DelegateCommand(
                () => GreetingMesage = "Bye-bye world");
        }

        private string _greetingMesage = "Hello World!";
        public string GreetingMesage {
            get => _greetingMesage;
            set => SetProperty(ref _greetingMesage, value);
                
        }

        public DelegateCommand ChangeMesageCommand { get; }
    }
}
