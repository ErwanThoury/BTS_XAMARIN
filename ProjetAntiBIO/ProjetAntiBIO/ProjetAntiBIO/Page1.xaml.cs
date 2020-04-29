
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetAntiBIO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Categorie categorieSel;
        public Page1(Categorie laCategorie)
        {
            InitializeComponent();
            categorieSel = laCategorie;
            lvAntiBio.ItemsSource = DataAntibio.getAntibiotiquesUneCateg(categorieSel).ToList();
        }
        

        
        private void lvAntiBio_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lvAntiBio.SelectedItem is AntibioParKilo)
            {

                stkPoids.IsVisible = true;
            }
            else
            {
                stkPoids.IsVisible = false;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (lvAntiBio.SelectedItem is AntibioParKilo)
            {
                if (entPoids.Text == null)
                {
                    DisplayAlert("Prescription", "Veuillez saisir un poids", "OK");

                }
                else
                {
                    try
                    {
                        AntibioParKilo atk = lvAntiBio.SelectedItem as AntibioParKilo;
                        int poids = Convert.ToInt32(entPoids.Text);
                        poids = poids * atk.getDoseKilo();
                        DisplayAlert("Prescription", "Il faut donc prendre " + poids + " " + atk.getUnite() + " et cela " + atk.getNombre() + " fois par jour", "OK");
                    }
                    catch
                    {
                        DisplayAlert("Prescription", "Rentrez un chiffre", "OK");
                    }


                }
            }
            else
            {
                AntibioParPrise atp = lvAntiBio.SelectedItem as AntibioParPrise;
                DisplayAlert("Prescription", "Il faut en prendre " + atp.getDosePrise() + " " + atp.getUnite() + " et cela " + atp.getNombre() + " par jour.", "OK");

            }
        }
        /*public async void recuperationAntibios(string categ)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            HttpClient wc = new HttpClient();
            HttpResponseMessage reponse = await wc.GetAsync(new Uri("https://projetgsb.000webhostapp.com/antibiotiques.php?libelleCateg=" + categ, UriKind.Absolute));
            string json = reponse.Content.ReadAsStringAsync().Result;
            List<Antibio> uneListeAntibios = JsonConvert.DeserializeObject<List<Antibio>>(json, settings).ToList();
            //DataAntibio.setLesAntibiotiques(uneListeAntibios);
        }*/
    }
}