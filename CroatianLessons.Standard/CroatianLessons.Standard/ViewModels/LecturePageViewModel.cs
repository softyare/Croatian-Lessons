using CroatianLessons.Standard.Models;
using CroatianLessons.Standard.Views;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace CroatianLessons.Standard.ViewModels
{
    public class LecturePageViewModel : IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Lecture currentLecture;
        private Lesson selectedLesson;
        private JObject lectureJObject;
        public ICommand OpenLessonCommand { get; set; }
        public INavigation Navigation { get; set; }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Lesson SelectedLessonItem
        {
            get
            {
                return selectedLesson;
            }
            set
            {
                selectedLesson = value;
                OnPropertyChanged(nameof(SelectedLessonItem));
            }
        }

        private async void OpenLesson()
        {
            if (SelectedLessonItem != null)
            {
                LessonPageViewModel vm = new LessonPageViewModel(SelectedLessonItem, currentLecture, Navigation);
                await Navigation.PushModalAsync(new NavigationPage( new LessonPage() { BindingContext = vm } ));
            }
        }

        public string LectureTitle
        {
            get { return CurrentLecture.Title; }
        }

        public Lecture CurrentLecture { get { return currentLecture; } }

        public List<Lesson> Lessons
        {
            get
            {
                return CurrentLecture.Lessons;
            }
        }

        public LecturePageViewModel(JObject lectureJsonObject)
        {
            OpenLessonCommand = new Command(OpenLesson);
            lectureJObject = lectureJsonObject;
            GetLectureFromJObject(lectureJObject);
        }

        public void GetLectureFromJObject(JObject lectureJO)
        {

            try
            {
                List<Lesson> lessons = new List<Lesson>();
                foreach (var lesson in lectureJO["Lessons"].Values())
                {
                    Lesson newLesson = new Lesson()
                    {
                        LectureId = lesson["LectureId"].Value<string>(),
                        LessonId = lesson["LessonId"].Value<string>(),
                        Title = lesson["Title"].Value<string>(),
                        Info = lesson["Info"].Value<string>(),
                        Phrase = lesson["Phrase"].Value<string>(),
                        Translation = lesson["Translation"].Value<string>(),
                        Memo = lesson["Memo"].Value<string>()
                    };
                    lessons.Add(newLesson);
                }
                Lecture lecture = new Lecture()
                {
                    LectureId = lectureJO["LectureId"].Value<string>(),
                    Title = lectureJO["Title"].Value<string>(),
                    Lessons = lessons
                };

                currentLecture = lecture;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

    }
}
