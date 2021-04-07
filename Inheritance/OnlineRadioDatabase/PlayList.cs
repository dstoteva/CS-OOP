using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRadioDatabase
{
    public class PlayList
    {
        private List<Song> allSongs;

        public PlayList()
        {
            this.allSongs = new List<Song>();
        }

        public void AddSong(Song song)
        {
            allSongs.Add(song);
            Console.WriteLine("Song added.");
        }
        public void ReturnSongsCount()
        {
            Console.WriteLine($"Songs added: {this.allSongs.Count}");
        }
        public void GetTotalLength()
        {
            int lengthInSconds = 0;
            foreach (var s in allSongs)
            {
                lengthInSconds += s.Length.Minutes * 60 + s.Length.Seconds;
            }

            int hours = lengthInSconds / 3600;
            int seconds = lengthInSconds % 60;
            int minutes = (lengthInSconds / 60) % 60;

            Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");
        }
    }
}
