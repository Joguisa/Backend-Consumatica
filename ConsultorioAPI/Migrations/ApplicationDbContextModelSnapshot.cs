﻿// <auto-generated />
using System;
using ConsultorioAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsultorioAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConsultorioAPI.Entidades.AsignacionTipoEmpleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<int>("TipoEmpleadoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("TipoEmpleadoId");

                    b.ToTable("AsignarEmpleado");
                });

            modelBuilder.Entity("ConsultorioAPI.Entidades.AsignacionTipoServicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<int>("ServicioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("ServicioId");

                    b.ToTable("AsignarServicio");
                });

            modelBuilder.Entity("ConsultorioAPI.Entidades.AsignarTurno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AsignacionTipoServicioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HoraConsulta")
                        .HasColumnType("datetime2");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AsignacionTipoServicioId");

                    b.HasIndex("PacienteId");

                    b.ToTable("AsignarTurno");
                });

            modelBuilder.Entity("ConsultorioAPI.Entidades.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("ConsultorioAPI.Entidades.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("ConsultorioAPI.Entidades.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreServicio")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("ConsultorioAPI.Entidades.TipoEmpleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreTipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TipoEmpleados");
                });

            modelBuilder.Entity("ConsultorioAPI.Entidades.AsignacionTipoEmpleado", b =>
                {
                    b.HasOne("ConsultorioAPI.Entidades.Empleado", "Empleado")
                        .WithMany("Asignacion")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsultorioAPI.Entidades.TipoEmpleado", "TipoEmpleado")
                        .WithMany("AsignacionTipos")
                        .HasForeignKey("TipoEmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");

                    b.Navigation("TipoEmpleado");
                });

            modelBuilder.Entity("ConsultorioAPI.Entidades.AsignacionTipoServicio", b =>
                {
                    b.HasOne("ConsultorioAPI.Entidades.Empleado", "Empleado")
                        .WithMany("Servicio")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsultorioAPI.Entidades.Servicio", "TipoServicio")
                        .WithMany("AsignacionServicio")
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");

                    b.Navigation("TipoServicio");
                });

            modelBuilder.Entity("ConsultorioAPI.Entidades.AsignarTurno", b =>
                {
                    b.HasOne("ConsultorioAPI.Entidades.AsignacionTipoServicio", "ServicioEmpleado")
                        .WithMany()
                        .HasForeignKey("AsignacionTipoServicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsultorioAPI.Entidades.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");

                    b.Navigation("ServicioEmpleado");
                });

            modelBuilder.Entity("ConsultorioAPI.Entidades.Empleado", b =>
                {
                    b.Navigation("Asignacion");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("ConsultorioAPI.Entidades.Servicio", b =>
                {
                    b.Navigation("AsignacionServicio");
                });

            modelBuilder.Entity("ConsultorioAPI.Entidades.TipoEmpleado", b =>
                {
                    b.Navigation("AsignacionTipos");
                });
#pragma warning restore 612, 618
        }
    }
}
