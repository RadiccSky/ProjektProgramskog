﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjektProgramskog.Model;

#nullable disable

namespace ProjektProgramskog.Migrations
{
    [DbContext(typeof(Pi05Context))]
    [Migration("20250213152205_AddCvijecarnaToVjencanje")]
    partial class AddCvijecarnaToVjencanje
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cvijećarna", b =>
                {
                    b.Property<int>("CvijećarnaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CvijećarnaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CvijećarnaId"));

                    b.Property<decimal?>("Cijena")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Detalji")
                        .HasColumnType("text");

                    b.Property<string>("Ime")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int")
                        .HasColumnName("PartnerID");

                    b.HasKey("CvijećarnaId")
                        .HasName("PK__Cvijećar__BFA8E7A21956F4E2");

                    b.HasIndex("PartnerId");

                    b.ToTable("Cvijećarna", (string)null);

                    b.HasData(
                        new
                        {
                            CvijećarnaId = 1,
                            Cijena = 500m,
                            Ime = "Cvjetna oaza",
                            PartnerId = 1
                        },
                        new
                        {
                            CvijećarnaId = 2,
                            Cijena = 650m,
                            Ime = "Cvijecarna Ana",
                            PartnerId = 2
                        },
                        new
                        {
                            CvijećarnaId = 3,
                            Cijena = 700m,
                            Ime = "Buket snova",
                            PartnerId = 3
                        });
                });

            modelBuilder.Entity("ProjektProgramskog.Model.CustomPartneri", b =>
                {
                    b.Property<int>("CustomPartnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CustomPartnerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomPartnerId"));

                    b.Property<decimal>("Cijena")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int")
                        .HasColumnName("PartnerID");

                    b.Property<string>("Usluga")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CustomPartnerId")
                        .HasName("PK__CustomPa__08D0F745D59419A7");

                    b.HasIndex("PartnerId");

                    b.ToTable("CustomPartneri", (string)null);
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Glazbenici", b =>
                {
                    b.Property<int>("GlazbenikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GlazbenikID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GlazbenikId"));

                    b.Property<decimal?>("CijenaPoSatu")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Ime")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal?>("OsnovnaCijena")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int")
                        .HasColumnName("PartnerID");

                    b.Property<string>("SlobodniDatumi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GlazbenikId")
                        .HasName("PK__Glazbeni__8ED4C2106614D353");

                    b.HasIndex("PartnerId");

                    b.ToTable("Glazbenici", (string)null);

                    b.HasData(
                        new
                        {
                            GlazbenikId = 1,
                            CijenaPoSatu = 200m,
                            Ime = "Guitar Masters",
                            OsnovnaCijena = 1000m,
                            PartnerId = 1,
                            SlobodniDatumi = "2024-01-01,2024-01-02"
                        },
                        new
                        {
                            GlazbenikId = 2,
                            CijenaPoSatu = 250m,
                            Ime = "Ajkula",
                            OsnovnaCijena = 1500m,
                            PartnerId = 2,
                            SlobodniDatumi = "2024-01-03,2024-01-04"
                        });
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Gosti", b =>
                {
                    b.Property<int>("GostiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GostiID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GostiId"));

                    b.Property<int>("BrojGostiju")
                        .HasColumnType("int")
                        .HasColumnName("BrojGostiju");

                    b.Property<int>("Idvjenčanja")
                        .HasColumnType("int")
                        .HasColumnName("IDVjenčanja");

                    b.HasKey("GostiId")
                        .HasName("PK__Gosti__6A3535C435292757");

                    b.HasIndex("Idvjenčanja");

                    b.ToTable("Gosti", (string)null);

                    b.HasData(
                        new
                        {
                            GostiId = 1,
                            BrojGostiju = 100,
                            Idvjenčanja = 1
                        });
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Hrana", b =>
                {
                    b.Property<int>("HranaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("HranaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HranaId"));

                    b.Property<decimal?>("CijenaPoOsobi")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Detalji")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int")
                        .HasColumnName("PartnerID");

                    b.Property<string>("TipHrane")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("HranaId")
                        .HasName("PK__Hrana__19AD0ACA0CA31B25");

                    b.HasIndex("PartnerId");

                    b.ToTable("Hrana", (string)null);

                    b.HasData(
                        new
                        {
                            HranaId = 1,
                            CijenaPoOsobi = 50.00m,
                            Naziv = "Teleći Medaljoni",
                            PartnerId = 1,
                            TipHrane = "Glavno jelo"
                        },
                        new
                        {
                            HranaId = 2,
                            CijenaPoOsobi = 40.00m,
                            Naziv = "Pečena janjetina s krumpirima",
                            PartnerId = 1,
                            TipHrane = "Glavno jelo"
                        },
                        new
                        {
                            HranaId = 3,
                            CijenaPoOsobi = 60.00m,
                            Naziv = "Pečena patka s mlincima",
                            PartnerId = 1,
                            TipHrane = "Glavno jelo"
                        },
                        new
                        {
                            HranaId = 4,
                            CijenaPoOsobi = 10.00m,
                            Naziv = "Cheesecake",
                            PartnerId = 1,
                            TipHrane = "Desert"
                        },
                        new
                        {
                            HranaId = 5,
                            CijenaPoOsobi = 11.00m,
                            Naziv = "Baklava",
                            PartnerId = 1,
                            TipHrane = "Desert"
                        },
                        new
                        {
                            HranaId = 6,
                            CijenaPoOsobi = 9.00m,
                            Naziv = "Čokoladni lava cake",
                            PartnerId = 1,
                            TipHrane = "Desert"
                        },
                        new
                        {
                            HranaId = 7,
                            CijenaPoOsobi = 20.00m,
                            Naziv = "Rolana puretina ili piletina punjena sirom i šunkom",
                            PartnerId = 1,
                            TipHrane = "Predjelo"
                        },
                        new
                        {
                            HranaId = 8,
                            CijenaPoOsobi = 15.00m,
                            Naziv = "Tart od sira i špinata",
                            PartnerId = 1,
                            TipHrane = "Predjelo"
                        },
                        new
                        {
                            HranaId = 9,
                            CijenaPoOsobi = 11.00m,
                            Naziv = "Juha",
                            PartnerId = 1,
                            TipHrane = "Predjelo"
                        });
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Izvještaj", b =>
                {
                    b.Property<int>("IzvještajId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IzvještajID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IzvještajId"));

                    b.Property<int>("Idvjenčanja")
                        .HasColumnType("int")
                        .HasColumnName("IDVjenčanja");

                    b.Property<string>("Sadržaj")
                        .HasColumnType("text");

                    b.Property<string>("TipIzvještaja")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IzvještajId")
                        .HasName("PK__Izvješta__DA1089BCFF48F48E");

                    b.HasIndex("Idvjenčanja");

                    b.ToTable("Izvještaj", (string)null);

                    b.HasData(
                        new
                        {
                            IzvještajId = 1,
                            Idvjenčanja = 1,
                            Sadržaj = "Izvještaj o statusu priprema za vjenčanje.",
                            TipIzvještaja = "Planiranje"
                        });
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Lokacija", b =>
                {
                    b.Property<int>("LokacijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LokacijaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LokacijaId"));

                    b.Property<decimal?>("CijenaPoDanu")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Ime")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int")
                        .HasColumnName("PartnerID");

                    b.HasKey("LokacijaId")
                        .HasName("PK__Lokacija__49DE2C2A95ACE938");

                    b.HasIndex("PartnerId");

                    b.ToTable("Lokacija", (string)null);

                    b.HasData(
                        new
                        {
                            LokacijaId = 1,
                            CijenaPoDanu = 1500.00m,
                            Ime = "Bijela Ruža",
                            PartnerId = 1
                        },
                        new
                        {
                            LokacijaId = 2,
                            CijenaPoDanu = 1500.00m,
                            Ime = "Vjenčana Oaza",
                            PartnerId = 1
                        },
                        new
                        {
                            LokacijaId = 3,
                            CijenaPoDanu = 1500.00m,
                            Ime = "Bajka",
                            PartnerId = 1
                        });
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Meni", b =>
                {
                    b.Property<int>("MeniId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MeniID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeniId"));

                    b.Property<int?>("BrojSljedova")
                        .HasColumnType("int");

                    b.Property<decimal?>("Cijena")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("CustomObrok")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HranaId")
                        .HasColumnType("int")
                        .HasColumnName("HranaID");

                    b.Property<string>("VrstaHrane")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MeniId")
                        .HasName("PK__Meni__EEA512D50B225059");

                    b.HasIndex("HranaId");

                    b.ToTable("Meni", (string)null);

                    b.HasData(
                        new
                        {
                            MeniId = 1,
                            Cijena = 50.00m,
                            HranaId = 1,
                            VrstaHrane = "Glavno jelo"
                        },
                        new
                        {
                            MeniId = 2,
                            Cijena = 30.00m,
                            HranaId = 2,
                            VrstaHrane = "Predjelo"
                        });
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Partneri", b =>
                {
                    b.Property<int>("PartnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PartnerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartnerId"));

                    b.Property<string>("BrojTelefona")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<bool?>("CustomPartneri")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("Hrana")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("ImePartnera")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Kategorija")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal?>("Provizija")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("PartnerId")
                        .HasName("PK__Partneri__39FD63327D5D2D52");

                    b.ToTable("Partneri", (string)null);

                    b.HasData(
                        new
                        {
                            PartnerId = 1,
                            BrojTelefona = "123-456-789",
                            Email = "info@floraldreams.com",
                            ImePartnera = "Cvjetna oaza",
                            Kategorija = "Cvijećarna",
                            Provizija = 0.10m
                        },
                        new
                        {
                            PartnerId = 6,
                            BrojTelefona = "063-111-222",
                            Email = "info@floraldreams.com",
                            ImePartnera = "Cvijecarna Ana",
                            Kategorija = "Cvijećarna",
                            Provizija = 0.10m
                        },
                        new
                        {
                            PartnerId = 5,
                            BrojTelefona = "063-111-333",
                            Email = "info@floraldreams.com",
                            ImePartnera = "Buket snova",
                            Kategorija = "Cvijećarna",
                            Provizija = 0.10m
                        },
                        new
                        {
                            PartnerId = 2,
                            BrojTelefona = "987-654-321",
                            Email = "contact@guitarmasters.com",
                            ImePartnera = "Guitar Masters",
                            Kategorija = "Glazba",
                            Provizija = 0.15m
                        },
                        new
                        {
                            PartnerId = 3,
                            BrojTelefona = "987-654-321",
                            Email = "contact@guitarmasters.com",
                            ImePartnera = "Ajkula",
                            Kategorija = "Glazba",
                            Provizija = 0.15m
                        },
                        new
                        {
                            PartnerId = 4,
                            BrojTelefona = "123-456-789",
                            Email = "bijelaruza",
                            ImePartnera = "Bijela Ruža",
                            Kategorija = "Lokacija",
                            Provizija = 0.20m
                        },
                        new
                        {
                            PartnerId = 8,
                            BrojTelefona = "123-456-789",
                            Email = "vjenčanaoaza",
                            ImePartnera = "Vjenčana Oaza",
                            Kategorija = "Lokacija"
                        },
                        new
                        {
                            PartnerId = 9,
                            BrojTelefona = "123-456-789",
                            Email = "bajka",
                            ImePartnera = "Bajka",
                            Kategorija = "Lokacija"
                        });
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Playlist", b =>
                {
                    b.Property<int>("PlaylistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PlaylistID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistId"));

                    b.Property<int?>("GlazbeniciGlazbenikId")
                        .HasColumnType("int");

                    b.Property<int>("GlazbenikId")
                        .HasColumnType("int")
                        .HasColumnName("GlazbenikID");

                    b.Property<string>("ListPjesama")
                        .HasColumnType("text");

                    b.HasKey("PlaylistId")
                        .HasName("PK__Playlist__B30167809234BB8F");

                    b.HasIndex("GlazbeniciGlazbenikId");

                    b.ToTable("Playlists");

                    b.HasData(
                        new
                        {
                            PlaylistId = 1,
                            GlazbenikId = 1,
                            ListPjesama = "Narodna"
                        },
                        new
                        {
                            PlaylistId = 2,
                            GlazbenikId = 1,
                            ListPjesama = "Folk"
                        },
                        new
                        {
                            PlaylistId = 3,
                            GlazbenikId = 1,
                            ListPjesama = "Pop"
                        },
                        new
                        {
                            PlaylistId = 4,
                            GlazbenikId = 2,
                            ListPjesama = "Narodna"
                        },
                        new
                        {
                            PlaylistId = 5,
                            GlazbenikId = 2,
                            ListPjesama = "Folk"
                        },
                        new
                        {
                            PlaylistId = 6,
                            GlazbenikId = 2,
                            ListPjesama = "Pop"
                        });
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Ponude", b =>
                {
                    b.Property<int>("PonudaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PonudaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PonudaId"));

                    b.Property<decimal?>("Cijena")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Detalji")
                        .HasColumnType("text");

                    b.Property<int>("Idvjenčanja")
                        .HasColumnType("int")
                        .HasColumnName("IDVjenčanja");

                    b.Property<string>("Ime")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("JeUnaprijedDefiniran")
                        .HasColumnType("bit");

                    b.Property<string>("JsonPodaci")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int")
                        .HasColumnName("PartnerID");

                    b.HasKey("PonudaId")
                        .HasName("PK__Ponude__5AF121B10DD24B45");

                    b.HasIndex("Idvjenčanja");

                    b.HasIndex("PartnerId");

                    b.ToTable("Ponude", (string)null);

                    b.HasData(
                        new
                        {
                            PonudaId = 1,
                            Cijena = 5000.00m,
                            Detalji = "Complete wedding package including venue, catering, and entertainment.",
                            Idvjenčanja = 1,
                            Ime = "Luxury Wedding Package",
                            JeUnaprijedDefiniran = false,
                            PartnerId = 1
                        },
                        new
                        {
                            PonudaId = 2,
                            Cijena = 3000.00m,
                            Detalji = "Wedding package including venue, catering, and entertainment.",
                            Idvjenčanja = 1,
                            Ime = "Medium Wedding Package",
                            JeUnaprijedDefiniran = false,
                            PartnerId = 1
                        });
                });

            modelBuilder.Entity("Vjenčanje", b =>
                {
                    b.Property<int>("Idvjenčanja")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDVjenčanja");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idvjenčanja"));

                    b.Property<string>("BrojKontakta")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int?>("CvijecarnaId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Datum")
                        .HasColumnType("date");

                    b.Property<int?>("DesertId")
                        .HasColumnType("int");

                    b.Property<int?>("GlavnoJeloId")
                        .HasColumnType("int");

                    b.Property<int?>("GlazbenikId")
                        .HasColumnType("int");

                    b.Property<string>("ImeKontakta")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("LokacijaId")
                        .HasColumnType("int");

                    b.Property<string>("Napomena")
                        .HasColumnType("text");

                    b.Property<int?>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<int?>("PredjeloId")
                        .HasColumnType("int");

                    b.Property<string>("Template")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Idvjenčanja")
                        .HasName("PK__Vjenčanj__A710B34E885FBD97");

                    b.HasIndex("CvijecarnaId");

                    b.HasIndex("DesertId");

                    b.HasIndex("GlavnoJeloId");

                    b.HasIndex("GlazbenikId");

                    b.HasIndex("LokacijaId");

                    b.HasIndex("PlaylistId");

                    b.HasIndex("PredjeloId");

                    b.ToTable("Vjenčanje", (string)null);

                    b.HasData(
                        new
                        {
                            Idvjenčanja = 1,
                            BrojKontakta = "123-123-123",
                            Datum = new DateOnly(1, 1, 1),
                            ImeKontakta = "Anna and Mark",
                            Napomena = "Wedding ceremony with special decorations",
                            Template = "Luxury"
                        });
                });

            modelBuilder.Entity("Cvijećarna", b =>
                {
                    b.HasOne("ProjektProgramskog.Model.Partneri", "Partner")
                        .WithMany("Cvijećarnas")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Cvijećarn__Partn__403A8C7D");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("ProjektProgramskog.Model.CustomPartneri", b =>
                {
                    b.HasOne("ProjektProgramskog.Model.Partneri", "Partner")
                        .WithMany("CustomPartneris")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CustomPartneri_Partneri");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Glazbenici", b =>
                {
                    b.HasOne("ProjektProgramskog.Model.Partneri", "Partner")
                        .WithMany("Glazbenicis")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Glazbenic__Partn__4316F928");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Gosti", b =>
                {
                    b.HasOne("Vjenčanje", "IdvjenčanjaNavigation")
                        .WithMany("Gostis")
                        .HasForeignKey("Idvjenčanja")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Gosti__IDVjenčan__00200768");

                    b.Navigation("IdvjenčanjaNavigation");
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Hrana", b =>
                {
                    b.HasOne("ProjektProgramskog.Model.Partneri", "Partner")
                        .WithMany("Hranas")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Hrana__PartnerID__4AB81AF0");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Izvještaj", b =>
                {
                    b.HasOne("Vjenčanje", "IdvjenčanjaNavigation")
                        .WithMany("Izvještajs")
                        .HasForeignKey("Idvjenčanja")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Izvještaj__IDVje__7C4F7684");

                    b.Navigation("IdvjenčanjaNavigation");
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Lokacija", b =>
                {
                    b.HasOne("ProjektProgramskog.Model.Partneri", "Partner")
                        .WithMany("Lokacijas")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Lokacija__Partne__5070F446");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Meni", b =>
                {
                    b.HasOne("ProjektProgramskog.Model.Hrana", "Hrana")
                        .WithMany("Menis")
                        .HasForeignKey("HranaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Meni__HranaID__534D60F1");

                    b.Navigation("Hrana");
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Playlist", b =>
                {
                    b.HasOne("ProjektProgramskog.Model.Glazbenici", null)
                        .WithMany("Playlists")
                        .HasForeignKey("GlazbeniciGlazbenikId");
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Ponude", b =>
                {
                    b.HasOne("Vjenčanje", "IdvjenčanjaNavigation")
                        .WithMany("Ponudes")
                        .HasForeignKey("Idvjenčanja")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Ponude__IDVjenča__787EE5A0");

                    b.HasOne("ProjektProgramskog.Model.Partneri", "Partner")
                        .WithMany("Ponudes")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Ponude__PartnerI__797309D9");

                    b.Navigation("IdvjenčanjaNavigation");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("Vjenčanje", b =>
                {
                    b.HasOne("Cvijećarna", "Cvijecarna")
                        .WithMany("Vjenčanjes")
                        .HasForeignKey("CvijecarnaId")
                        .HasConstraintName("FK__Vjenčanje__CvijecarnaId");

                    b.HasOne("ProjektProgramskog.Model.Hrana", "Desert")
                        .WithMany()
                        .HasForeignKey("DesertId");

                    b.HasOne("ProjektProgramskog.Model.Hrana", "GlavnoJelo")
                        .WithMany()
                        .HasForeignKey("GlavnoJeloId");

                    b.HasOne("ProjektProgramskog.Model.Glazbenici", "Glazbenik")
                        .WithMany("Vjenčanjes")
                        .HasForeignKey("GlazbenikId");

                    b.HasOne("ProjektProgramskog.Model.Lokacija", "Lokacija")
                        .WithMany("Vjenčanjes")
                        .HasForeignKey("LokacijaId")
                        .HasConstraintName("FK__Vjenčanje__LokacijaId");

                    b.HasOne("ProjektProgramskog.Model.Playlist", "Playlist")
                        .WithMany()
                        .HasForeignKey("PlaylistId");

                    b.HasOne("ProjektProgramskog.Model.Hrana", "Predjelo")
                        .WithMany()
                        .HasForeignKey("PredjeloId");

                    b.Navigation("Cvijecarna");

                    b.Navigation("Desert");

                    b.Navigation("GlavnoJelo");

                    b.Navigation("Glazbenik");

                    b.Navigation("Lokacija");

                    b.Navigation("Playlist");

                    b.Navigation("Predjelo");
                });

            modelBuilder.Entity("Cvijećarna", b =>
                {
                    b.Navigation("Vjenčanjes");
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Glazbenici", b =>
                {
                    b.Navigation("Playlists");

                    b.Navigation("Vjenčanjes");
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Hrana", b =>
                {
                    b.Navigation("Menis");
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Lokacija", b =>
                {
                    b.Navigation("Vjenčanjes");
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Partneri", b =>
                {
                    b.Navigation("CustomPartneris");

                    b.Navigation("Cvijećarnas");

                    b.Navigation("Glazbenicis");

                    b.Navigation("Hranas");

                    b.Navigation("Lokacijas");

                    b.Navigation("Ponudes");
                });

            modelBuilder.Entity("Vjenčanje", b =>
                {
                    b.Navigation("Gostis");

                    b.Navigation("Izvještajs");

                    b.Navigation("Ponudes");
                });
#pragma warning restore 612, 618
        }
    }
}
