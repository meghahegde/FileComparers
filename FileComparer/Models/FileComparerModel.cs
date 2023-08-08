using System;
using System.IO;

namespace FileComparer.Models
{
    public class FileComparerModel
    {
        public void CompareAndCopyFiles(string oldFolderPath, string newFolderPath)
        {
            string[] oldFiles = Directory.GetFiles(oldFolderPath);
            string[] newFiles = Directory.GetFiles(newFolderPath);

            foreach (string oldFile in oldFiles)
            {
                string oldFileName = Path.GetFileName(oldFile);
                string newFile = Array.Find(newFiles, file => Path.GetFileName(file).Equals(oldFileName, StringComparison.OrdinalIgnoreCase));

                if (newFile != null)
                {
                    string oldFileContent = File.ReadAllText(oldFile);
                    string newFileContent = File.ReadAllText(newFile);

                    int dataIndex = newFileContent.IndexOf("Data", StringComparison.OrdinalIgnoreCase);
                    if (dataIndex >= 0)
                    {
                        newFileContent = newFileContent.Substring(0, dataIndex + "Data".Length);
                        newFileContent += Environment.NewLine + oldFileContent;
                        File.WriteAllText(newFile, newFileContent);
                    }
                    else
                    {
                        throw new Exception($"The text 'Data' was not found in the new file: {newFile}");
                    }
                }
            }
        }
    }
}
