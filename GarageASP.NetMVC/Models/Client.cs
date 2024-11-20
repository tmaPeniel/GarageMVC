using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageASP.NetMVC.Models
{
    public class Client
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "L'adresse e-mail n'est pas valide.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "L'adresse e-mail n'est pas valide.")]
        public string Mail { get; set; }
        public List<Car>? Cars { get; set; }
    }
}
