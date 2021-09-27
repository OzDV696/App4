using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace App4.ViewModels
{
    public class CountViewModel : BaseViewModel
    {
        int _contador;
        ICommand _buttonClickCommand;
        ICommand _resetClickCommand;
        string _countConverted;

        public CountViewModel()
        {
            _contador = 0;
        }

        public int Contador {
            get => _contador;
            set
            {
                if (value == _contador) return;
                _contador = value;
                CountConverted = $"Haz dado click {_contador} veces";
                OnPropertyChanged(nameof(CountConverted));
            }
        }

        public string CountConverted
        {
            get => _countConverted;
            set
            {
                if (string.Equals(_countConverted, value)) return;
                _countConverted = value;
                OnPropertyChanged();
            }
        }

        public ICommand ButtonClickCommand
        {
            get => _buttonClickCommand ?? (_buttonClickCommand = new Command(ButtonClickAction));
        }

        public ICommand ResetClickCommand
        {
            get => _resetClickCommand ?? (_resetClickCommand = new Command(ResetClickAction));
        }

        private void ResetClickAction()
        {
            Contador = 0;
            CountConverted = $"Haz reseteado el contador";
        }

        private void ButtonClickAction()
        {
            Contador++;
        }
    }
}
