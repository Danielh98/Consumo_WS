using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Xamarin.Forms.Xaml;


namespace App5
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://10.1.60.2/moviles/post.php";
        private readonly HttpClient Client = new HttpClient();
        private ObservableCollection<App5.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
            get();
            int edad;
            
        }

        public async void get()
        {
            try
            {
                var content = await Client.GetStringAsync(Url);
                List<App5.Datos> posts = JsonConvert.DeserializeObject<List<App5.Datos>>(content);
                _post = new ObservableCollection<App5.Datos>(posts);
                MyListView.ItemsSource = _post;


            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "ERROR " + ex.Message, "OK");
            }

        }

       

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var dt = menuItem.CommandParameter as App5.Datos;

            await Navigation.PushAsync(new actualizar(dt.codigo, dt.nombre, dt.apellido, dt.edad));
        }

        private async void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
