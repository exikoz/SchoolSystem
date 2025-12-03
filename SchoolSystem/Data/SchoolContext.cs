using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SchoolSystem.data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() { }
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


        public DbSet<SchoolSystemDB.Models.Assigned> Assgineds { get; set; }
        public DbSet<SchoolSystemDB.Models.Classroom> Classrooms { get; set; }
        public DbSet<SchoolSystemDB.Models.ClassroomTeacher> ClassroomTeachers { get; set; }
        public DbSet<SchoolSystemDB.Models.Course> Courses { get; set; }
        public DbSet<SchoolSystemDB.Models.Enrolls> Enrolls { get; set; }
        public DbSet<SchoolSystemDB.Models.Report> Reports { get; set; }
        public DbSet<SchoolSystemDB.Models.ScheduleClassroom> ScheduleClassrooms { get; set; }
        public DbSet<SchoolSystemDB.Models.Student> Students { get; set; }
        public DbSet<SchoolSystemDB.Models.StudentReport> StudentReports { get; set; }
        public DbSet<SchoolSystemDB.Models.Teacher> Teachers { get; set; }
        public DbSet<SchoolSystemDB.Models.TeacherSignature> TeacherSignatures { get; set; }
        
    }
}
