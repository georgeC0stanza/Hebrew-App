using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HebNavi
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

        async void OnConsonantsPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Consonants());
        }
        async void OnVowelsPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vowels());
        }
        async void OnNounsAndPronounsPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NounsAndPronouns());
        }

    }
}
