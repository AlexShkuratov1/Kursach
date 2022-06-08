﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Data;

namespace Shop.Migrations
{
    [DbContext(typeof(AppDBContent))]
    [Migration("20211018090736_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shop.Data.Models.Camera", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("available");

                    b.Property<int>("categoryID");

                    b.Property<string>("img");

                    b.Property<bool>("isFavourite");

                    b.Property<string>("longDesc");

                    b.Property<string>("name");

                    b.Property<int>("price");

                    b.Property<string>("shortDesc");

                    b.HasKey("id");

                    b.HasIndex("categoryID");

                    b.ToTable("Camera");
                });

            modelBuilder.Entity("Shop.Data.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("categoryName");

                    b.Property<string>("desc");

                    b.HasKey("id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Shop.Data.Models.ShopCartItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ShopCartId");

                    b.Property<int?>("cameraid");

                    b.Property<int>("price");

                    b.HasKey("id");

                    b.HasIndex("cameraid");

                    b.ToTable("ShopCartItem");
                });

            modelBuilder.Entity("Shop.Data.Models.Camera", b =>
                {
                    b.HasOne("Shop.Data.Models.Category", "Category")
                        .WithMany("cameras")
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shop.Data.Models.ShopCartItem", b =>
                {
                    b.HasOne("Shop.Data.Models.Camera", "camera")
                        .WithMany()
                        .HasForeignKey("cameraid");
                });
#pragma warning restore 612, 618
        }
    }
}
