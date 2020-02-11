using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace jk468115MIS4200.Models
{
    public class Student
    {
        public int studentID { get; set; }
        public string studentFirstName { get; set; }
        public string studentLastName { get; set; }
        public string studentAddress { get; set; }

        public ICollection<Course> Course { get; set; }

    }

    public class Course
    {
        public int courseID { get; set; }
        public string courseName { get; set; }
        public string courseDescription { get; set; }
        
        public ICollection<Registration> Registration { get; set; }
    }

    public class Registration
    {
        [Key]
        public int registrationID { get; set; }

        public int studentID { get; set; }
        public virtual Student Student { get; set; }

        public int courseID { get; set; }
        public virtual Course Course { get; set; }

    }
}