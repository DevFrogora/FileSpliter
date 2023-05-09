using FileChunker;

Console.WriteLine("Choose \n\t1. File Split \n\t2. File Merge ");
int option = Convert.ToInt16(Console.ReadLine());

if (option == 1)
{
    FileSplitter fileSplitter = new FileSplitter();
    FileSplitterParameter fileSplitterParameter = new FileSplitterParameter();
    fileSplitterParameter.numberOfChunkFile = Convert.ToInt32(args[1]);
    bool Successed = fileSplitter.IncomingRequest(args[0], fileSplitterParameter);
    if (Successed)
    {
        Console.WriteLine("Split is done");
    }
    else
    {
        Console.WriteLine("split is failed");
    }
}
else if (option == 2)
{
    string selectedFile = args[0];
    string absoluteFilePath = Path.GetFullPath(selectedFile);
    selectedFile = Path.GetFileName(absoluteFilePath);
    string baseFileName = selectedFile.Substring(0, selectedFile.IndexOf(Convert.ToChar(".")));
    string extension = Path.GetExtension(Path.GetFileNameWithoutExtension(selectedFile));

    string directory = Path.GetDirectoryName(absoluteFilePath);
    List<string> listOfFiles = Directory.GetFiles(directory, baseFileName + ".?????" + extension + ".tmp").ToList<string>(); //listOfFileName
    FileMerger fileMerger = new FileMerger();
    string outputFileName = directory + "\\" + baseFileName + extension;
    bool Successed = fileMerger.MergeFile(listOfFiles,outputFileName);

    if (Successed)
    {
        Console.WriteLine("Merger is done");
    }
    else
    {
        Console.WriteLine("Merger is failed");
    }
}
else
{
    Console.WriteLine("invalid Option");
}

