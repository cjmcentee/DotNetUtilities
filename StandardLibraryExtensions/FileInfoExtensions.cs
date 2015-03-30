using System.IO;
using System.Text.RegularExpressions;

namespace StandardLibraryExtensions
{
    public static class FileInfoExtensions
    {
        public static Regex ImageExtensionMatcher = new Regex(@"\.jpg|\.jpeg|\.png|\.bmp|\.tif|\.tga");

        public static bool IsImage(this FileInfo self) {
            string fileExtension = Path.GetExtension(self.FullName).ToLower();
            return ImageExtensionMatcher.IsMatch(fileExtension);
        }
    }
}
