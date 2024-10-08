using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Biblioteca_c_sharp.Models;

public class Book
{
    [Key]
    public long Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public string Category { get; set; }
    [Required]
    public bool Available { get; set; }

    // Constructor con parámetros públicos
    public Book(long id ,string title, string author, string isbn, string category, bool available)
    {   
        Id = id;
        Title = title;
        Author = author;
        Isbn = isbn;
        Category = category;
        Available = available;
    }
}
