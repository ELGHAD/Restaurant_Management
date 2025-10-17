using System;
using System.Collections.Generic;

namespace restaurant3.Models;

public partial class Plat
{
    public int IdPlat { get; set; }

    public string NomPlat { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Prix { get; set; }

    public bool? Disponible { get; set; }

    public virtual ICollection<DetailsCommande> DetailsCommandes { get; set; } = new List<DetailsCommande>();

    public virtual ICollection<PlatsIngredient> PlatsIngredients { get; set; } = new List<PlatsIngredient>();
}
