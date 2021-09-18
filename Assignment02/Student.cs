using System;
using System.Text;

namespace Assignment02
{
    public class Student
    {
        public int Id { get; init; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public Status Status 
        { 
            get
            {
                // if (GraduationDate.HasValue || _endDate.HasValue){
                //     if (GraduationDate.HasValue) return Status.Graduated;
                //     else return Status.Dropout;
                // }
                // else if (DateTime.Now > )

                throw new NotImplementedException();
            } 
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        private DateTime? _endDate;

        public DateTime GraduationDate { get; set; }
        private DateTime? _graduationDate;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Id: {Id} Name: {GivenName} {Surname} Status: {Status} Start date: {StartDate}");
            if (_endDate.HasValue) sb.Append($" End date {EndDate}");
            if (_graduationDate.HasValue) sb.Append($" Graduation date {GraduationDate}");
            return sb.ToString();            
        }
    }
}
