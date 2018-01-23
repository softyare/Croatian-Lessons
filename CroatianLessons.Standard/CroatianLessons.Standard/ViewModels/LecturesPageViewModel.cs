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
using DLToolkit.Forms.Controls;


namespace CroatianLessons.Standard.ViewModels
{
    public class LecturesPageViewModel : IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }
        public Command OpenLectureCommand { get; set; }
        private JObject selectedLectureJObject;
        public JObject SelectedLectureJObject { get => selectedLectureJObject; set => selectedLectureJObject = value; }

        public LecturesPageViewModel()
        {
            FlowListView.Init();
            OpenLectureCommand = new Command(OpenNewPage);
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
        }

        public List<string> LectureFileNames
        {
            get
            {
                return GetLectureFileNames(Settings.Settings.AppLanguageCode);
            }
        }

        private ObservableCollection<LectureListItem> lectureItemsList;
        public ObservableCollection<LectureListItem> LectureListItems
        {
            get
            {
                lectureItemsList = CreateLecureItemsList();
                return lectureItemsList;
            }
            set
            {
                lectureItemsList = value;
                OnPropertyChanged(nameof(LectureListItems));
            }
        }

        public ObservableCollection<LectureListItem> CreateLecureItemsList()
        {
            List<LectureListItem> items = new List<LectureListItem>();
            if (LectureFileNames.Count > 0)
            {
                foreach (string filename in LectureFileNames)
                {
                    string json = GetJsonStringFromFile(filename);
                    JObject lecture = JObject.Parse(json);
                    string title = lecture["Title"].Value<string>();
                    string lecid = lecture["LectureId"].Value<string>();
                    var imageSource = ImageSource.FromResource($"CroatianLessons.Standard.Resources.Lectures.Icons.{lecid}.png");
                    items.Add
                        (
                           new LectureListItem() { Title = title, FilePath = filename, LectureIconImageSource = imageSource }
                        );
                }
                return new ObservableCollection<LectureListItem>(items);
            }

            return null;
        }

        private LectureListItem lastTappedItem;
        public LectureListItem LastTappedItem {
            get => lastTappedItem;
            set
            {
                lastTappedItem = value;
                
                OnPropertyChanged(nameof(LastTappedItem));
            }
        }

        private async void OpenNewPage()
        {
            string json = GetJsonStringFromFile(lastTappedItem.FilePath);
            JObject lecture = JObject.Parse(json);
            selectedLectureJObject = lecture;
            LecturePageViewModel vm = new LecturePageViewModel(selectedLectureJObject) { Navigation = this.Navigation };
            await Navigation.PushAsync(new NavigationPage(new LecturePage(vm)));
        }

        private List<string> GetLectureFileNames(string appLanguageCode)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var allResources = assembly.GetManifestResourceNames();
            var result = new List<String>();

            foreach(string name in allResources)
            {
                if (name.Contains($"Lectures.{appLanguageCode.ToLower()}"))
                {
                    result.Add(name);
                }
            }

            return result;
        }

        public string GetJsonStringFromFile(string jsonFileName)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(jsonFileName);

            string json = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            return json;
        }
    }
}
