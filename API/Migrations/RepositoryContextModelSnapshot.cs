﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("JournalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JournalId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            Description = "In this paper, by using properties of attractive points, we study an iteration scheme combining simplified Baillon type and Mann type to find a common fixed point of commutative two nonlinear mappings in Hilbert spaces. Then, we apply the obtained results to prove a new weak convergence theorem.",
                            JournalId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Name = "A Weak Convergence Theorem for Common Fixed Points of Two Nonlinear Mappings in Hilbert Spaces"
                        },
                        new
                        {
                            Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                            Description = "In this paper, we obtain some stability results of fixed point sets for a sequence of enriched contraction mappings in the setting of convex metric spaces. In particular, two types of convergence of mappings, namely, -convergence and -convergence are considered. We also illustrate our results by an application to an initial value problem for an ordinary differential equation.",
                            JournalId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Name = "Stability Results for Enriched Contraction Mappings in Convex Metric Spaces"
                        },
                        new
                        {
                            Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            Description = "This article addressed the causes and effects of soil compaction, operating parameters, and soil physicochemical properties in the Bishoftu long year tilled farmland of Ethiopia.",
                            JournalId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            Name = "Investigation of Soil Physiochemical Properties Effects on Soil Compaction for a Long Year Tilled Farmland"
                        });
                });

            modelBuilder.Entity("Entities.Models.Journal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Journals");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Description = "Abstract and Applied Analysis publishes research with an emphasis on important developments in classical analysis, linear and nonlinear functional analysis, ordinary and partial differential equations, optimisation theory, and control theory.",
                            Name = "Abstract and Applied Analysis"
                        },
                        new
                        {
                            Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            Description = "Applied and Environmental Soil Science publishes research in the field of soil science. Its focus reflects the multidisciplinary nature of soil science, especially the dynamics and spatial heterogeneity of processes in soil.",
                            Name = "Applied and Environmental Soil Science"
                        });
                });

            modelBuilder.Entity("Entities.Models.Article", b =>
                {
                    b.HasOne("Entities.Models.Journal", "Journal")
                        .WithMany("Articles")
                        .HasForeignKey("JournalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Journal");
                });

            modelBuilder.Entity("Entities.Models.Journal", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
