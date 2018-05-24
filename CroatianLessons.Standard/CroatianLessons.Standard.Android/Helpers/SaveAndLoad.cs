using System.IO;
using CroatianLessons.Standard.Droid.Helpers;
using CroatianLessons.Standard.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndLoad))]
namespace CroatianLessons.Standard.Droid.Helpers
{
    public class SaveAndLoad : ISaveAndLoad
    {
        public bool FileExists(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return File.Exists(filePath);
        }

        public string LoadText(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return System.IO.File.ReadAllText(filePath);
        }

        public void SaveText(string filename, string text)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            File.WriteAllText(filePath, text);
        }
    }
}