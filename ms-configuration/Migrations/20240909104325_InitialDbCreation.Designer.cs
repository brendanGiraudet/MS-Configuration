﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ms_configuration.Data;

#nullable disable

namespace ms_configuration.Migrations
{
    [DbContext(typeof(ConfigurationDatabaseContext))]
    [Migration("20240909104325_InitialDbCreation")]
    partial class InitialDbCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("ms_configuration.Models.RabbitMqConfigModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Hostname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Port")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RabbitMqConfigs");
                });

            modelBuilder.Entity("ms_configuration.Models.RabbitMqExchangeModel", b =>
                {
                    b.Property<string>("Exchange")
                        .HasColumnType("TEXT");

                    b.Property<string>("Queue")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RabbitMqConfigModelId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoutingKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Exchange", "Queue");

                    b.HasIndex("RabbitMqConfigModelId");

                    b.ToTable("RabbitMqExchange");
                });

            modelBuilder.Entity("ms_configuration.Models.RabbitMqExchangeModel", b =>
                {
                    b.HasOne("ms_configuration.Models.RabbitMqConfigModel", "RabbitMqConfigModel")
                        .WithMany("RabbitMqExchanges")
                        .HasForeignKey("RabbitMqConfigModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RabbitMqConfigModel");
                });

            modelBuilder.Entity("ms_configuration.Models.RabbitMqConfigModel", b =>
                {
                    b.Navigation("RabbitMqExchanges");
                });
#pragma warning restore 612, 618
        }
    }
}
