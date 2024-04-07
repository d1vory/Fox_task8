﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task8.Data;

#nullable disable

namespace Task8.Migrations
{
    [DbContext(typeof(SqlServerAppContext))]
    partial class SqlServerAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.2.24128.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Task8.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Learn the basics of Python programming language, including variables, data types, control structures, functions, and basic algorithms.",
                            Name = "Python Programming Fundamentals"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Discover effective digital marketing strategies, including search engine optimization (SEO), social media marketing, email marketing, and content marketing.",
                            Name = "Digital Marketing Strategies"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Get started with web development by learning HTML, CSS, and JavaScript fundamentals.",
                            Name = "Web Development Basics"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Learn the fundamentals of graphic design, including typography, color theory, layout design, and image manipulation techniques.",
                            Name = "Graphic Design Essentials"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Get started with mobile app development by learning about mobile platforms, user interface design, and mobile app development tools.",
                            Name = "Mobile App Development Basics"
                        });
                });

            modelBuilder.Entity("Task8.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            Name = "PPF-01",
                            StudentId = 1,
                            TeacherId = 1
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 1,
                            Name = "PPF-02",
                            StudentId = 2,
                            TeacherId = 1
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 1,
                            Name = "PPF-03",
                            StudentId = 3,
                            TeacherId = 1
                        },
                        new
                        {
                            Id = 4,
                            CourseId = 2,
                            Name = "DMC-01",
                            StudentId = 3,
                            TeacherId = 2
                        },
                        new
                        {
                            Id = 5,
                            CourseId = 2,
                            Name = "DMC-02",
                            StudentId = 4,
                            TeacherId = 2
                        },
                        new
                        {
                            Id = 6,
                            CourseId = 3,
                            Name = "WDB-01",
                            StudentId = 5,
                            TeacherId = 3
                        },
                        new
                        {
                            Id = 7,
                            CourseId = 3,
                            Name = "WDB-02",
                            StudentId = 6,
                            TeacherId = 3
                        },
                        new
                        {
                            Id = 8,
                            CourseId = 4,
                            Name = "GDE-01",
                            StudentId = 7,
                            TeacherId = 4
                        });
                });

            modelBuilder.Entity("Task8.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Alice",
                            LastName = "Smith"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Michael",
                            LastName = "Johnson"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Emily",
                            LastName = "Brown"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Daniel",
                            LastName = "Wilson"
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "Jessica",
                            LastName = "Martinez"
                        },
                        new
                        {
                            Id = 7,
                            FirstName = "Matthew",
                            LastName = "Taylor"
                        },
                        new
                        {
                            Id = 8,
                            FirstName = "Sophia",
                            LastName = "Anderson"
                        },
                        new
                        {
                            Id = 9,
                            FirstName = "William",
                            LastName = "Thomas"
                        },
                        new
                        {
                            Id = 10,
                            FirstName = "Olivia",
                            LastName = "Hernandez"
                        },
                        new
                        {
                            Id = 11,
                            FirstName = "Ethan",
                            LastName = "Moore"
                        });
                });

            modelBuilder.Entity("Task8.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Ava",
                            LastName = "Martin"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Adrian",
                            LastName = "Herrero"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Elena",
                            LastName = "Pascual"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Diego",
                            LastName = "Delgado"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Cristina",
                            LastName = "Molina"
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "Antonio",
                            LastName = "Ortega"
                        },
                        new
                        {
                            Id = 7,
                            FirstName = "Gabriel",
                            LastName = "Marquez"
                        },
                        new
                        {
                            Id = 8,
                            FirstName = "Laura",
                            LastName = "Santiago"
                        });
                });

            modelBuilder.Entity("Task8.Models.Group", b =>
                {
                    b.HasOne("Task8.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task8.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task8.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
