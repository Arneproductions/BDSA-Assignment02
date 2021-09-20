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
                Status status;

                DateTime now = DateTime.Now;
                if(StartDate > now)
                    status = Status.New;
                else
                    status = Status.Active;

                if(Graduates && GraduationDate <= now)
                    status = Status.Graduated;
                else if(EndDate >= StartDate && EndDate <= now)
                    status = Status.Dropout;

                return status;
            } 
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime GraduationDate { get; set; }
        private DateTime _graduationDate;

        private bool Graduates => GraduationDate >= StartDate && ((EndDate < StartDate && GraduationDate > EndDate) || (EndDate >= StartDate && GraduationDate <= EndDate));
        


        public override string ToString()
        {
            return $"Id: {Id}, Name: {GivenName} {Surname}, Status: {Status}, Start date: {StartDate}, End date {EndDate}, Graduation date {GraduationDate}";
        }
    }
}
