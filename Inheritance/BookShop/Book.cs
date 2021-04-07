using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
    public class Book
    {
        private string author;
        private string title;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public string Author
        {
            get => this.author;
            set
            {
                if (value.Split().Length > 1 && char.IsDigit(value.Split()[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
                this.author = value;
            }
        }
        public string Title
        {
            get => this.title;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                this.title = value;
            }
        }

        public virtual decimal Price
        {
            get => this.price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                this.price = value;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Title: {this.Title}");
            sb.AppendLine($"Author: {this.Author}");
            sb.Append($"Price: {this.Price:f2}");
            return sb.ToString();
        }
    }
}
