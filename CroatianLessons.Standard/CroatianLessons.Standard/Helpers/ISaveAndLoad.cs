using System;
using System.Collections.Generic;
using System.Text;

namespace CroatianLessons.Standard.Helpers
{
    public interface ISaveAndLoad
    {
        void SaveText(string filename, string text);
        string LoadText(string filename);
        bool FileExists(string filename);
    }
}
