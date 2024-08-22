using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Biblioteca_c_sharp.Models;
public class User
{
    [Key]
    public BigInteger Id { get; set; }

    public string Document_Number { get; set; }

    public string Name { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string Contact_Number { get; set; }

    public User(BigInteger id, string document_Number, string name, string address, string contact_Number)
    {
        Id = id;
        Document_Number = document_Number;
        Name = name;
        Address = address;
        Contact_Number = contact_Number;
    }
}