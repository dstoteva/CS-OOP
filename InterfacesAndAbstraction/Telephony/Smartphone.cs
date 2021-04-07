using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : IBrowsable, ICallable
    {
        private List<string> numbers;
        private List<string> sites;
        public Smartphone(string[] phoneNums, string[] sites)
        {
            this.numbers = new List<string>(phoneNums);
            this.sites = new List<string>(sites);
        }
        public string Browse()
        {
            var sb = new StringBuilder();
            foreach (var s in sites)
            {
                try
                {
                    if (s.Any(x => char.IsDigit(x)))
                    {
                        throw new ArgumentException("Invalid URL!");
                    }
                    else
                    {
                        sb.AppendLine($"Browsing: {s}!");
                    }
                }
                catch (Exception ex)
                {

                    sb.AppendLine(ex.Message);
                }
                
            }
            return sb.ToString();
        }

        public string Call()
        {
            var sb = new StringBuilder();
            foreach (var n in numbers)
            {
                try
                {
                    if (n.All(x => char.IsDigit(x)))
                    {
                        sb.AppendLine($"Calling... {n}");
                    }
                    else
                    {
                        throw new ArgumentException("Invalid number!");
                    }
                }
                catch (Exception ex )
                {

                    sb.AppendLine(ex.Message);
                }
                
            }
            return sb.ToString();
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(this.Call());
            sb.Append(this.Browse());
            return sb.ToString();
        }
    }
}
