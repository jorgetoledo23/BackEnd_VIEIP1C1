using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_BD.Model
{
    public class Item
    {
        /*
        [Key]
        public int ASD { get; set; } */

        public int ItemId { get; set; }
        public string Nombre { get; set; }
        public int Vida { get; set; }
        public int Fuerza { get; set; }
        public int Coste { get; set; }
    }
}
