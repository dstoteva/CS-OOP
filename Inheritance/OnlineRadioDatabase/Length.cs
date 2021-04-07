using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnlineRadioDatabase
{
    public class Length
    {
        private int minutes;
        private int seconds;

        public Length(string length)
        {
            if (length.Split(":").Length != 2 || !int.TryParse(length.Split(":")[0], out int mins) || !int.TryParse(length.Split(":")[1], out int secs))
            {
                throw new ArgumentException("Invalid song length.");
            }
            this.Minutes = int.Parse(length.Split(":")[0]);
            this.Seconds = int.Parse(length.Split(":")[1]);
        }

        public int Minutes
        {
            get => this.minutes;
            private set
            {
                if (value < 0 || value > 14)
                {
                    throw new ArgumentException("Song minutes should be between 0 and 14.");
                }
                this.minutes = value;
            }
        }
        public int Seconds
        {
            get => this.seconds;
            private set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException("Song seconds should be between 0 and 59.");
                }
                this.seconds = value;
            }
        }
    }
}
