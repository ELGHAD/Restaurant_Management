using System;
using System.Collections.Generic;

namespace restaurant3.Models;

public partial class Ingredient
{
    public int IdIngredient { get; set; }

    public string NomIngredient { get; set; } = null!;

    public int QuantiteStock { get; set; }

    public string Unite { get; set; } = null!;

    public virtual ICollection<PlatsIngredient> PlatsIngredients { get; set; } = new List<PlatsIngredient>();
}
