using CroatianLessons.Standard.Helpers;
using CroatianLessons.Standard.Models;
using CroatianLessons.Standard.Views;
using Plugin.SimpleAudioPlayer;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
            SaveNoteCommand = new Command(SaveNote);
            LoadLessonNotes();
        }

        public string LessonTitle { get { return currentLesson.Title; } }
        public string LessonInfo { get { return currentLesson.Info; } }
        public string LessonPhrase { get { return currentLesson.Phrase; } }
        public string LessonTranslation { get { return currentLesson.Translation; } }
        public string LessonMemo { get { return currentLesson.Memo; } }

        private string lessonNotes;
        public string LessonNotes
        {
            get
            {
                return lessonNotes;
            }
            set
            {
                lessonNotes = value;
                OnPropertyChanged(nameof(LessonNotes));
            }
        }

        private string note;
        public string Note {
            get
            {
                return note;
            }
            set
            {
                note = value;
                OnPropertyChanged(nameof(Note));
            }
        }

        private int notesHeight;
        public int NotesHeight
        {
            get
            {
                return notesHeight;
            }
            set
            {
                notesHeight = value;
                OnPropertyChanged(nameof(NotesHeight));
            }
        }

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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("CroatianLessons.Standard.Resources.Audio." + filename + ".mp3");

            return stream;
        }

        public Command SaveNoteCommand { get; set; }
        private void SaveNote()
        {
            StringBuilder sb = new StringBuilder(lessonNotes);
            if(sb.Length > 0)
                sb.Append("\n");
            sb.Append(note);
            LessonNotes = sb.ToString();
            if (lessonNotes.Length > 0)
                NotesHeight = (lessonNotes.Split('\n').Length + 1) * 20;
            else
                NotesHeight = 1;
            Note = "";
            string lessonFileName = currentLesson.LectureId + currentLesson.LessonId + ".note";
            try
            {
                DependencyService.Get<ISaveAndLoad>().SaveText(lessonFileName, LessonNotes);
            }
            catch (IOException e)
            {
                Debug.WriteLine("IO Greška: " + e.Message);
            }
        }

        private void LoadLessonNotes()
        {
            string lessonFileName = currentLesson.LectureId + currentLesson.LessonId + ".note";
            try
            {
                if(DependencyService.Get<ISaveAndLoad>().FileExists(lessonFileName))
                {
                    LessonNotes = DependencyService.Get<ISaveAndLoad>().LoadText(lessonFileName);
                }

                if (lessonNotes.Length > 0)
                    NotesHeight = (lessonNotes.Split('\n').Length + 1) * 20;
                else
                    NotesHeight = 1;
                OnPropertyChanged(nameof(NotesHeight));
            }
            catch (System.Exception e)
            {
                Debug.WriteLine("Ne radi Load: " + e.Message);
            }
        }
    }
}
