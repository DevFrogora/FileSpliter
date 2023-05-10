namespace FileChunker
{
    public class FileSplitter
    {

        public bool IncomingRequest(string filePath, FileSplitterParameter fSP)
        {
            try
            {
                return SplitFile(filePath, fSP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        bool SplitFile(string sourceFilePath, FileSplitterParameter fSP)
        {
            bool Split = false;
            try
            {
                FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read);

                fSP.sizeofEachFile = fSP.numberOfChunkFile == 0 ?   fSP.sizeofEachFile : (int)Math.Ceiling((double)sourceStream.Length / fSP.numberOfChunkFile);
                string absoluteFilePath = sourceStream.Name;
                string baseFileName = string.IsNullOrEmpty(fSP.baseFileName) ? Path.GetFileNameWithoutExtension(absoluteFilePath) : fSP.baseFileName;
                string extension = string.IsNullOrEmpty(fSP.extension) ? Path.GetExtension(absoluteFilePath) : fSP.extension;
                string outputFolder = string.IsNullOrEmpty(fSP.outputFolder) ? Path.GetDirectoryName(absoluteFilePath) : fSP.outputFolder;

                int i = 0;
                int numberOfSizeChunked = 0;
                while (sourceStream.Length != numberOfSizeChunked)
                {
                    string fileName = fileNamePattern(i, outputFolder, baseFileName, extension);
                    FileStream outputFile = new FileStream(fileName, FileMode.Create, FileAccess.Write);

                    int bytesRead = 0;
                    byte[] buffer = new byte[fSP.sizeofEachFile];
                    if ((bytesRead = sourceStream.Read(buffer, 0, fSP.sizeofEachFile)) > 0)
                    {
                        numberOfSizeChunked += bytesRead;
                        outputFile.Write(buffer, 0, bytesRead);
                    }

                    outputFile.Close();
                    i++;
                }
                sourceStream.Close();
                Split = true;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return Split;
        }

        public virtual string fileNamePattern(int count, string outputFolder, string baseFileName, string extension)
        {
            return outputFolder + "\\" + baseFileName + "." +
                        count.ToString().PadLeft(5, Convert.ToChar("0")) + extension + ".tmp";
        }


    }
    public class FileSplitterParameter
    {
        public int sizeofEachFile = 0;
        public int numberOfChunkFile = 0;
        public string baseFileName;
        public string extension;
        public string outputFolder;
    }

}