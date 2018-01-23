using CroatianLessons.Standard.Models;
using CroatianLessons.Standard.Views;
using Plugin.SimpleAudioPlayer.Abstractions;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace CroatianLessons.Standard.ViewModels
{
    public class LessonPageViewModel : IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Lesson currentLesson;
        private Lecture currentLecture;
        private INavigation _nav;
        private Lesson previousLesson;
        private Lesson nextLesson;

        public LessonPageViewModel(Lesson lesson, Lecture lecture, INavigation nav)
        {
            _nav = nav;
            currentLesson = lesson;
            currentLecture = lecture;
            SetPrevAndNextLessons();
            PlayAudioCommand = new Command(PlayAudio);
            CloseModalPageCommand = new Command(CloseModalPage);
        }

        public string LessonTitle { get { return currentLesson.Title; } }
        public string LessonInfo { get { return currentLesson.Info; } }
        public string LessonPhrase { get { return currentLesson.Phrase; } }
        public string LessonTranslation { get { return currentLesson.Translation; } }
        public string LessonMemo { get { return currentLesson.Memo; } }

        public bool IsPreviousLessonAvailable
        {
            get { return previousLesson != null; }
        }

        public bool IsNextLessonAvailable
        {
            get { return nextLesson != null; }
        }

        private void SetPrevAndNextLessons()
        {
            previousLesson = null;
            nextLesson = null;
            int currentLessonIndex = currentLecture.Lessons.IndexOf(currentLesson);
            if (currentLessonIndex > 0)
            {
                previousLesson = currentLecture.Lessons[currentLessonIndex - 1];
            }
            if (currentLessonIndex < currentLecture.Lessons.Count - 1)
            {
                nextLesson = currentLecture.Lessons[currentLessonIndex + 1];
            }
        }

        public Command PlayAudioCommand { get; set; }
        private void PlayAudio()
        {
            ISimpleAudioPlayer player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

            try
            {
                if (!player.IsPlaying)
                {
                    player.Load(GetStreamFromFile(currentLesson.LectureId + currentLesson.LessonId));
                    player.Play();
                }
            }
            catch (System.Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Nema audio filea za " + currentLesson.LectureId + currentLesson.LessonId);
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public ICommand CloseModalPageCommand { get; set; }

        private async void CloseModalPage()
        {
            await _nav.PopModalAsync(true);
        }

        public ICommand OpenNextPageCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _nav.PopModalAsync();
                    LessonPageViewModel vm = new LessonPageViewModel(nextLesson, currentLecture, _nav);
                    await _nav.PushModalAsync(new NavigationPage(new LessonPage() { BindingContext = vm }));
                });
            }
        }
        public ICommand OpenPrevPageCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _nav.PopModalAsync();
                    LessonPageViewModel vm = new LessonPageViewModel(previousLesson, currentLecture, _nav);
                    await _nav.PushModalAsync(new NavigationPage(new LessonPage() { BindingContext = vm }));
                });
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
        }

        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("CroatianLessons.Standard.Resources.Audio." + filename + ".mp3");

            return stream;
        }
    }
}
