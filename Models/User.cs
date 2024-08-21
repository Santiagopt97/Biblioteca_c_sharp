using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_c_sharp.Models
{
    public class User : Document_type
    {
        public int Id { get; set; }
        public int Document_number { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact_number { get; set; }

        public void ShowInformation(){
            Console.WriteLine($@"Id: {Id}
            Name: {Name} 
            Document Type: {Document_name}
            {Abbreviation}: Document Number: {Document_number}
            Address: {Address}
            Contact Number: {Contact_number}");
        }

    }
}