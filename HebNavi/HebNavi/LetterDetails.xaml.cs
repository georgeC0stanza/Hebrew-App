using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HebNavi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LetterDetails : ContentPage
    {
        ConsonantName nextValue;
        ListView listView;
        public LetterDetails(ConsonantName letter)
        {
            InitializeComponent();

            
            Character.Text = letter.ToString();

            nextValue = Enum.GetValues(typeof(ConsonantName)).Cast<ConsonantName>().SkipWhile(e => e != letter).Skip(1).FirstOrDefault();
            NextLetterButton.Text = nextValue.ToString();
        }
        async void OnLetterDetailsPageClicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new LetterDetails(nextValue));
        }

    }
}