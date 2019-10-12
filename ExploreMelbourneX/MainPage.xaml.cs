using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        public MainPage()
        {
            InitializeComponent();
        }

        async void Handle_Tapped(object sender, EventArgs e)
        {
            var image = await CrossMedia.Current.PickPhotoAsync();
            pickedImage.Source = ImageSource.FromFile(image.Path);
        }

        void Handle_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();

        }
    }
}
