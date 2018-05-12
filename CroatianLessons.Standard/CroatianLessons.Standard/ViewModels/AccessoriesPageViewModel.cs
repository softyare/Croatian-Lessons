using CroatianLessons.Standard.Models;
using CroatianLessons.Standard.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Globalization;
using DLToolkit.Forms.Controls;
using Plugin.SimpleAudioPlayer.Abstractions;

namespace CroatianLessons.Standard.ViewModels
{
    internal class AccessoriesPageViewModel : IViewModel
    {
        private List<Letter> letters = new List<Letter>() {
            new Letter() { Upper="A", Lower="a", Long="a", Example="Avantura",
                Translation = Resources.AppResources.A, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.a.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.a.mp3" },
            new Letter() { Upper="B", Lower="b", Long="be", Example="Buba",
                Translation = Resources.AppResources.B, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.b.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.b.mp3" },
            new Letter() { Upper="C", Lower="c", Long="ce", Example="Cesta",
                Translation = Resources.AppResources.C, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.c.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.c.mp3" },
            new Letter() { Upper="Č", Lower="č", Long="če", Example="Čovjek",
                Translation = Resources.AppResources.Cx, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.cx.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.cx.mp3" },
            new Letter() { Upper="Ć", Lower="ć", Long="će", Example="Ćuk",
                Translation = Resources.AppResources.Cy, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.cy.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.cy.mp3" },
            new Letter() { Upper="D", Lower="d", Long="de", Example="Djed",
                Translation = Resources.AppResources.D, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.d.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.d.mp3" },
            new Letter() { Upper="Dž", Lower="dž", Long="dže", Example="Džemper",
                Translation = Resources.AppResources.Dx, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.dx.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.dx.mp3" },
            new Letter() { Upper="Đ", Lower="đ", Long="đe", Example="Đak",
                Translation = Resources.AppResources.Dy, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.dy.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.dy.mp3" },
            new Letter() { Upper="E", Lower="e", Long="e", Example="Energija",
                Translation = Resources.AppResources.E, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.e.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.e.mp3" },
            new Letter() { Upper="F", Lower="f", Long="ef", Example="Frizura",
                Translation = Resources.AppResources.F, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.f.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.f.mp3" },
            new Letter() { Upper="G", Lower="g", Long="ge", Example="Grad",
                Translation = Resources.AppResources.G, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.g.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.g.mp3" },
            new Letter() { Upper="H", Lower="h", Long="ha", Example="Hlače",
                Translation = Resources.AppResources.H, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.h.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.h.mp3" },
            new Letter() { Upper="I", Lower="i", Long="i", Example="Igla",
                Translation = Resources.AppResources.I, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.i.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.i.mp3" },
            new Letter() { Upper="J", Lower="j", Long="je", Example="Jabuka",
                Translation = Resources.AppResources.J, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.j.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.j.mp3" },
            new Letter() { Upper="K", Lower="k", Long="ka", Example="Kutija",
                Translation = Resources.AppResources.K, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.k.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.k.mp3" },
            new Letter() { Upper="L", Lower="l", Long="el", Example="Leptir",
                Translation = Resources.AppResources.L, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.l.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.l.mp3" },
            new Letter() { Upper="Lj", Lower="lj", Long="elj", Example="Ljubav",
                Translation = Resources.AppResources.Lj, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.lj.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.lj.mp3" },
            new Letter() { Upper="M", Lower="m", Long="em", Example="Mama",
                Translation = Resources.AppResources.M, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.m.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.m.mp3" },
            new Letter() { Upper="N", Lower="n", Long="en", Example="Nebo",
                Translation = Resources.AppResources.N, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.n.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.n.mp3" },
            new Letter() { Upper="Nj", Lower="nj", Long="enj", Example="Njihaljka",
                Translation = Resources.AppResources.Nj, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.nj.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.nj.mp3" },
            new Letter() { Upper="O", Lower="o", Long="o", Example="Oblak",
                Translation = Resources.AppResources.O, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.o.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.o.mp3" },
            new Letter() { Upper="P", Lower="p", Long="pe", Example="Prst",
                Translation = Resources.AppResources.P, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.p.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.p.mp3" },
            new Letter() { Upper="R", Lower="r", Long="er", Example="Riba",
                Translation = Resources.AppResources.R, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.r.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.r.mp3" },
            new Letter() { Upper="S", Lower="s", Long="es", Example="Stol",
                Translation = Resources.AppResources.S, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.s.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.s.mp3" },
            new Letter() { Upper="Š", Lower="š", Long="eš", Example="Šuma",
                Translation = Resources.AppResources.Sx, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.sx.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.sx.mp3" },
            new Letter() { Upper="T", Lower="t", Long="te", Example="Torba",
                Translation = Resources.AppResources.T, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.t.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.t.mp3" },
            new Letter() { Upper="U", Lower="u", Long="u", Example="Uho",
                Translation = Resources.AppResources.U, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.u.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.u.mp3" },
            new Letter() { Upper="V", Lower="v", Long="ve", Example="Vino",
                Translation = Resources.AppResources.V, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.v.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.v.mp3" },
            new Letter() { Upper="Z", Lower="z", Long="ze", Example="Zima",
                Translation = Resources.AppResources.Z, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.z.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.z.mp3" },
            new Letter() { Upper="Ž", Lower="ž", Long="že", Example="Žar",
                Translation = Resources.AppResources.Zx, ExampleImagePath="CroatianLessons.Standard.Resources.AbecedaImg.zx.png", AudioPath="CroatianLessons.Standard.Resources.Audio.Abeceda.zx.mp3" }
        };

        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }
        public Command OpenLetterCommand { get; set; }

        public List<Letter> Letters
        {
            get { return letters; }
        }

        private string selectedUpper;
        public string SelectedUpper
        {
            get => selectedUpper;
            set
            {
                selectedUpper = value;
                OnPropertyChanged(nameof(SelectedUpper));
            }
        }
        private string selectedLong;
        public string SelectedLong
        {
            get => selectedLong;
            set
            {
                selectedLong = value;
                OnPropertyChanged(nameof(SelectedLong));
            }
        }
        private string selectedExample;
        public string SelectedExample
        {
            get => selectedExample;
            set
            {
                selectedExample = value;
                OnPropertyChanged(nameof(SelectedExample));
            }
        }
        private string selectedTranslation;
        public string SelectedTranslation
        {
            get => selectedTranslation;
            set
            {
                selectedTranslation = value;
                OnPropertyChanged(nameof(SelectedTranslation));
            }
        }

        private Letter lastTappedItem;
        public Letter LastTappedItem 
        {
            get => lastTappedItem;
            set
            {
                lastTappedItem = value;
                OnPropertyChanged(nameof(LastTappedItem));
            }
        }

        public AccessoriesPageViewModel()
        {
            FlowListView.Init();
            LastTappedItem = Letters[0];
            SelectedUpper = LastTappedItem.Upper;
            SelectedLong = LastTappedItem.Long;
            SelectedExample = LastTappedItem.Example;
            SelectedTranslation = "Translation";
            OpenLetterCommand = new Command(OpenLetter);
        }

        private void OpenLetter()
        {
            SelectedUpper = LastTappedItem.Upper;
            OnPropertyChanged(SelectedUpper);
            SelectedLong = LastTappedItem.Long;
            OnPropertyChanged(SelectedLong);
            SelectedExample = LastTappedItem.Example;
            OnPropertyChanged(SelectedExample);
            SelectedTranslation = "Translation";
            PlayAudio(LastTappedItem);
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
        }

        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(filename);

            return stream;
        }

        private void PlayAudio(Letter l)
        {
            ISimpleAudioPlayer player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

            try
            {
                if (!player.IsPlaying)
                {
                    player.Load(GetStreamFromFile(l.AudioPath));
                    player.Play();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Nema audio filea za " + l.Upper);
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
    }
}