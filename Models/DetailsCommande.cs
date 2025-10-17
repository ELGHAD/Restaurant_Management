using System;
using System.Collections.Generic;

namespace restaurant3.Models;

public partial class DetailsCommande
{
    public int IdDetailCommande { get; set; }

    public int? IdCommande { get; set; }

    public int? IdPlat { get; set; }

    public int Quantite { get; set; }

    public decimal PrixUnitaire { get; set; }

    public decimal? Total { get; set; }

    public virtual Commande? IdCommandeNavigation { get; set; }

    public virtual Plat? IdPlatNavigation { get; set; }
}
