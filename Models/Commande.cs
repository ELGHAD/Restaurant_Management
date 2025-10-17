using System;
using System.Collections.Generic;

namespace restaurant3.Models;

public partial class Commande
{
    public int IdCommande { get; set; }

    public int? IdClient { get; set; }

    public DateTime? DateCommande { get; set; }

    public decimal Total { get; set; }

    public string? Statut { get; set; }

    public string TypeCommande { get; set; } = null!;

    public virtual ICollection<DetailsCommande> DetailsCommandes { get; set; } = new List<DetailsCommande>();

    public virtual Utilisateur? IdClientNavigation { get; set; }

    public virtual ICollection<Vente> Ventes { get; set; } = new List<Vente>();
}
