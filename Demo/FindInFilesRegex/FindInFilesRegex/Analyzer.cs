using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FindInFilesRegex
{
    public class Analyzer
    {
        public async Task<List<File>> FindInFilesAsync(string folder, string regex)
        {
            if (string.IsNullOrWhiteSpace(folder) || regex is null)
                return null;

            List<string> allFileNames = GetAllFileNames(folder);
            if (allFileNames is not null)
            {
                List<File> listFiles = new();

                foreach (string fileName in allFileNames)
                {
                    File newAnalyzedFile = await FindInFileAsync(fileName, regex);
                    listFiles.Add(newAnalyzedFile);
                }

                return listFiles;
            }
            else
            {
                return null;
            }
        }

        private List<string> GetAllFileNames(string folder)
        {
            if (string.IsNullOrWhiteSpace(folder))
                return null;

            List<string> allFullFileNames = new();

            DirectoryInfo dirInfo = new(folder);

            var allFiles = dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly);

            allFullFileNames = (from f in allFiles
                                select f.FullName)
                               .ToList();

            return allFullFileNames;
        }

        private async Task<File> FindInFileAsync(string fullFileName, string regexPattern)
        {
            if (string.IsNullOrEmpty(fullFileName) || regexPattern is null)
                return null;

            File file = new()
            {
                Name = Path.GetFileName(fullFileName),
                Folder = Path.GetDirectoryName(fullFileName)
            };
            Regex regex = new(regexPattern);

            string fileContent = await System.IO.File.ReadAllTextAsync(fullFileName);
            if (fileContent is not null)
            {
                MatchCollection matchCollection = regex.Matches(fileContent);
                file.CountMatches = matchCollection.Count;
            }
                        
            return file;
        }
    }
}
