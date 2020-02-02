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
    public partial class NounsAndPronouns : ContentPage
    {
        public NounsAndPronouns()
        {
            InitializeComponent();
            foreach (View child in GridNounEndings.Children)
            {
                if(child.GetType() == typeof(Button))
                {
                    Button button = (Button)child;

                    button.Clicked += (s, e) => ToggleHidden_OnClicked(button);
                }
            }
            foreach (View child in GridIndepenantPersonalPronouns.Children)
            {
                if (child.GetType() == typeof(Button))
                {
                    Button button = (Button)child;

                    button.Clicked += (s, e) => ToggleHidden_OnClicked(button);
                }
            }
            foreach (View child in GridDemonstrativePronouns.Children)
            {
                if (child.GetType() == typeof(Button))
                {
                    Button button = (Button)child;

                    button.Clicked += (s, e) => ToggleHidden_OnClicked(button);
                }
            }
            foreach (View child in gridMiscPronouns.Children)
            {
                if (child.GetType() == typeof(Button))
                {
                    Button button = (Button)child;

                    button.Clicked += (s, e) => ToggleHidden_OnClicked(button);
                }
            }

        }
        private void GridButtonToggleHide_Clicked(object sender, EventArgs e)
        {
            var button = (Button) sender;
            var classId = button.ClassId;
        }

        private void NounsInfo_Clicked(object sender, EventArgs e)
        {

        }
        async void OnHomePageClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private void ToggleHidden_OnClicked(object sender)
        {
            var button = (Button)sender;
            //var classId = button.ClassId;

            if (button.BackgroundColor != Color.DarkSeaGreen)
            {
                button.BackgroundColor = Color.DarkSeaGreen;
                button.TextColor = Color.DarkSeaGreen;
            }
            else
            {
                button.BackgroundColor = Color.FromHex("#34495e");
                button.TextColor = Color.FromHex("FCFBEE");
            }

        }
        private void ToggleAll_OnClicked(object sender, EventArgs e)
        {
            foreach (View child in GridNounEndings.Children)
            {
                if (child.GetType() == typeof(Button))
                {
                    Button buttoned = (Button)child;

                    buttoned.BackgroundColor = Color.DarkSeaGreen;
                    buttoned.TextColor = Color.DarkSeaGreen;
                }
            }
            foreach (View child in GridIndepenantPersonalPronouns.Children)
            {
                if (child.GetType() == typeof(Button))
                {
                    Button buttoned = (Button)child;

                    buttoned.BackgroundColor = Color.DarkSeaGreen;
                    buttoned.TextColor = Color.DarkSeaGreen;
                }
            }
            foreach (View child in GridDemonstrativePronouns.Children)
            {
                if (child.GetType() == typeof(Button))
                {
                    Button buttoned = (Button)child;

                    buttoned.BackgroundColor = Color.DarkSeaGreen;
                    buttoned.TextColor = Color.DarkSeaGreen;
                }
            }
            foreach (View child in gridMiscPronouns.Children)
            {
                if (child.GetType() == typeof(Button))
                {
                    Button buttoned = (Button)child;

                    buttoned.BackgroundColor = Color.DarkSeaGreen;
                    buttoned.TextColor = Color.DarkSeaGreen;
                }
            }


        }

    }
}