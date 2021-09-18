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
                DateTime now = DateTime.Now;
                if(StartDate > now)
                    return Status.New;
                else if(!_endDate.HasValue && !_graduationDate.HasValue)
                    return Status.Active;
                else if (_endDate <= now)
                    return Status.Dropout;
                else if (_graduationDate <= now)
                    return Status.Graduated;
                else 
                    return Status.Active;
            } 
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get => _endDate.GetValueOrDefault(); set => _endDate = value; }
        private DateTime? _endDate;

        public DateTime GraduationDate { get => _graduationDate.GetValueOrDefault(); set => _graduationDate = value; }
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
