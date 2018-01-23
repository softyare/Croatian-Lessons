using System.Globalization;

namespace CroatianLessons.Standard.Helpers
{
    public interface ILocalize
    {
        CultureInfo GetCultureInfo();
        void SetLocale(CultureInfo ci);
    }
}
