using System;
using System.Collections.Generic;

namespace restaurant3.Models;

public partial class Employe
{
    public int IdEmploye { get; set; }

    public string Poste { get; set; } = null!;

    public decimal Salaire { get; set; }

    public DateOnly DateEmbauche { get; set; }

    public string? Horaires { get; set; }

    public virtual Utilisateur IdEmployeNavigation { get; set; } = null!;
}
