using Plugin.SimpleAudioPlayer;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace HebNavi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vowels : ContentPage
    {
        public enum LongVowel
        {
            Qamets,
            Tsere,
            Holem,
            count
        }
        public enum ShortVowel
        {
            Pathach,
            Seghol,
            Hireq,
            QametsHatuf,
            Qibbuts,
            count
        }
        public enum ReducedVowel
        {
            HatephPathach,
            HatephSeghol,
            HatephQamets,
            count
        }
        public enum VowelLetter
        {
            QametsHe,
            TsereYod,
            SegholYod,
            HireqYod,
            HolemWaw,
            Shureq,
            count
        }
        readonly ISimpleAudioPlayer[] LongVowelSoundPlayers = new ISimpleAudioPlayer[(int)LongVowel.count];
        readonly ISimpleAudioPlayer[] LongVowelNamePlayers = new ISimpleAudioPlayer[(int)LongVowel.count];
        readonly ISimpleAudioPlayer[] ShortVowelSoundPlayers = new ISimpleAudioPlayer[(int)ShortVowel.count];
        readonly ISimpleAudioPlayer[] ShortVowelNamePlayers = new ISimpleAudioPlayer[(int)ShortVowel.count];
        readonly ISimpleAudioPlayer[] ReducedVowelSoundPlayers = new ISimpleAudioPlayer[(int)ReducedVowel.count];
        readonly ISimpleAudioPlayer[] ReducedVowelNamePlayers = new ISimpleAudioPlayer[(int)ReducedVowel.count];
        readonly ISimpleAudioPlayer[] VowelLetterSoundPlayers = new ISimpleAudioPlayer[(int)VowelLetter.count];
        readonly ISimpleAudioPlayer[] VowelLetterNamePlayers = new ISimpleAudioPlayer[(int)VowelLetter.count];
        ISimpleAudioPlayer[] CurrentPlayers;
        public Vowels()
        {
            var player = CrossSimpleAudioPlayer.Current;
            InitializeComponent();

            FillSoundPlayers();
        }
        void FillSoundPlayers()
        {
            for (int i = 0; i < (int)LongVowel.count; i++)
            {
                LongVowelSoundPlayers[i] = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                LongVowelSoundPlayers[i].Loop = false;
            }
            for (int i = 0; i < (int)LongVowel.count; i++)
            {
                LongVowelNamePlayers[i] = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                LongVowelNamePlayers[i].Loop = false;
            }

            for (int i = 0; i < (int)ShortVowel.count; i++)
            {
                ShortVowelSoundPlayers[i] = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                ShortVowelSoundPlayers[i].Loop = false;
            }
            for (int i = 0; i < (int)ShortVowel.count; i++)
            {
                ShortVowelNamePlayers[i] = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                ShortVowelNamePlayers[i].Loop = false;
            }

            for (int i = 0; i < (int)ReducedVowel.count; i++)
            {
                ReducedVowelSoundPlayers[i] = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                ReducedVowelSoundPlayers[i].Loop = false;
            }
            for (int i = 0; i < (int)ReducedVowel.count; i++)
            {
                ReducedVowelNamePlayers[i] = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                ReducedVowelNamePlayers[i].Loop = false;
            }

            for (int i = 0; i < (int)VowelLetter.count; i++)
            {
                VowelLetterSoundPlayers[i] = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                VowelLetterSoundPlayers[i].Loop = false;
            }
            for (int i = 0; i < (int)VowelLetter.count; i++)
            {
                VowelLetterNamePlayers[i] = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                VowelLetterNamePlayers[i].Loop = false;
            }
            LoadSamples();
            int j = 0;
            foreach (Button button in GridVowelsLong.Children.Where(c => Grid.GetColumn(c) == 1))
            {
                LongVowel LongVowel = (LongVowel)j;
                button.Clicked += (s, e) => LongVowelSoundPlayers[(int)LongVowel]?.Play();

                j++;
            }
            j = 0;
            foreach (Button button in GridVowelsLong.Children.Where(c => Grid.GetColumn(c) == 2))
            {
                LongVowel LongVowel = (LongVowel)j;
                button.Clicked += (s, e) => LongVowelNamePlayers[(int)LongVowel]?.Play();

                j++;
            }
            j = 0;
            foreach (Button button in GridVowelsShort.Children.Where(c => Grid.GetColumn(c) == 1))
            {
                ShortVowel ShortVowel = (ShortVowel)j;
                button.Clicked += (s, e) => ShortVowelSoundPlayers[(int)ShortVowel]?.Play();

                j++;
            }
            j = 0;
            foreach (Button button in GridVowelsShort.Children.Where(c => Grid.GetColumn(c) == 2))
            {
                ShortVowel ShortVowel = (ShortVowel)j;
                button.Clicked += (s, e) => ShortVowelNamePlayers[(int)ShortVowel]?.Play();

                j++;
            }
            j = 0;
            foreach (Button button in GridVowelsReduced.Children.Where(c => Grid.GetColumn(c) == 1))
            {
                ReducedVowel ReducedVowel = (ReducedVowel)j;
                button.Clicked += (s, e) => ReducedVowelSoundPlayers[(int)ReducedVowel]?.Play();

                j++;
            }
            j = 0;
            foreach (Button button in GridVowelsReduced.Children.Where(c => Grid.GetColumn(c) == 2))
            {
                ReducedVowel ReducedVowel = (ReducedVowel)j;
                button.Clicked += (s, e) => ReducedVowelNamePlayers[(int)ReducedVowel]?.Play();

                j++;
            }
            j = 0;
            foreach (Button button in GridVowelLetters.Children.Where(c => Grid.GetColumn(c) == 1))
            {
                VowelLetter VowelLetter = (VowelLetter)j;
                button.Clicked += (s, e) => VowelLetterSoundPlayers[(int)VowelLetter]?.Play();

                j++;
            }
            j = 0;
            foreach (Button button in GridVowelLetters.Children.Where(c => Grid.GetColumn(c) == 2))
            {
                VowelLetter VowelLetter = (VowelLetter)j;
                button.Clicked += (s, e) => VowelLetterNamePlayers[(int)VowelLetter]?.Play();

                j++;
            }

        }
        async void OnHomePageClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
        async void OnVowelsLongClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LongVowels());
        }
        async void OnVowelsShortClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShortVowels());
        }
        void LoadSamples()
        {
            LongVowelSoundPlayers[(int)LongVowel.Qamets].Load(GetStreamFromFile("audio.VowelPronunciations.qamets.mp3"));
            LongVowelSoundPlayers[(int)LongVowel.Tsere].Load(GetStreamFromFile("audio.VowelPronunciations.tsere.mp3"));
            LongVowelSoundPlayers[(int)LongVowel.Holem].Load(GetStreamFromFile("audio.VowelPronunciations.holem.mp3"));

            LongVowelNamePlayers[(int)LongVowel.Qamets].Load(GetStreamFromFile("audio.VowelNames.qamets.mp3"));
            LongVowelNamePlayers[(int)LongVowel.Tsere].Load(GetStreamFromFile("audio.VowelNames.tsere.mp3"));
            LongVowelNamePlayers[(int)LongVowel.Holem].Load(GetStreamFromFile("audio.VowelNames.holem.mp3"));

            ShortVowelSoundPlayers[(int)ShortVowel.Pathach].Load(GetStreamFromFile("audio.VowelPronunciations.pathach.mp3"));
            ShortVowelSoundPlayers[(int)ShortVowel.Seghol].Load(GetStreamFromFile("audio.VowelPronunciations.seghol.mp3"));
            ShortVowelSoundPlayers[(int)ShortVowel.Hireq].Load(GetStreamFromFile("audio.VowelPronunciations.hireq.mp3"));
            ShortVowelSoundPlayers[(int)ShortVowel.QametsHatuf].Load(GetStreamFromFile("audio.VowelPronunciations.qametsHatuf.mp3"));
            ShortVowelSoundPlayers[(int)ShortVowel.Qibbuts].Load(GetStreamFromFile("audio.VowelPronunciations.qibbuts.mp3"));

            ShortVowelNamePlayers[(int)ShortVowel.Pathach].Load(GetStreamFromFile("audio.VowelNames.pathach.mp3"));
            ShortVowelNamePlayers[(int)ShortVowel.Seghol].Load(GetStreamFromFile("audio.VowelNames.seghol.mp3"));
            ShortVowelNamePlayers[(int)ShortVowel.Hireq].Load(GetStreamFromFile("audio.VowelNames.hireq.mp3"));
            ShortVowelNamePlayers[(int)ShortVowel.QametsHatuf].Load(GetStreamFromFile("audio.VowelNames.qametsHatuf.mp3"));
            ShortVowelNamePlayers[(int)ShortVowel.Qibbuts].Load(GetStreamFromFile("audio.VowelNames.qibbuts.mp3"));

            ReducedVowelSoundPlayers[(int)ReducedVowel.HatephPathach].Load(GetStreamFromFile("audio.silence.mp3"));
            ReducedVowelSoundPlayers[(int)ReducedVowel.HatephSeghol].Load(GetStreamFromFile("audio.silence.mp3"));
            ReducedVowelSoundPlayers[(int)ReducedVowel.HatephQamets].Load(GetStreamFromFile("audio.silence.mp3"));

            ReducedVowelNamePlayers[(int)ReducedVowel.HatephPathach].Load(GetStreamFromFile("audio.silence.mp3"));
            ReducedVowelNamePlayers[(int)ReducedVowel.HatephSeghol].Load(GetStreamFromFile("audio.silence.mp3"));
            ReducedVowelNamePlayers[(int)ReducedVowel.HatephQamets].Load(GetStreamFromFile("audio.silence.mp3"));

            VowelLetterSoundPlayers[(int)VowelLetter.QametsHe].Load(GetStreamFromFile("audio.VowelPronunciations.qamets.mp3"));
            VowelLetterSoundPlayers[(int)VowelLetter.TsereYod].Load(GetStreamFromFile("audio.VowelPronunciations.tsereYod.mp3"));
            VowelLetterSoundPlayers[(int)VowelLetter.SegholYod].Load(GetStreamFromFile("audio.VowelPronunciations.seghol.mp3"));
            VowelLetterSoundPlayers[(int)VowelLetter.HireqYod].Load(GetStreamFromFile("audio.VowelPronunciations.hireqYod.mp3"));
            VowelLetterSoundPlayers[(int)VowelLetter.HolemWaw].Load(GetStreamFromFile("audio.VowelPronunciations.holemWaw.mp3"));
            VowelLetterSoundPlayers[(int)VowelLetter.Shureq].Load(GetStreamFromFile("audio.VowelPronunciations.shureq.mp3"));

            VowelLetterNamePlayers[(int)VowelLetter.QametsHe].Load(GetStreamFromFile("audio.VowelNames.qametsHe.mp3"));
            VowelLetterNamePlayers[(int)VowelLetter.TsereYod].Load(GetStreamFromFile("audio.VowelNames.tsereYod.mp3"));
            VowelLetterNamePlayers[(int)VowelLetter.SegholYod].Load(GetStreamFromFile("audio.VowelNames.segholYod.mp3"));
            VowelLetterNamePlayers[(int)VowelLetter.HireqYod].Load(GetStreamFromFile("audio.VowelNames.hireqYod.mp3"));
            VowelLetterNamePlayers[(int)VowelLetter.HolemWaw].Load(GetStreamFromFile("audio.VowelNames.holemWaw.mp3"));
            VowelLetterNamePlayers[(int)VowelLetter.Shureq].Load(GetStreamFromFile("audio.VowelNames.shureq.mp3"));
        }


        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("HebNavi." + filename);

            return stream;
        }

    }
}