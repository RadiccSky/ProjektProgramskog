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
    [Migration("20241211120738_AddTemplateFieldsToPonude")]
    partial class AddTemplateFieldsToPonude
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

            modelBuilder.Entity("ProjektProgramskog.Model.Cvijećarna", b =>
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
                            Ime = "Floral Dreams",
                            PartnerId = 1
                        });
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
                            Ime = "The Melody Band",
                            OsnovnaCijena = 1000m,
                            PartnerId = 2
                        });
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Gosti", b =>
                {
                    b.Property<int>("GostiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GostiID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GostiId"));

                    b.Property<int?>("BrojStola")
                        .HasColumnType("int");

                    b.Property<int>("Idvjenčanja")
                        .HasColumnType("int")
                        .HasColumnName("IDVjenčanja");

                    b.Property<string>("Ime")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("StatusGosta")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("Potvrdili dolazak");

                    b.HasKey("GostiId")
                        .HasName("PK__Gosti__6A3535C435292757");

                    b.HasIndex("Idvjenčanja");

                    b.ToTable("Gosti", (string)null);

                    b.HasData(
                        new
                        {
                            GostiId = 1,
                            Idvjenčanja = 1,
                            Ime = "John Doe",
                            StatusGosta = "Potvrdili dolazak"
                        },
                        new
                        {
                            GostiId = 2,
                            Idvjenčanja = 1,
                            Ime = "Jane Smith",
                            StatusGosta = "Potvrdili dolazak"
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
                            Naziv = "Roast Beef",
                            PartnerId = 1,
                            TipHrane = "Glavno jelo"
                        },
                        new
                        {
                            HranaId = 2,
                            CijenaPoOsobi = 30.00m,
                            Naziv = "Chicken Salad",
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

                    b.Property<bool?>("Catering")
                        .HasColumnType("bit");

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
                            Ime = "Beach Resort",
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
                            ImePartnera = "Floral Dreams",
                            Kategorija = "Cvjećarna",
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
                        });
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Playlist", b =>
                {
                    b.Property<int>("PlaylistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PlaylistID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistId"));

                    b.Property<int>("GlazbenikId")
                        .HasColumnType("int")
                        .HasColumnName("GlazbenikID");

                    b.Property<string>("ListPjesama")
                        .HasColumnType("text");

                    b.HasKey("PlaylistId")
                        .HasName("PK__Playlist__B30167809234BB8F");

                    b.HasIndex("GlazbenikId");

                    b.ToTable("Playlists");

                    b.HasData(
                        new
                        {
                            PlaylistId = 1,
                            GlazbenikId = 1,
                            ListPjesama = "Song 1, Song 2, Song 3"
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

            modelBuilder.Entity("ProjektProgramskog.Model.Vjenčanje", b =>
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

                    b.Property<DateOnly>("Datum")
                        .HasColumnType("date");

                    b.Property<string>("ImeKontakta")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Napomena")
                        .HasColumnType("text");

                    b.Property<string>("Template")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Idvjenčanja")
                        .HasName("PK__Vjenčanj__A710B34E885FBD97");

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

            modelBuilder.Entity("ProjektProgramskog.Model.Cvijećarna", b =>
                {
                    b.HasOne("ProjektProgramskog.Model.Partneri", "Partner")
                        .WithMany("Cvijećarnas")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Cvijećarn__Partn__403A8C7D");

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
                    b.HasOne("ProjektProgramskog.Model.Vjenčanje", "IdvjenčanjaNavigation")
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
                    b.HasOne("ProjektProgramskog.Model.Vjenčanje", "IdvjenčanjaNavigation")
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
                    b.HasOne("ProjektProgramskog.Model.Glazbenici", "Glazbenik")
                        .WithMany("Playlists")
                        .HasForeignKey("GlazbenikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Playlists__Glazb__5629CD9C");

                    b.Navigation("Glazbenik");
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Ponude", b =>
                {
                    b.HasOne("ProjektProgramskog.Model.Vjenčanje", "IdvjenčanjaNavigation")
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

            modelBuilder.Entity("ProjektProgramskog.Model.Glazbenici", b =>
                {
                    b.Navigation("Playlists");
                });

            modelBuilder.Entity("ProjektProgramskog.Model.Hrana", b =>
                {
                    b.Navigation("Menis");
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

            modelBuilder.Entity("ProjektProgramskog.Model.Vjenčanje", b =>
                {
                    b.Navigation("Gostis");

                    b.Navigation("Izvještajs");

                    b.Navigation("Ponudes");
                });
#pragma warning restore 612, 618
        }
    }
}