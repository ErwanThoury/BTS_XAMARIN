using System;
using System.Collections.Generic;
using System.Text;

//namespace Antibio.Models
namespace ProjetAntiBIO
{
    class AntibioParKilo : Antibio
    {
        public int doseKilo;
        public AntibioParKilo(String pLibelle, String pUnite, Categorie pCategorie,int pNombre,int pDoseKilo) : base(pLibelle, pUnite, pCategorie, pNombre)
        {            
            this.doseKilo = pDoseKilo;
        }
        public int getDoseKilo()
        {
            return this.doseKilo;
        }

    }
}
