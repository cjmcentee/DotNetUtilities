using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemUtilities
{
    public static class FileSystem
    {
        /* Gets all files in a directory (but not subdirectories) that are of the format
         *      <ANY><SUFFIX>
         * 
         * So if the suffix is " picture.jpeg", the following files will be matched:
         *      01 picture.jpeg
         *      this picture.jpeg
         *      some picture.jpeg
         *      ...
         */
        public static List<FileInfo> GetFilesMatching(String root, String suffix)
        {
            string[] allFileNames = Directory.GetFiles(root);
            var matchingFileNames = allFileNames.Where(f => f.EndsWith(suffix));
            var matchingFiles = matchingFileNames.Select(f => new FileInfo(f)).ToList();
            return matchingFiles;
        }
    }
}
