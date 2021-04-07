using System;

namespace OnlineRadioDatabase
{
    public class Program
    {
        static void Main(string[] args)
        {
            PlayList playList = new PlayList();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] songArgs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    Song song = new Song(songArgs);
                    playList.AddSong(song);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            playList.ReturnSongsCount();
            playList.GetTotalLength();
        }
    }
}
