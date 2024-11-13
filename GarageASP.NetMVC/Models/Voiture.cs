using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageASP.NetMVC.Models;

public partial class Voiture
{
    [StringLength(6, MinimumLength = 6)]
    [RegularExpression(@"^[A-Z]{2}\d{4}$", ErrorMessage = "L'immatriculation doit être au format 'AA0000'.")]
    public string Immatriculation { get; set; } = null!;

    [Required]
    public string? Marque { get; set; }

    [Required]
    public string? Modele { get; set; }

    [Required]
    public string? Etat { get; set; }
}
