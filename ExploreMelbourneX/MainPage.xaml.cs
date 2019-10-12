using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExploreMelbourneX
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private MediaFile _pickedImage;
        private HttpClient _httpClient = new HttpClient();
        public MainPage()
        {
            InitializeComponent();
        }

        async void Handle_Tapped(object sender, EventArgs e)
        {
            _pickedImage = await CrossMedia.Current.PickPhotoAsync();
            pickedImage.Source = ImageSource.FromFile(_pickedImage.Path);
        }

        async void Handle_Clicked(object sender, EventArgs e)
        {
            if(_pickedImage != null)
            {
                var postResult = await _httpClient.PostAsync("https://exploremelbourne.azurewebsites.net/api/HttpTrigger1?code=goezSGuSlOY27GdVSLoiD3aD6hI0nK/LRvECVETTGXR6C/XBDBgLJQ==",
                    new StreamContent(_pickedImage.GetStreamWithImageRotatedForExternalStorage()));

                var stringResult = await postResult.Content.ReadAsStringAsync();

                if (postResult.IsSuccessStatusCode)
                {
                    await DisplayAlert("Here is what you see", stringResult, "OK");
                }
                else
                {
                    await DisplayAlert("Error", stringResult, "OK");
                }
            }

        }
    }
}
