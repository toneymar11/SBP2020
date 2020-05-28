using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineProdajaKnjiga.Models
{
    public partial class online_bookstoreContext : DbContext
    {
        public online_bookstoreContext()
        {
        }

        public online_bookstoreContext(DbContextOptions<online_bookstoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<IzdavackaKuca> IzdavackaKuca { get; set; }
        public virtual DbSet<Knjiga> Knjiga { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Mjesto> Mjesto { get; set; }
        public virtual DbSet<Narudzba> Narudzba { get; set; }
        public virtual DbSet<NarudzbaKnjiga> NarudzbaKnjiga { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=online_bookstore;Username=postgres;Password=Inot4321");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("autor_pkey");

                entity.ToTable("autor");

                entity.Property(e => e.IdAutor).HasColumnName("id_autor");

                entity.Property(e => e.Biografija).HasColumnName("biografija");

                entity.Property(e => e.BrojDijela).HasColumnName("broj_dijela");

                entity.Property(e => e.Ime)
                    .HasColumnName("ime")
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .HasColumnName("prezime")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<IzdavackaKuca>(entity =>
            {
                entity.HasKey(e => e.IdIzdavackaKuca)
                    .HasName("izdavacka_kuca_pkey");

                entity.ToTable("izdavacka_kuca");

                entity.Property(e => e.IdIzdavackaKuca).HasColumnName("id_izdavacka_kuca");

                entity.Property(e => e.FkMjesto)
                    .HasColumnName("fk_mjesto")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(50);

                entity.HasOne(d => d.FkMjestoNavigation)
                    .WithMany(p => p.IzdavackaKuca)
                    .HasForeignKey(d => d.FkMjesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mjesto");
            });

            modelBuilder.Entity<Knjiga>(entity =>
            {
                entity.HasKey(e => e.IdKnjiga)
                    .HasName("knjiga_pkey");

                entity.ToTable("knjiga");

                entity.Property(e => e.IdKnjiga).HasColumnName("id_knjiga");

                entity.Property(e => e.BrojStranica).HasColumnName("broj_stranica");

                entity.Property(e => e.Cijena).HasColumnName("cijena");

                entity.Property(e => e.DatumObjave)
                    .HasColumnName("datum_objave")
                    .HasColumnType("date");

                entity.Property(e => e.FkAutor)
                    .HasColumnName("fk_autor")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FkIzdavackaKuca)
                    .HasColumnName("fk_izdavacka_kuca")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(50);

                entity.HasOne(d => d.FkAutorNavigation)
                    .WithMany(p => p.Knjiga)
                    .HasForeignKey(d => d.FkAutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_autor");

                entity.HasOne(d => d.FkIzdavackaKucaNavigation)
                    .WithMany(p => p.Knjiga)
                    .HasForeignKey(d => d.FkIzdavackaKuca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_izdavacka_kuca");
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.HasKey(e => e.IdKorisnik)
                    .HasName("korisnik_pkey");

                entity.ToTable("korisnik");

                entity.Property(e => e.IdKorisnik).HasColumnName("id_korisnik");

                entity.Property(e => e.BrojMobitela).HasColumnName("broj_mobitela");

                entity.Property(e => e.FkMjesto)
                    .HasColumnName("fk_mjesto")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Ime)
                    .HasColumnName("ime")
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .HasColumnName("prezime")
                    .HasMaxLength(50);

                entity.HasOne(d => d.FkMjestoNavigation)
                    .WithMany(p => p.Korisnik)
                    .HasForeignKey(d => d.FkMjesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mjesto");
            });

            modelBuilder.Entity<Mjesto>(entity =>
            {
                entity.HasKey(e => e.IdMjesto)
                    .HasName("mjesto_pkey");

                entity.ToTable("mjesto");

                entity.Property(e => e.IdMjesto).HasColumnName("id_mjesto");

                entity.Property(e => e.Adresa)
                    .HasColumnName("adresa")
                    .HasMaxLength(50);

                entity.Property(e => e.Drzava)
                    .HasColumnName("drzava")
                    .HasMaxLength(50);

                entity.Property(e => e.Grad)
                    .HasColumnName("grad")
                    .HasMaxLength(50);

                entity.Property(e => e.PostanskiBroj).HasColumnName("postanski_broj");
            });

            modelBuilder.Entity<Narudzba>(entity =>
            {
                entity.HasKey(e => e.IdNarudzba)
                    .HasName("narudzba_pkey");

                entity.ToTable("narudzba");

                entity.Property(e => e.IdNarudzba).HasColumnName("id_narudzba");

                entity.Property(e => e.DatumNarudzbe)
                    .HasColumnName("datum_narudzbe")
                    .HasColumnType("date");

                entity.Property(e => e.Dostava).HasColumnName("dostava");

                entity.Property(e => e.FkKorisnk)
                    .HasColumnName("fk_korisnk")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UkupnaCijena).HasColumnName("ukupna_cijena");

                entity.HasOne(d => d.FkKorisnkNavigation)
                    .WithMany(p => p.Narudzba)
                    .HasForeignKey(d => d.FkKorisnk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_korisnik");
            });

            modelBuilder.Entity<NarudzbaKnjiga>(entity =>
            {
                entity.HasKey(e => e.IdNarudzbaKnjiga)
                    .HasName("narudzba_knjiga_pkey");

                entity.ToTable("narudzba_knjiga");

                entity.Property(e => e.IdNarudzbaKnjiga).HasColumnName("id_narudzba_knjiga");

                entity.Property(e => e.Cijena).HasColumnName("cijena");

                entity.Property(e => e.FkKnjiga)
                    .HasColumnName("fk_knjiga")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FkNarudzba)
                    .HasColumnName("fk_narudzba")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Kolicina).HasColumnName("kolicina");

                entity.HasOne(d => d.FkKnjigaNavigation)
                    .WithMany(p => p.NarudzbaKnjiga)
                    .HasForeignKey(d => d.FkKnjiga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_knjiga");

                entity.HasOne(d => d.FkNarudzbaNavigation)
                    .WithMany(p => p.NarudzbaKnjiga)
                    .HasForeignKey(d => d.FkNarudzba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_narudzba");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
