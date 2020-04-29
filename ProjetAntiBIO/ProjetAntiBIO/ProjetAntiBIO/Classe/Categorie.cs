using System;
using System.Collections.Generic;
using System.Text;

//namespace Antibio.Models
namespace ProjetAntiBIO
{
    public class Categorie
    {
        public string libelle;
        public Categorie(string pLibelle)
        {
            this.libelle = pLibelle;
        }
        public string getLibelle()
        {
            return this.libelle;
        }      
        public override string ToString()
        {
            return this.libelle;
        }
    }

}
