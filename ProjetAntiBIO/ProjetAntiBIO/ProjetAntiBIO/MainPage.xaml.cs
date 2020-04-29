using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace ProjetAntiBIO
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {     
            InitializeComponent();
            recuperation();
            recuperationAntibio();
            DataAntibio.initialiser();
            lvCateg.ItemsSource = DataAntibio.getLesCategories().ToList();
            //lblMoy.Text=DataAntibio.getMoyDosePrise("mg").ToString();
        }
        private void lvCateg_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //await Navigation.PushAsync(new Page1(e.SelectedItem as Categorie));
            Navigation.PushAsync(new Page1(lvCateg.SelectedItem as Categorie));
            //lvAntiBio.ItemsSource = DataAntibio.getAntibiotiquesUneCateg(e.SelectedItem as Categorie).ToList();
        }
        
        public async void recuperation()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage reponse = await client.GetAsync(new Uri("https://projetgsb.000webhostapp.com/categories.php", UriKind.Absolute));
            string json = reponse.Content.ReadAsStringAsync().Result;
            List<Categorie> listeCategories = null;
            listeCategories = JsonConvert.DeserializeObject<List<Categorie>>(json);
            DataAntibio.setLesCategories(listeCategories);
            lvCateg.ItemsSource = listeCategories.ToList();
        }
        /*
        public async void recuperationAntibio()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage reponse = await client.GetAsync(new Uri("https://projetgsb.000webhostapp.com/antibio.php", UriKind.Absolute));
            string json = reponse.Content.ReadAsStringAsync().Result;
            List<AntibioParPrise> listeAntibioPP = null;
            List<AntibioParKilo> listeAntibioPK = null;
            dynamic jsonObj = JsonConvert.DeserializeObject(json);

            foreach (var obj in jsonObj.objectList)
            {
                Console.WriteLine(obj.type);
                if(obj.type == )
            }

            DataAntibio.setLesAntibiotiques(listeAntibioPK);
            lvCateg.ItemsSource = listeAntibioPK.ToList();
        }
        */
        private void er(List<Antibio> a) 
        {
            DataAntibio.setLesAntibiotiques(a);
        }
        public async void recuperationAntibio()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            HttpClient wc = new HttpClient();
            HttpResponseMessage reponse = await wc.GetAsync(new Uri("https://projetgsb.000webhostapp.com/antibiotiques.php", UriKind.Absolute));
            string json = reponse.Content.ReadAsStringAsync().Result;
            List<Antibio> uneListeAntibios = null;
            uneListeAntibios = JsonConvert.DeserializeObject<List<Antibio>>(json, settings).ToList();
            DataAntibio.setLesAntibiotiques(uneListeAntibios);
            er(uneListeAntibios);
        }

    }
}
