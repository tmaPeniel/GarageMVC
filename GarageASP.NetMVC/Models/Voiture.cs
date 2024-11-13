using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageASP.NetMVC.Models;

public partial class Voiture
{
    public string Immatriculation { get; set; } = null!;

    [Required]
    public string? Marque { get; set; }

    [Required]
    public string? Modele { get; set; }

    [Required]
    public string? Etat { get; set; }
}
