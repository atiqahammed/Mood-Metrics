using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SytnerCollege.Data;

namespace SytnerCollege.Migrations
{
    [DbContext(typeof(CollegeContext))]
    [Migration("20170618235026_ComplexDataModel")]
    partial class ComplexDataModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SytnerCollege.Models.Course", b =>
                {
                    b.Property<int>("CourseID");

                    b.Property<int>("Credits");

                    b.Property<int>("DepartmentID");

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("CourseID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("SytnerCollege.Models.CourseAssignment", b =>
                {
                    b.Property<int>("CourseID");

                    b.Property<int>("LecturerID");

                    b.HasKey("CourseID", "LecturerID");

                    b.HasIndex("LecturerID");

                    b.ToTable("CourseAssignment");
                });

            modelBuilder.Entity("SytnerCollege.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Budget")
                        .HasColumnType("money");

                    b.Property<int?>("LecturerID");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<DateTime>("StartDate");

                    b.HasKey("DepartmentID");

                    b.HasIndex("LecturerID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("SytnerCollege.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseID");

                    b.Property<int?>("Grade");

                    b.Property<int>("StudentID");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("SytnerCollege.Models.Lecturer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(254);

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasMaxLength(50);

                    b.Property<DateTime>("HireDate");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Lecturer");
                });

            modelBuilder.Entity("SytnerCollege.Models.OfficeAssignment", b =>
                {
                    b.Property<int>("LecturerID");

                    b.Property<string>("Location")
                        .HasMaxLength(50);

                    b.HasKey("LecturerID");

                    b.ToTable("OfficeAssignment");
                });

            modelBuilder.Entity("SytnerCollege.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DOB");

                    b.Property<DateTime>("EnrollmentDate");

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("SytnerCollege.Models.Course", b =>
                {
                    b.HasOne("SytnerCollege.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SytnerCollege.Models.CourseAssignment", b =>
                {
                    b.HasOne("SytnerCollege.Models.Course", "Course")
                        .WithMany("CourseAssignments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SytnerCollege.Models.Lecturer", "Lecturer")
                        .WithMany("CourseAssignments")
                        .HasForeignKey("LecturerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SytnerCollege.Models.Department", b =>
                {
                    b.HasOne("SytnerCollege.Models.Lecturer", "Administrator")
                        .WithMany()
                        .HasForeignKey("LecturerID");
                });

            modelBuilder.Entity("SytnerCollege.Models.Enrollment", b =>
                {
                    b.HasOne("SytnerCollege.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SytnerCollege.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SytnerCollege.Models.OfficeAssignment", b =>
                {
                    b.HasOne("SytnerCollege.Models.Lecturer", "Lecturer")
                        .WithOne("OfficeAssignment")
                        .HasForeignKey("SytnerCollege.Models.OfficeAssignment", "LecturerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
