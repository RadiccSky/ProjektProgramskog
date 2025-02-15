using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjektProgramskog.Model;

public partial class Pi05Context : DbContext
{
    public Pi05Context()
    {
    }

    public Pi05Context(DbContextOptions<Pi05Context> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomPartneri> CustomPartneris { get; set; }

    public virtual DbSet<Cvijećarna> Cvijećarnas { get; set; }

    public virtual DbSet<Glazbenici> Glazbenicis { get; set; }

    public virtual DbSet<Gosti> Gostis { get; set; }

    public virtual DbSet<Hrana> Hranas { get; set; }

    public virtual DbSet<Izvještaj> Izvještajs { get; set; }

    public virtual DbSet<Lokacija> Lokacijas { get; set; }

    public virtual DbSet<Meni> Menis { get; set; }

    public virtual DbSet<Partneri> Partneris { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }

    public virtual DbSet<Ponude> Ponudes { get; set; }

    public virtual DbSet<Vjenčanje> Vjenčanjes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=dosa.fer.hr,3000;Database=PI-05;User Id=PI05;Password=rover.4n-2;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<CustomPartneri>(entity =>
        {
            entity.HasKey(e => e.CustomPartnerId).HasName("PK__CustomPa__08D0F745D59419A7");

            entity.ToTable("CustomPartneri");

            entity.Property(e => e.CustomPartnerId).HasColumnName("CustomPartnerID");
            entity.Property(e => e.Cijena).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Ime).HasMaxLength(100);
            entity.Property(e => e.PartnerId).HasColumnName("PartnerID");
            entity.Property(e => e.Usluga).HasMaxLength(255);

            entity.HasOne(d => d.Partner).WithMany(p => p.CustomPartneris)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("FK_CustomPartneri_Partneri");
        });

