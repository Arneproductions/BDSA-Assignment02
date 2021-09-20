using System;

namespace Assignment02
{
    public record ImmutableStudent
    {
        public int Id { get; init; }
        public string GivenName { get; init; }
        public string Surname { get; init; }
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

        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }

        public DateTime GraduationDate { get; init; }
        private DateTime _graduationDate;

        private bool Graduates => GraduationDate >= StartDate && ((EndDate < StartDate && GraduationDate > EndDate) || (EndDate >= StartDate && GraduationDate <= EndDate));
        

        public override string ToString()
        {
            return $"Id: {Id}, Name: {GivenName} {Surname}, Status: {Status}, Start date: {StartDate}, End date {EndDate}, Graduation date {GraduationDate}";
        }

    }
}