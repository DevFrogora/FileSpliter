using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileChunker
{
    public class FileMerger
    {
        public bool MergeFile(List<string> listOfFileName,string outputFileName)
        {
            bool isMerged = false;
            try
            {
                FileStream outputFile = null;
                string PrevFileName = "";
                foreach (string tempFile in listOfFileName)
                {
                    string tempfileName = Path.GetFileNameWithoutExtension(tempFile);
                    string baseFileName = tempfileName.Substring(0, tempfileName.IndexOf(Convert.ToChar(".")));
                    string extension = Path.GetExtension(tempfileName);
                    if (!PrevFileName.Equals(baseFileName))
                    {
                        if (outputFile != null)
                        {
                            outputFile.Flush();
                            outputFile.Close();
                        }
                        outputFile = new FileStream(outputFileName, FileMode.OpenOrCreate, FileAccess.Write);
                    }
                    int bytesRead = 0;
                    byte[] buffer = new byte[1024];
                    FileStream inputTempFile = new FileStream(tempFile, FileMode.OpenOrCreate, FileAccess.Read);
                    while ((bytesRead = inputTempFile.Read(buffer, 0, 1024)) > 0)
                        outputFile.Write(buffer, 0, bytesRead);
                    inputTempFile.Close();
                    File.Delete(tempFile);
                    PrevFileName = baseFileName;
                }
                outputFile.Close();
                isMerged = true;
            }
            catch
            {
            }
            return isMerged;

        }
    }
}
