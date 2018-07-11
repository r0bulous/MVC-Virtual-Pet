using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Virtual_Pet.Models
{
    public class VirtualPet
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [DisplayName("Type of Pet")]
        public string Type { get; set; }
        public int Hunger { get; set; }
        public int Thirst { get; set; }
        
    }
}