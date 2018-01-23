using System.Globalization;

namespace CroatianLessons.Standard.Helpers
{
    public interface ILocalize
    {
        /// <summary>
        /// Gets device's culture info
        /// </summary>
        /// <returns>CultureInfo</returns>
        CultureInfo GetCultureInfo();
        void SetLocale(CultureInfo ci);
    }
}
