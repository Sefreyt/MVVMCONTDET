using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMCONTDET.Data;

namespace MVVMCONTDET.ViewModels
{
    public class PanneauxViewModel : NotificationBase<Panneaux>
    {
        public PanneauxViewModel(Panneaux panneaux = null) : base(panneaux) { }
        public String Contrat
        {
            get { return This.Contrat; }
            set { SetProperty(This.Contrat, value, () => This.Contrat = value);}
        }
        public String Element
        {
            get { return This.Element; }
            set { SetProperty(This.Element, value, () => This.Element = value); }
        }
        public String Dessin
        {
            get { return This.Dessin; }
            set { SetProperty(This.Dessin, value, () => This.Dessin = value); }
        }
        public String Fabrication
        {
            get { return This.Fabrication; }
            set { SetProperty(This.Fabrication, value, () => This.Fabrication = value); }
        }
    }
}
