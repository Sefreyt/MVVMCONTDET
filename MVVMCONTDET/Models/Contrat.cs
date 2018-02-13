using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMCONTDET.Data;

namespace MVVMCONTDET.Models
{
    public class Contrat
    {
        public List<Panneaux> ListeDesPanneaux { get; set; }
        public String Numero { get; set; }

        public Contrat(string Numero)
        {
            Numero = this.Numero;
            ListeDesPanneaux = RequeteSQL.GetPanneaux();
        }

        public void Add(Panneaux panneaux)
        {
            if (!ListeDesPanneaux.Contains(panneaux))
            {
                ListeDesPanneaux.Add(panneaux);
                RequeteSQL.Write(panneaux);
            }
        }

        public void Delete(Panneaux panneaux)
        {
            if (ListeDesPanneaux.Contains(panneaux))
            {
                ListeDesPanneaux.Remove(panneaux);
                RequeteSQL.Write(panneaux);
            }
        }

        public void Update(Panneaux panneaux)
        {
            RequeteSQL.Write(panneaux);
        }
    }
}
