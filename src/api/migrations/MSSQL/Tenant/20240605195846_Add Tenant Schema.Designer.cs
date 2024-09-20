﻿// <auto-generated />
using System;
using FSH.Framework.Infrastructure.Tenant.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TMC.WebApi.Migrations.MSSQL.Tenant
{
    [DbContext(typeof(TenantDbContext))]
    [Migration("20240605195846_Add Tenant Schema")]
    partial class AddTenantSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FSH.Framework.Infrastructure.Tenant.FshTenantInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("AdminEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConnectionString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Issuer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ValidUpto")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Identifier")
                        .IsUnique();

                    b.ToTable("Tenants", "tenant");
                });
#pragma warning restore 612, 618
        }
    }
}
