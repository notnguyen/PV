using Bookstore_2._0.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bookstore_2._0.Entity
{
    public class Book : IBaseClass
    {
        private int id;
        private string title;
        private string author;
        private string genre;
        private int pages;

        public int ID { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public string Genre { get => genre; set => genre = value; }
        public int Pages { get => pages; set => pages=value; }

        public Book()
        {
        }

        public Book(int id, string title, string author, string genre, int pages)
        {
            ID = id;
            Title = title;
            Author = author;
            Genre = genre;
            Pages = pages;
        }

        public Book(string title, string author, string genre, int pages)
        {
            ID = 0;
            Title = title;
            Author = author;
            Genre = genre;
            Pages = pages;
        }

        public override string ToString()
        {
            return $"Book: {ID}, Title: {Title}, Author: {Author}, Genre: {Genre}, Pages: {Pages}";
        }
    }
}
