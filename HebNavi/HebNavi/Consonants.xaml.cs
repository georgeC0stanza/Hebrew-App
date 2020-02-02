using Plugin.SimpleAudioPlayer;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HebNavi
{
    public enum ConsonantSound
    {
        Alef,
        Bet,
        Vet,
        GimelDaghesh,
        Gimel,
        DaletDaghesh,
        Dalet,
        He,
        Waw,
        Zayin,
        Het,
        Tet,
        Yod,
        KafDaghesh,
        Kaf,
        Lamed,
        Mem,
        Nun,
        Samek,
        Ayin,
        PeDaghesh,
        Pe,
        Tsade,
        Qof,
        Resh,
        Sin,
        Shin,
        TawDaghesh,
        Taw,
        count
    }
    public enum ConsonantName
    {
        Alef,
        Bet,
        Gimel,
        Dalet,
        He,
        Waw,
        Zayin,
        Het,
        Tet,
        Yod,
        Kaf,
        Lamed,
        Mem,
        Nun,
        Samek,
        Ayin,
        Pe,
        Tsade,
        Qof,
        Resh,
        Sin,
        Shin,
        Taw,
        count
    }


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Consonants : ContentPage
    {
        readonly ISimpleAudioPlayer[] SoundPlayers = new ISimpleAudioPlayer[(int)ConsonantSound.count];
        readonly ISimpleAudioPlayer[] NamePlayers = new ISimpleAudioPlayer[(int)ConsonantName.count];
        ISimpleAudioPlayer[] CurrentPlayers;
        bool toggle = true;

        // TODO: unload the audio files. Memory leak haha.
        public Consonants()
        {
            var player = CrossSimpleAudioPlayer.Current;
            InitializeComponent();
            for (int i = 0; i < (int)ConsonantSound.count; i++)
            {
                SoundPlayers[i] = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                SoundPlayers[i].Loop = false;
            }
            for (int i = 0; i < (int)ConsonantName.count; i++)
            {
                NamePlayers[i] = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                NamePlayers[i].Loop = false;
            }
            LoadSamples();
            int j = 0;
            foreach (Button button in gridButtons.Children.Where(c => Grid.GetColumn(c) == 0))
            {
                ConsonantSound consonantSound = (ConsonantSound)j;
                button.Clicked += (s, e) => OnConsonantSoundButton(consonantSound);
                j++;
            }
            j = 0;
            foreach (Button button in gridButtons.Children.Where(c => Grid.GetColumn(c) == 1))
            {
                ConsonantName consonantName = (ConsonantName)j;
                button.Clicked += (s, e) => OnConsonantNameButton(consonantName);
                j++;
            }
            CurrentPlayers = NamePlayers;

        }
        void OnConsonantSoundButton(ConsonantSound consonantSound)
        {
            SoundPlayers[(int)consonantSound]?.Play();
        }

        void OnConsonantNameButton(ConsonantName consonantName)
        {
            NamePlayers[(int)consonantName]?.Play();
        }


        void LoadSamples()
        {
            SoundPlayers[(int)ConsonantSound.Alef].Load(GetStreamFromFile("audio.LetterPronunciations.alef.mp3"));
            SoundPlayers[(int)ConsonantSound.Bet].Load(GetStreamFromFile("audio.LetterPronunciations.bet.mp3"));
            SoundPlayers[(int)ConsonantSound.Vet].Load(GetStreamFromFile("audio.LetterPronunciations.betDaghesh.mp3"));
            SoundPlayers[(int)ConsonantSound.GimelDaghesh].Load(GetStreamFromFile("audio.LetterPronunciations.gimelDaghesh.mp3"));
            SoundPlayers[(int)ConsonantSound.Gimel].Load(GetStreamFromFile("audio.LetterPronunciations.gimel.mp3"));
            SoundPlayers[(int)ConsonantSound.Dalet].Load(GetStreamFromFile("audio.LetterPronunciations.dalet.mp3"));
            SoundPlayers[(int)ConsonantSound.DaletDaghesh].Load(GetStreamFromFile("audio.LetterPronunciations.daletDaghesh.mp3"));
            SoundPlayers[(int)ConsonantSound.He].Load(GetStreamFromFile("audio.LetterPronunciations.he.mp3"));
            SoundPlayers[(int)ConsonantSound.Waw].Load(GetStreamFromFile("audio.LetterPronunciations.waw.mp3"));
            SoundPlayers[(int)ConsonantSound.Zayin].Load(GetStreamFromFile("audio.LetterPronunciations.zayin.mp3"));
            SoundPlayers[(int)ConsonantSound.Het].Load(GetStreamFromFile("audio.LetterPronunciations.het.mp3"));
            SoundPlayers[(int)ConsonantSound.Tet].Load(GetStreamFromFile("audio.LetterPronunciations.tet.mp3"));
            SoundPlayers[(int)ConsonantSound.Yod].Load(GetStreamFromFile("audio.LetterPronunciations.yod.mp3"));
            SoundPlayers[(int)ConsonantSound.KafDaghesh].Load(GetStreamFromFile("audio.LetterPronunciations.kafDaghesh.mp3"));
            SoundPlayers[(int)ConsonantSound.Kaf].Load(GetStreamFromFile("audio.LetterPronunciations.kaf.mp3"));
            SoundPlayers[(int)ConsonantSound.Lamed].Load(GetStreamFromFile("audio.LetterPronunciations.lamed.mp3"));
            SoundPlayers[(int)ConsonantSound.Mem].Load(GetStreamFromFile("audio.LetterPronunciations.mem.mp3"));
            SoundPlayers[(int)ConsonantSound.Nun].Load(GetStreamFromFile("audio.LetterPronunciations.nun.mp3"));
            SoundPlayers[(int)ConsonantSound.Samek].Load(GetStreamFromFile("audio.LetterPronunciations.samek.mp3"));
            SoundPlayers[(int)ConsonantSound.Ayin].Load(GetStreamFromFile("audio.LetterPronunciations.ayin.mp3"));
            SoundPlayers[(int)ConsonantSound.PeDaghesh].Load(GetStreamFromFile("audio.LetterPronunciations.peDaghesh.mp3"));
            SoundPlayers[(int)ConsonantSound.Pe].Load(GetStreamFromFile("audio.LetterPronunciations.pe.mp3"));
            SoundPlayers[(int)ConsonantSound.Tsade].Load(GetStreamFromFile("audio.LetterPronunciations.tsade.mp3"));
            SoundPlayers[(int)ConsonantSound.Qof].Load(GetStreamFromFile("audio.LetterPronunciations.qof.mp3"));
            SoundPlayers[(int)ConsonantSound.Resh].Load(GetStreamFromFile("audio.LetterPronunciations.resh.mp3"));
            SoundPlayers[(int)ConsonantSound.Sin].Load(GetStreamFromFile("audio.LetterPronunciations.sin.mp3"));
            SoundPlayers[(int)ConsonantSound.Shin].Load(GetStreamFromFile("audio.LetterPronunciations.shin.mp3"));
            SoundPlayers[(int)ConsonantSound.Taw].Load(GetStreamFromFile("audio.LetterPronunciations.taw.mp3"));
            SoundPlayers[(int)ConsonantSound.TawDaghesh].Load(GetStreamFromFile("audio.LetterPronunciations.taw.mp3"));




            NamePlayers[(int)ConsonantName.Alef].Load(GetStreamFromFile("audio.LetterNames.alef.mp3"));
            NamePlayers[(int)ConsonantName.Bet].Load(GetStreamFromFile("audio.LetterNames.bet.mp3"));
            NamePlayers[(int)ConsonantName.Gimel].Load(GetStreamFromFile("audio.LetterNames.gimel.mp3"));
            NamePlayers[(int)ConsonantName.Dalet].Load(GetStreamFromFile("audio.LetterNames.dalet.mp3"));
            NamePlayers[(int)ConsonantName.He].Load(GetStreamFromFile("audio.LetterNames.he.mp3"));
            NamePlayers[(int)ConsonantName.Waw].Load(GetStreamFromFile("audio.LetterNames.waw.mp3"));
            NamePlayers[(int)ConsonantName.Zayin].Load(GetStreamFromFile("audio.LetterNames.zayin.mp3"));
            NamePlayers[(int)ConsonantName.Het].Load(GetStreamFromFile("audio.LetterNames.het.mp3"));
            NamePlayers[(int)ConsonantName.Tet].Load(GetStreamFromFile("audio.LetterNames.tet.mp3"));
            NamePlayers[(int)ConsonantName.Yod].Load(GetStreamFromFile("audio.LetterNames.yod.mp3"));
            NamePlayers[(int)ConsonantName.Kaf].Load(GetStreamFromFile("audio.LetterNames.kaf.mp3"));
            NamePlayers[(int)ConsonantName.Lamed].Load(GetStreamFromFile("audio.LetterNames.lamed.mp3"));
            NamePlayers[(int)ConsonantName.Mem].Load(GetStreamFromFile("audio.LetterNames.mem.mp3"));
            NamePlayers[(int)ConsonantName.Nun].Load(GetStreamFromFile("audio.LetterNames.nun.mp3"));
            NamePlayers[(int)ConsonantName.Samek].Load(GetStreamFromFile("audio.LetterNames.samek.mp3"));
            NamePlayers[(int)ConsonantName.Ayin].Load(GetStreamFromFile("audio.LetterNames.ayin.mp3"));
            NamePlayers[(int)ConsonantName.Pe].Load(GetStreamFromFile("audio.LetterNames.pe.mp3"));
            NamePlayers[(int)ConsonantName.Tsade].Load(GetStreamFromFile("audio.LetterNames.tsade.mp3"));
            NamePlayers[(int)ConsonantName.Qof].Load(GetStreamFromFile("audio.LetterNames.qof.mp3"));
            NamePlayers[(int)ConsonantName.Resh].Load(GetStreamFromFile("audio.LetterNames.resh.mp3"));
            NamePlayers[(int)ConsonantName.Sin].Load(GetStreamFromFile("audio.LetterNames.sin.mp3"));
            NamePlayers[(int)ConsonantName.Shin].Load(GetStreamFromFile("audio.LetterNames.shin.mp3"));
            NamePlayers[(int)ConsonantName.Taw].Load(GetStreamFromFile("audio.LetterNames.taw.mp3"));
        }
            

        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("HebNavi." + filename);

            return stream;
        }

        async void OnHomePageClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
        async void OnConsonantPageClicked(object sender, EventArgs e)
        {
            
            //await Navigation.PushAsync(new LetterDetails(ConsonantName.Alef));
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
        void OnSoundNameToggled(object sender, EventArgs e)
        {

            if (toggle == true)
            {
                toggle = false;
                foreach (View child in gridButtons.Children)
                {
                    if (child.GetType() == typeof(Button))
                    {
                        Button buttoned = (Button)child;

                        buttoned.Clicked += (s, ed) => ToggleHidden_OnClicked(buttoned);
                        buttoned.BackgroundColor = Color.DarkSeaGreen;
                        buttoned.TextColor = Color.DarkSeaGreen;
                    }
                }
                
            }
            else
            {
                toggle = true;
                int j = 0;
                foreach (Button button in gridButtons.Children.Where(c => Grid.GetColumn(c) == 0))
                {
                    ConsonantSound consonantSound = (ConsonantSound)j;
                    button.Clicked += (s, ed) => OnConsonantSoundButton(consonantSound);
                    j++;
                }
                j = 0;
                foreach (Button button in gridButtons.Children.Where(c => Grid.GetColumn(c) == 1))
                {
                    ConsonantName consonantName = (ConsonantName)j;
                    button.Clicked += (s, ed) => OnConsonantNameButton(consonantName);
                    j++;
                }
            }
        }
    }
    
}
