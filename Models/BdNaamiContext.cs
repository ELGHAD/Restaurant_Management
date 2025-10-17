using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace restaurant3.Models;

public partial class BdNaamiContext : DbContext
{
    public BdNaamiContext()
    {
    }

    public BdNaamiContext(DbContextOptions<BdNaamiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Commande> Commandes { get; set; }

    public virtual DbSet<DetailsCommande> DetailsCommandes { get; set; }

    public virtual DbSet<Employe> Employes { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Plat> Plats { get; set; }

    public virtual DbSet<PlatsIngredient> PlatsIngredients { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    public virtual DbSet<Vente> Ventes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ZNAAMI; Database=bd_naami;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Commande>(entity =>
        {
            entity.HasKey(e => e.IdCommande).HasName("PK__Commande__6828586C5C34886B");

            entity.Property(e => e.DateCommande)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Statut)
                .HasMaxLength(50)
                .HasDefaultValue("En cours");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TypeCommande).HasMaxLength(50);

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Commandes)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("FK__Commandes__IdCli__4316F928");
        });

        modelBuilder.Entity<DetailsCommande>(entity =>
        {
            entity.HasKey(e => e.IdDetailCommande).HasName("PK__DetailsC__69D14E49673740B0");

            entity.Property(e => e.PrixUnitaire).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Total)
                .HasComputedColumnSql("([Quantite]*[PrixUnitaire])", true)
                .HasColumnType("decimal(21, 2)");

            entity.HasOne(d => d.IdCommandeNavigation).WithMany(p => p.DetailsCommandes)
                .HasForeignKey(d => d.IdCommande)
                .HasConstraintName("FK__DetailsCo__IdCom__4E88ABD4");

            entity.HasOne(d => d.IdPlatNavigation).WithMany(p => p.DetailsCommandes)
                .HasForeignKey(d => d.IdPlat)
                .HasConstraintName("FK__DetailsCo__IdPla__4F7CD00D");
        });

        modelBuilder.Entity<Employe>(entity =>
        {
            entity.HasKey(e => e.IdEmploye).HasName("PK__Employes__2ED32064ECA072A8");

            entity.Property(e => e.IdEmploye).ValueGeneratedNever();
            entity.Property(e => e.Horaires).HasMaxLength(255);
            entity.Property(e => e.Poste).HasMaxLength(100);
            entity.Property(e => e.Salaire).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdEmployeNavigation).WithOne(p => p.Employe)
                .HasForeignKey<Employe>(d => d.IdEmploye)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employes__IdEmpl__3C69FB99");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.IdIngredient).HasName("PK__Ingredie__01037EDC01375491");

            entity.Property(e => e.NomIngredient).HasMaxLength(150);
            entity.Property(e => e.Unite).HasMaxLength(50);
        });

        modelBuilder.Entity<Plat>(entity =>
        {
            entity.HasKey(e => e.IdPlat).HasName("PK__Plats__FB810294668931F3");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Disponible).HasDefaultValue(true);
            entity.Property(e => e.NomPlat).HasMaxLength(150);
            entity.Property(e => e.Prix).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<PlatsIngredient>(entity =>
        {
            entity.HasKey(e => new { e.IdPlat, e.IdIngredient }).HasName("PK__PlatsIng__2B913579456628D1");

            entity.Property(e => e.QuantiteNecessaire).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Unite).HasMaxLength(50);

            entity.HasOne(d => d.IdIngredientNavigation).WithMany(p => p.PlatsIngredients)
                .HasForeignKey(d => d.IdIngredient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlatsIngr__IdIng__5535A963");

            entity.HasOne(d => d.IdPlatNavigation).WithMany(p => p.PlatsIngredients)
                .HasForeignKey(d => d.IdPlat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlatsIngr__IdPla__5441852A");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.IdReservation).HasName("PK__Reservat__7E69A57B68248365");

            entity.Property(e => e.DateReservation).HasColumnType("datetime");
            entity.Property(e => e.Statut)
                .HasMaxLength(50)
                .HasDefaultValue("En attente");
            entity.Property(e => e.TableReservee).HasMaxLength(50);

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("FK__Reservati__IdCli__3F466844");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.IdUtilisateur).HasName("PK__Utilisat__45A4C157B2230A6C");

            entity.HasIndex(e => e.Email, "UQ__Utilisat__A9D1053410CA2907").IsUnique();

            entity.Property(e => e.Adresse).HasMaxLength(255);
            entity.Property(e => e.DateInscription)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.MotDePasse).HasMaxLength(255);
            entity.Property(e => e.Nom).HasMaxLength(100);
            entity.Property(e => e.Prenom).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Telephone).HasMaxLength(15);
        });

        modelBuilder.Entity<Vente>(entity =>
        {
            entity.HasKey(e => e.IdVente).HasName("PK__Ventes__BC1240B16F9C9CAA");

            entity.Property(e => e.DateVente)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MontantFinal)
                .HasComputedColumnSql("([MontantTotal]-[Remise])", true)
                .HasColumnType("decimal(11, 2)");
            entity.Property(e => e.MontantTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Remise)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCommandeNavigation).WithMany(p => p.Ventes)
                .HasForeignKey(d => d.IdCommande)
                .HasConstraintName("FK__Ventes__IdComman__5812160E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
