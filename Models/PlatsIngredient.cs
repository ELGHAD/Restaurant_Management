using System;
using System.Collections.Generic;

namespace restaurant3.Models;

public partial class PlatsIngredient
{
    public int IdPlat { get; set; }

    public int IdIngredient { get; set; }

    public decimal QuantiteNecessaire { get; set; }

    public string Unite { get; set; } = null!;

    public virtual Ingredient IdIngredientNavigation { get; set; } = null!;

    public virtual Plat IdPlatNavigation { get; set; } = null!;
}
