using System;
using System.Collections.Generic;
using System.Text;

//namespace Antibio.Models
namespace ProjetAntiBIO
{
    class DataAntibio
    {
        static private List<Antibio> lesAntibiotiques;
        static private List<Categorie> lesCategories;
        static public void initialiser()
        {
            
            DataAntibio.lesCategories = new List<Categorie>();
            DataAntibio.lesAntibiotiques = new List<Antibio>();

            /*
            Categorie uneCategorie1 = new Categorie("Aminoglycosides");
            DataAntibio.lesCategories.Add(uneCategorie1);
            Categorie uneCategorie2 = new Categorie("AntiFongiques");
            DataAntibio.lesCategories.Add(uneCategorie2);
            Categorie uneCategorie3 = new Categorie("Antiviraux");
            DataAntibio.lesCategories.Add(uneCategorie3);
            Categorie uneCategorie4 = new Categorie("Carbapénèmes");
            DataAntibio.lesCategories.Add(uneCategorie4);
            Categorie uneCategorie5 = new Categorie("Céphalosporines");
            DataAntibio.lesCategories.Add(uneCategorie5);
            Categorie uneCategorie6 = new Categorie("Macrolides");
            DataAntibio.lesCategories.Add(uneCategorie6);
            Categorie uneCategorie7 = new Categorie("Pénicillines");
            DataAntibio.lesCategories.Add(uneCategorie7);
            Categorie uneCategorie8 = new Categorie("Quinolones");
            DataAntibio.lesCategories.Add(uneCategorie8);
            Categorie uneCategorie9 = new Categorie("Sulfamidés");
            DataAntibio.lesCategories.Add(uneCategorie9);
            Categorie uneCategorie10 = new Categorie("Autres");
            DataAntibio.lesCategories.Add(uneCategorie10);
            
            
            AntibioParKilo unAntibioParKilo;
            unAntibioParKilo = new AntibioParKilo("Amiklin", "mg", uneCategorie1,1,15);
            DataAntibio.lesAntibiotiques.Add(unAntibioParKilo);
            unAntibioParKilo = new AntibioParKilo("Garamycine", "mg", uneCategorie1,1,6);
            DataAntibio.lesAntibiotiques.Add(unAntibioParKilo);
            unAntibioParKilo = new AntibioParKilo("porimycine", "kg", uneCategorie2, 2,4);
            DataAntibio.lesAntibiotiques.Add(unAntibioParKilo);
            unAntibioParKilo = new AntibioParKilo("Gaticycine", "hg", uneCategorie2, 14, 3);
            DataAntibio.lesAntibiotiques.Add(unAntibioParKilo);

            AntibioParPrise unAPP;
            unAPP = new AntibioParPrise("Garamycinorimne", "mg", uneCategorie1, 5, 45);
            DataAntibio.lesAntibiotiques.Add(unAPP);
            unAPP = new AntibioParPrise("Ramycine", "mg", uneCategorie1, 12, 6);
            DataAntibio.lesAntibiotiques.Add(unAPP);
            unAPP = new AntibioParPrise("Gaine", "cg", uneCategorie2, 5, 58);
            DataAntibio.lesAntibiotiques.Add(unAPP);
            unAPP = new AntibioParPrise("Garam", "kg", uneCategorie2, 2, 10);
            DataAntibio.lesAntibiotiques.Add(unAPP);*/
        }
        static public List<Categorie> getLesCategories()
        {
            return DataAntibio.lesCategories;
        }
        static public List<Antibio> getAntibiotiquesUneCateg(Categorie c)
        {
            List<Antibio> liste = new List<Antibio>();
            foreach (Antibio a in DataAntibio.lesAntibiotiques)
            {
                if (a.getCategorie().getLibelle() == c.getLibelle())
                {
                    liste.Add(a);
                }
            }
            return liste;
        }
        static public float getMoyDosePrise(string unite) 
        {
            float moy = 0;
            int i = 0;
            foreach (Antibio a in DataAntibio.lesAntibiotiques) 
            {
                if (a.getUnite() == unite && a is AntibioParPrise)
                {
                    AntibioParPrise ap = (AntibioParPrise)a;
                    moy += ap.getDosePrise();
                    i++;
                }
            }
            if (i != 0) 
            {
                moy = moy / i;
            }
            return moy;
        }
        static public void setLesAntibiotiques(List<Antibio> lesAntibios)
        {
            lesAntibiotiques = lesAntibios;
        }

        static public void setLesCategories(List<Categorie> lesCateg)
        {
            lesCategories = lesCateg;
        }
    }
}