        modelBuilder.Entity<Cvijećarna>(entity =>
        {
            entity.HasKey(e => e.CvijecarnaId).HasName("PK__Cvijećar__BFA8E7A21956F4E2");

            entity.ToTable("Cvijećarna");

            entity.Property(e => e.CvijecarnaId).HasColumnName("CvijećarnaID");
            entity.Property(e => e.Cijena).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Detalji).HasColumnType("text");
            entity.Property(e => e.Ime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PartnerId).HasColumnName("PartnerID");

            entity.HasOne(d => d.Partner).WithMany(p => p.Cvijećarnas)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("FK__Cvijećarn__Partn__403A8C7D");


        });

        modelBuilder.Entity<Glazbenici>(entity =>
        {
            entity.HasKey(e => e.GlazbenikId).HasName("PK__Glazbeni__8ED4C2106614D353");

            entity.ToTable("Glazbenici");

            entity.Property(e => e.GlazbenikId).HasColumnName("GlazbenikID");
            entity.Property(e => e.CijenaPoSatu).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Ime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OsnovnaCijena).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PartnerId).HasColumnName("PartnerID");

            entity.HasOne(d => d.Partner).WithMany(p => p.Glazbenicis)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("FK__Glazbenic__Partn__4316F928");
        });

        modelBuilder.Entity<Gosti>(entity =>
        {
            entity.HasKey(e => e.GostiId).HasName("PK__Gosti__6A3535C435292757");

            entity.ToTable("Gosti");

            entity.Property(e => e.GostiId).HasColumnName("GostiID");
            entity.Property(e => e.Idvjenčanja).HasColumnName("IDVjenčanja");
            entity.Property(e => e.BrojGostiju).HasColumnName("BrojGostiju");

            entity.HasOne(d => d.IdvjenčanjaNavigation).WithMany(p => p.Gostis)
                .HasForeignKey(d => d.Idvjenčanja)
                .HasConstraintName("FK__Gosti__IDVjenčan__00200768");
        });


        modelBuilder.Entity<Hrana>(entity =>
        {
            entity.HasKey(e => e.HranaId).HasName("PK__Hrana__19AD0ACA0CA31B25");

            entity.ToTable("Hrana");

            entity.Property(e => e.HranaId).HasColumnName("HranaID");
            entity.Property(e => e.CijenaPoOsobi).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Naziv).HasMaxLength(100);
            entity.Property(e => e.PartnerId).HasColumnName("PartnerID");
            entity.Property(e => e.TipHrane).HasMaxLength(50);

            entity.HasOne(d => d.Partner).WithMany(p => p.Hranas)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("FK__Hrana__PartnerID__4AB81AF0");
        });

        modelBuilder.Entity<Izvještaj>(entity =>
        {
            entity.HasKey(e => e.IzvještajId).HasName("PK__Izvješta__DA1089BCFF48F48E");

            entity.ToTable("Izvještaj");

            entity.Property(e => e.IzvještajId).HasColumnName("IzvještajID");
            entity.Property(e => e.Idvjenčanja).HasColumnName("IDVjenčanja");
            entity.Property(e => e.Sadržaj).HasColumnType("text");
            entity.Property(e => e.TipIzvještaja)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdvjenčanjaNavigation).WithMany(p => p.Izvještajs)
                .HasForeignKey(d => d.Idvjenčanja)
                .HasConstraintName("FK__Izvještaj__IDVje__7C4F7684");
        });

        modelBuilder.Entity<Lokacija>(entity =>
        {
            entity.HasKey(e => e.LokacijaId).HasName("PK__Lokacija__49DE2C2A95ACE938");

            entity.ToTable("Lokacija");

            entity.Property(e => e.LokacijaId).HasColumnName("LokacijaID");
            entity.Property(e => e.CijenaPoDanu).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Ime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PartnerId).HasColumnName("PartnerID");

            entity.HasOne(d => d.Partner)
                .WithMany(p => p.Lokacijas)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("FK__Lokacija__Partne__5070F446");
        });

        modelBuilder.Entity<Meni>(entity =>
        {
            entity.HasKey(e => e.MeniId).HasName("PK__Meni__EEA512D50B225059");

            entity.ToTable("Meni");

            entity.Property(e => e.MeniId).HasColumnName("MeniID");
            entity.Property(e => e.Cijena).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.HranaId).HasColumnName("HranaID");
            entity.Property(e => e.VrstaHrane).HasMaxLength(100);

            entity.HasOne(d => d.Hrana).WithMany(p => p.Menis)
                .HasForeignKey(d => d.HranaId)
                .HasConstraintName("FK__Meni__HranaID__534D60F1");
        });

        modelBuilder.Entity<Partneri>(entity =>
        {
            entity.HasKey(e => e.PartnerId).HasName("PK__Partneri__39FD63327D5D2D52");

            entity.ToTable("Partneri");

            entity.Property(e => e.PartnerId).HasColumnName("PartnerID");
            entity.Property(e => e.BrojTelefona)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CustomPartneri).HasDefaultValue(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Hrana).HasDefaultValue(false);
            entity.Property(e => e.ImePartnera)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Kategorija)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Provizija).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.HasKey(e => e.PlaylistId).HasName("PK__Playlist__B30167809234BB8F");

            entity.Property(e => e.PlaylistId).HasColumnName("PlaylistID");
            entity.Property(e => e.GlazbenikId).HasColumnName("GlazbenikID");
            entity.Property(e => e.ListPjesama).HasColumnType("text");

           // entity.HasOne(d => d.Glazbenik).WithMany(p => p.Playlists)
            //    .HasForeignKey(d => d.GlazbenikId)
              //  .HasConstraintName("FK__Playlists__Glazb__5629CD9C");
        });

        modelBuilder.Entity<Ponude>(entity =>
        {
            entity.HasKey(e => e.PonudaId).HasName("PK__Ponude__5AF121B10DD24B45");

            entity.ToTable("Ponude");

            entity.Property(e => e.PonudaId).HasColumnName("PonudaID");
            entity.Property(e => e.Cijena).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Detalji).HasColumnType("text");
            entity.Property(e => e.Idvjenčanja).HasColumnName("IDVjenčanja");
            entity.Property(e => e.Ime)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PartnerId).HasColumnName("PartnerID");

            entity.HasOne(d => d.IdvjenčanjaNavigation).WithMany(p => p.Ponudes)
                .HasForeignKey(d => d.Idvjenčanja)
                .HasConstraintName("FK__Ponude__IDVjenča__787EE5A0");

            entity.HasOne(d => d.Partner).WithMany(p => p.Ponudes)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("FK__Ponude__PartnerI__797309D9");
        });

        modelBuilder.Entity<Vjenčanje>(entity =>
        {
            entity.HasKey(e => e.Idvjenčanja).HasName("PK__Vjenčanj__A710B34E885FBD97");

            entity.ToTable("Vjenčanje");

            entity.Property(e => e.Idvjenčanja).HasColumnName("IDVjenčanja");
            entity.Property(e => e.BrojKontakta)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ImeKontakta)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Napomena).HasColumnType("text");
            entity.Property(e => e.Template)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Lokacija)
                .WithMany(p => p.Vjenčanjes)
                .HasForeignKey(d => d.LokacijaId)
                .HasConstraintName("FK__Vjenčanje__LokacijaId");

            entity.HasOne(d => d.Cvijecarna)
      .WithMany(p => p.Vjenčanjes)
      .HasForeignKey(d => d.CvijecarnaId)
      .HasConstraintName("FK__Vjenčanje__CvijecarnaId");
        });

        modelBuilder.Entity<Partneri>().HasData(
        new Partneri
        {
            PartnerId = 1,
            ImePartnera = "Cvjetna oaza",
            Email = "info@floraldreams.com",
            BrojTelefona = "123-456-789",
            Kategorija = "Cvijećarna",
            Provizija = 0.10m
        },
         new Partneri
         {
             PartnerId = 6,
             ImePartnera = "Cvijecarna Ana",
             Email = "info@floraldreams.com",
             BrojTelefona = "063-111-222",
             Kategorija = "Cvijećarna",
             Provizija = 0.10m
         },
           new Partneri
           {
               PartnerId = 5,
               ImePartnera = "Buket snova",
               Email = "info@floraldreams.com",
               BrojTelefona = "063-111-333",
               Kategorija = "Cvijećarna",
               Provizija = 0.10m
           },
        new Partneri
        {
            PartnerId = 2,
            ImePartnera = "Guitar Masters",
            Email = "contact@guitarmasters.com",
            BrojTelefona = "987-654-321",
            Kategorija = "Glazba",
            Provizija = 0.15m
        },

         new Partneri
         {
             PartnerId = 3,
             ImePartnera = "Ajkula",
             Email = "contact@guitarmasters.com",
             BrojTelefona = "987-654-321",
             Kategorija = "Glazba",
             Provizija = 0.15m
         },

      

         new Partneri
         {
             PartnerId = 4,
             ImePartnera = "Bijela Ruža",
             Email = "bijelaruza",
             BrojTelefona = "123-456-789",
             Kategorija = "Lokacija",
             Provizija = 0.20m

         }, 

         new Partneri
         {
             PartnerId = 8,
             ImePartnera = "Vjenčana Oaza",
             Email = "vjenčanaoaza",
             BrojTelefona = "123-456-789",
             Kategorija = "Lokacija",

         },
         new Partneri
         {
             PartnerId = 9,
             ImePartnera = "Bajka",
             Email = "bajka",
             BrojTelefona = "123-456-789",
             Kategorija = "Lokacija",

         }


    );

        modelBuilder.Entity<Cvijećarna>().HasData(
            new Cvijećarna
            {
                CvijecarnaId = 1,
                Ime = "Cvjetna oaza",
                Cijena = 500,
                PartnerId = 1
            },
            new Cvijećarna
            {
                CvijecarnaId = 2,
                Ime = "Cvijecarna Ana",
                Cijena = 650,
                PartnerId = 2
            },
            new Cvijećarna
            {
                CvijecarnaId = 3,
                Ime = "Buket snova",
                Cijena = 700,
                PartnerId = 3
            }
        );

        modelBuilder.Entity<Glazbenici>().HasData(
             new Glazbenici
             {
                 GlazbenikId = 1,
                 PartnerId = 1,
                 Ime = "Guitar Masters",
                 OsnovnaCijena = 1000m,
                 CijenaPoSatu = 200m,
                 SlobodniDatumi = "2024-01-01,2024-01-02"
             },
             new Glazbenici
             {
                 GlazbenikId = 2,
                 PartnerId = 2,
                 Ime = "Ajkula",
                 OsnovnaCijena = 1500m,
                 CijenaPoSatu = 250m,
                 SlobodniDatumi = "2024-01-03,2024-01-04"
             }
         );

        modelBuilder.Entity<Gosti>().HasData(
            new Gosti
            {
                GostiId = 1,
                Idvjenčanja = 1,
                BrojGostiju = 100,

            }
        );

        modelBuilder.Entity<Hrana>().HasData(
            new Hrana
            {
                HranaId = 1,
                Naziv = "Teleći Medaljoni",
                CijenaPoOsobi = 50.00m,
                TipHrane = "Glavno jelo",
                PartnerId = 1
            },
            new Hrana
            {
                HranaId = 2,
                Naziv = "Pečena janjetina s krumpirima",
                CijenaPoOsobi = 40.00m,
                TipHrane = "Glavno jelo",
                PartnerId = 1
            },
            new Hrana
            {
                HranaId = 3,
                Naziv = "Pečena patka s mlincima",
                CijenaPoOsobi = 60.00m,
                TipHrane = "Glavno jelo",
                PartnerId = 1
            },
            new Hrana
            {
                HranaId = 4,
                Naziv = "Cheesecake",
                CijenaPoOsobi = 10.00m,
                TipHrane = "Desert",
                PartnerId = 1
            },
            new Hrana
            {
                HranaId = 5,
                Naziv = "Baklava",
                CijenaPoOsobi = 11.00m,
                TipHrane = "Desert",
                PartnerId = 1
            },
            new Hrana
            {
                HranaId = 6,
                Naziv = "Čokoladni lava cake",
                CijenaPoOsobi = 9.00m,
                TipHrane = "Desert",
                PartnerId = 1
            },
            new Hrana
            {
                HranaId = 7,
                Naziv = "Rolana puretina ili piletina punjena sirom i šunkom",
                CijenaPoOsobi = 20.00m,
                TipHrane = "Predjelo",
                PartnerId = 1
            },
            new Hrana
            {
                HranaId = 8,
                Naziv = "Tart od sira i špinata",
                CijenaPoOsobi = 15.00m,
                TipHrane = "Predjelo",
                PartnerId = 1
            },
            new Hrana
            {
                HranaId = 9,
                Naziv = "Juha",
                CijenaPoOsobi = 11.00m,
                TipHrane = "Predjelo",
                PartnerId = 1
            }

        );

        modelBuilder.Entity<Izvještaj>().HasData(
            new Izvještaj
            {
                IzvještajId = 1,
                Idvjenčanja = 1,
                Sadržaj = "Izvještaj o statusu priprema za vjenčanje.",
                TipIzvještaja = "Planiranje"
            }
        );

        modelBuilder.Entity<Lokacija>().HasData(
            new Lokacija
            {
                LokacijaId = 1,
                Ime = "Bijela Ruža",
                CijenaPoDanu = 1500.00m,
                PartnerId = 1,
            },
            new Lokacija
            {

                LokacijaId = 2,
                Ime = "Vjenčana Oaza",
                CijenaPoDanu = 1500.00m,
                PartnerId = 1,
            },

            new Lokacija
            {
                LokacijaId = 3,
                Ime = "Bajka",
                CijenaPoDanu = 1500.00m,
                PartnerId = 1,
            }
        );

        modelBuilder.Entity<Meni>().HasData(
            new Meni
            {
                MeniId = 1,
                HranaId = 1,
                VrstaHrane = "Glavno jelo",
                Cijena = 50.00m
            },
            new Meni
            {
                MeniId = 2,
                HranaId = 2,
                VrstaHrane = "Predjelo",
                Cijena = 30.00m
            }
        );

        modelBuilder.Entity<Playlist>().HasData(
            new Playlist
            {
                PlaylistId = 1,
                GlazbenikId = 1,
                ListPjesama = "Narodna"
            },

             new Playlist
             {
                 PlaylistId = 2,
                 GlazbenikId = 1,
                 ListPjesama = "Folk"
             },
              new Playlist
              {
                  PlaylistId = 3,
                  GlazbenikId = 1,
                  ListPjesama = "Pop"
              },
              new Playlist
              {
                  PlaylistId = 4,
                  GlazbenikId = 2,
                  ListPjesama = "Narodna"
              },

             new Playlist
             {
                 PlaylistId = 5,
                 GlazbenikId = 2,
                 ListPjesama = "Folk"
             },
              new Playlist
              {
                  PlaylistId = 6,
                  GlazbenikId = 2,
                  ListPjesama = "Pop"
              }

        );

        modelBuilder.Entity<Ponude>().HasData(
            new Ponude
            {
                PonudaId = 1,
                Ime = "Luxury Wedding Package",
                Cijena = 5000.00m,
                Detalji = "Complete wedding package including venue, catering, and entertainment.",
                Idvjenčanja = 1,
                PartnerId = 1
            }
        );

        modelBuilder.Entity<Ponude>().HasData(
            new Ponude
            {
                PonudaId = 2,
                Ime = "Medium Wedding Package",
                Cijena = 3000.00m,
                Detalji = "Wedding package including venue, catering, and entertainment.",
                Idvjenčanja = 1,
                PartnerId = 1
            }
        );

        modelBuilder.Entity<Vjenčanje>().HasData(
            new Vjenčanje
            {
                Idvjenčanja = 1,
                ImeKontakta = "Anna and Mark",
                BrojKontakta = "123-123-123",
                Napomena = "Wedding ceremony with special decorations",
                Template = "Luxury"
            }
        );

        OnModelCreatingPartial(modelBuilder); }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


}
