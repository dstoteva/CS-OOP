using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRadioDatabase
{
    public class Song
    {
        private string artist;
        private string songName;
        private Length length;

        public Song(string[] parameters)
        {
            if (parameters.Length != 3)
            {
                throw new ArgumentException("Invalid song.");
            }
            this.Artist = parameters[0];
            this.SongName = parameters[1];
            this.Length = new Length(parameters[2]);
        }
        public string Artist
        {
            get => this.artist;
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
                }
                this.artist = value;
            }

        }
        public string SongName
        {
            get => this.songName;
            set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new ArgumentException("Song name should be between 3 and 30 symbols.");
                }
                this.songName = value;
            }
        }
        public Length Length
        {
            get => this.length;
            set
            {
                this.length = value;
            }
        }

    }
}
