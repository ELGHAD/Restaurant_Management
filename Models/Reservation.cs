using System;
using System.Collections.Generic;

namespace restaurant3.Models;

public partial class Reservation
{
    public int IdReservation { get; set; }

    public int? IdClient { get; set; }

    public DateTime DateReservation { get; set; }

    public int NombrePersonnes { get; set; }

    public string TableReservee { get; set; } = null!;

    public string? Statut { get; set; }

    public virtual Utilisateur? IdClientNavigation { get; set; }
}
