using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class actualizar : ContentPage
    {
        public actualizar(int codigo, string nombre, string apellido, int edad)
        {
            InitializeComponent();
            txtCodigo.Text = codigo.ToString();
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text = edad.ToString();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Clicked_1(object sender, EventArgs e)
        {

        }

        private async void btnGuardar_Clicked_2(object sender, EventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();

                //Actualizar con PUT
                var response = client.PutAsync(String.Format("http://10.1.60.2/moviles/post.php?codigo={0}&nombre={1}&apellido={2}&edad={3}", txtCodigo.Text, txtNombre.Text, txtApellido.Text, txtEdad.Text), null).Result;

                if (response.IsSuccessStatusCode)
                {
                    var resultString = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    await DisplayAlert("Mensaje de alerta", "Error al actualizar", "OK");
                }

                // Utilizar TOAST
                /*var mensaje = "Actualizado correctamente";
                DependencyService.Get<Mensaje>().longAlert(mensaje);*/

                //Regresar a la pantalla de Vacunas
                await Navigation.PushAsync(new MainPage());

                // Poner en blanco los campos
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtEdad.Text = "";
                await DisplayAlert("Mensaje", "aztualizado correctamente", "OK");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Mensaje de alerta", ex.Message, "OK");
            }
        }
    }
}