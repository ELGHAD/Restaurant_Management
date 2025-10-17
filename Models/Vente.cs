using System;
using System.Collections.Generic;

namespace restaurant3.Models;

public partial class Vente
{
    public int IdVente { get; set; }

    public int? IdCommande { get; set; }

    public DateTime? DateVente { get; set; }

    public decimal MontantTotal { get; set; }

    public decimal? Remise { get; set; }

    public decimal? MontantFinal { get; set; }

    public virtual Commande? IdCommandeNavigation { get; set; }
}
