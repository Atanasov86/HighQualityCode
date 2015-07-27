namespace InheritanceAndPolymorphism.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private string courseCourseName;
        
        protected Course(string courseCourseName)
        {
            this.CourseName = courseCourseName;
            this.TeacherName = null;
            this.Students = new List<string>();
        }

        protected Course(string courseCourseName, string teacherName) 
            : this(courseCourseName)
        {
            this.TeacherName = teacherName;
        }

        protected Course(string courseCourseName, string teacherName, IList<string> students) 
            : this(courseCourseName, teacherName)
        {
            this.Students = students;
        }

        public string CourseName
        {
            get
            {
                return this.courseCourseName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("name", "CourseName cannot be null or empty.");
                }

                this.courseCourseName = value;
            }
        }

        public string TeacherName { get; set; }

        public IList<string> Students { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("{ CourseName = ");
            result.Append(this.CourseName);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            
            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }

            return "{ " + string.Join(", ", this.Students) + " }";
        }
    }
}


