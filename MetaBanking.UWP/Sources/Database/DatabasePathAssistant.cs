using System.IO;
using Windows.Storage;
using Xamarin.Forms;
using MetaBanking.UWP;

[assembly: Dependency(typeof(DatabasePathAssistant))]
namespace MetaBanking.UWP
{
    public class DatabasePathAssistant
    {

        public static string GetDatabasePath(string sqliteFilename)
        {
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            return path;
        }
    }
}
