using System;
using System.Collections.Generic;

namespace GarageASP.NetMVC.Models;

public partial class Voiture
{
    public string Immatriculation { get; set; } = null!;

    public string? Marque { get; set; }

    public string? Modele { get; set; }

    public string? Etat { get; set; }
}
