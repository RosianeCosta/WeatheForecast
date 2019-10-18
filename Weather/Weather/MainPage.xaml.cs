using System.ComponentModel;
using System.Threading;
using Xamarin.Forms;

namespace Weather
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Thread.Sleep(300);

            App.Current.MainPage = new NavigationPage(new Views.FavoriteCitiesView()) { BarBackgroundColor = Color.FromHex("#E9E9E9"), BarTextColor = Color.Black };
        }
    }
}