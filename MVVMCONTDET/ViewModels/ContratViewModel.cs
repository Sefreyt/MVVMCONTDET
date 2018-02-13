using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using MVVMCONTDET.Models;
using MVVMCONTDET.Data;

namespace MVVMCONTDET.ViewModels
{
    public class ContratViewModel : NotificationBase
    {
        Contrat contrat;

        public ContratViewModel(String Numero)
        {
            contrat = new Contrat(Numero);
            _SelectedIndex = -1;

            // Load the database //TODO LOAD DATABASE HE FUCKING SAID YOU SAVAGE !!!

            foreach (var panneaux in contrat.ListeDesPanneaux)
            {
                var np = new PanneauxViewModel(panneaux);
                np.PropertyChanged += Panneaux_OnNotifyPropertyChanged;
                _ListeDesPanneaux.Add(np);
            }
        }

        ObservableCollection<PanneauxViewModel> _ListeDesPanneaux
           = new ObservableCollection<PanneauxViewModel>();
        public ObservableCollection<PanneauxViewModel> ListeDesPanneaux
        {
            get { return _ListeDesPanneaux; }
            set { SetProperty(ref _ListeDesPanneaux, value); }
        }

        //String _Numero;
        public String Numero
        {
            get { return contrat.Numero; }
        }

        int _SelectedIndex;
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                if (SetProperty(ref _SelectedIndex, value))
                { RaisePropertyChanged(nameof(SelectedPanneaux)); }
            }
        }

        public PanneauxViewModel SelectedPanneaux
        {
            get { return (_SelectedIndex >= 0) ? _ListeDesPanneaux[_SelectedIndex] : null; }
        }

        public void Add()
        {
            var panneaux = new PanneauxViewModel();
            panneaux.PropertyChanged += Panneaux_OnNotifyPropertyChanged;
            ListeDesPanneaux.Add(panneaux);
            contrat.Add(panneaux);
            SelectedIndex = ListeDesPanneaux.IndexOf(panneaux);
        }

        public void Delete()
        {
            if (SelectedIndex != -1)
            {
                var panneaux = ListeDesPanneaux[SelectedIndex];
                ListeDesPanneaux.RemoveAt(SelectedIndex);
                contrat.Delete(panneaux);
            }
        }

        void Panneaux_OnNotifyPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            contrat.Update((PanneauxViewModel)sender);
        }
    }
}

