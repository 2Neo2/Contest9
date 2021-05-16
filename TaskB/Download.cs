using System;

public class Download<T> : IDownload where T : Content
{
    private readonly T download;

    public Download(T download)
    {
        this.download = download;
    }

    public bool DownloadContent()
    {
        Program.FreeSpace -= download.Size;
        if (Program.FreeSpace > 0)
        {
            Console.WriteLine($"{download.Size}/{download.Size} MB");
            switch (download)
            {
                case Movie movie:
                    Loader.AddValueToStore("Movie");
                    break;
                case Game game:
                    Loader.AddValueToStore("Game");
                    break;
                case Track track:
                    Loader.AddValueToStore("Track");
                    break;
                default:
                    Loader.AddValueToStore("Content");
                    break;
            }
            return true;
        }
        else
        {
            Console.WriteLine($"{download.Size + Program.FreeSpace}/{download.Size} MB");
            return false;
        }
    }
}