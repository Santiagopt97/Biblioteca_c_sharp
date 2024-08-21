using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Biblioteca_c_sharp.Models;

public class Book
{
    public BigInteger Id { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public string Isbn { get; set; }

    public string Category { get; set; }

    public bool Available { get; set; }

    public Book (BigInteger id, string title, string author, string isbn, string category, bool available)
    {
        Id = id;
        Title = title;
        Author = author;
        Isbn = isbn;
        Category = category;
        Available = available;
    }

    
}
