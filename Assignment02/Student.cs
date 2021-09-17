using System;
using System.Text;

namespace Assignment02
{
    public class Student
    {
        public Student(int id, string givenName, string surname)
        {
            Id = id;
            GivenName = givenName;
            Surname = surname;
            StartDate = DateTime.Now;
        }

        public Student(int id, string givenName, string surname,
                        DateTime startDate, DateTime endDate, DateTime graduationDate)
        {
            Id = id;
            GivenName = givenName;
            Surname = surname;
            StartDate = startDate;
            EndDate = endDate;
            GraduationDate = graduationDate;
        }

        public int Id { get; init; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public Status Status 
        { 
            get
            {
                if (GraduationDate.HasValue || EndDate.HasValue){
                    if (GraduationDate.HasValue) return Status.Graduated;
                    else return Status.Dropout;
                }
                else if (DateTime.Now > )
            } 
        }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; private set; }
        public DateTime? GraduationDate { get; private set; }

        private void SetStatus(DateTime startDate, DateTime endDate, DateTime graduationDate)
        {
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Id: {Id} Name: {GivenName} {Surname} Status: {Status} Start date: {StartDate}");
            if (EndDate.HasValue) sb.Append($" End date {EndDate}");
            if (GraduationDate.HasValue) sb.Append($" Graduation date {GraduationDate}");
            return sb.ToString();            
        }
    }
}
