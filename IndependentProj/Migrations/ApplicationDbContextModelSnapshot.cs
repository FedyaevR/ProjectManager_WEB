// <auto-generated />
using System;
using IndependentProj.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IndependentProj.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IndependentProj.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"), 1L, 1);

                    b.Property<int>("ChoosedProjectID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees", (string)null);

                    b.HasData(
                        new
                        {
                            EmployeeID = 1,
                            ChoosedProjectID = 0,
                            Email = "asdasd@mail.ru",
                            Name = "Bob",
                            PhoneNumber = "79912301203",
                            SecondName = "Bobov"
                        });
                });

            modelBuilder.Entity("IndependentProj.Models.EmployeeProject", b =>
                {
                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.HasKey("EmployeeID", "ProjectID");

                    b.HasIndex("ProjectID");

                    b.ToTable("EmployeeProject", (string)null);
                });

            modelBuilder.Entity("IndependentProj.Models.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectID"), 1L, 1);

                    b.Property<int>("ChoosedEmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("CustomerCompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DoneDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PerformerCompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectID");

                    b.ToTable("Projects", (string)null);

                    b.HasData(
                        new
                        {
                            ProjectID = 1,
                            ChoosedEmployeeID = 0,
                            CustomerCompanyName = "FristCustomer",
                            DoneDate = new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PerformerCompanyName = "FirstPerformer",
                            Priority = 1,
                            ProjectName = "FirstProject",
                            StartDate = new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("IndependentProj.Models.EmployeeProject", b =>
                {
                    b.HasOne("IndependentProj.Models.Employee", "Employee")
                        .WithMany("EmployeeProject")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IndependentProj.Models.Project", "Project")
                        .WithMany("EmployeeProject")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("IndependentProj.Models.Employee", b =>
                {
                    b.Navigation("EmployeeProject");
                });

            modelBuilder.Entity("IndependentProj.Models.Project", b =>
                {
                    b.Navigation("EmployeeProject");
                });
#pragma warning restore 612, 618
        }
    }
}
