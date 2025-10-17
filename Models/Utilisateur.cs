using System;
using System.Collections.Generic;

namespace restaurant3.Models;

public partial class Utilisateur
{
    public int IdUtilisateur { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string MotDePasse { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string? Telephone { get; set; }

    public string? Adresse { get; set; }

    public DateTime? DateInscription { get; set; }

    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();

    public virtual Employe? Employe { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
