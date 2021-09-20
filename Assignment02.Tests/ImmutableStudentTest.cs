using System;
using System.Collections.Generic;
using Xunit;

namespace Assignment02.Tests
{
    public class ImmutableStudentTest
    {
        public static TheoryData<ImmutableStudent, Status> CtorImmutableStudents => new TheoryData<ImmutableStudent, Status>
        {
            {new ImmutableStudent {Id = 1, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(1)}, Status.New},
            {new ImmutableStudent {Id = 2, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1)}, Status.Active},
            {new ImmutableStudent {Id = 3, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now}, Status.Dropout},
            {new ImmutableStudent {Id = 4, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1), GraduationDate = DateTime.Now}, Status.Graduated},
            {new ImmutableStudent {Id = 5, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-2), GraduationDate = DateTime.Now}, Status.Graduated},
            {new ImmutableStudent {Id = 6, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(3), GraduationDate = DateTime.Now}, Status.Graduated},
            {new ImmutableStudent {Id = 7, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), GraduationDate = DateTime.Now}, Status.Dropout},
            {new ImmutableStudent {Id = 7, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Today, EndDate = DateTime.Today, GraduationDate = DateTime.Today}, Status.Graduated}
        };

        [Theory]
        [MemberData(nameof(CtorImmutableStudents))]
        public void Ctor_StatusWhenProvidingDateTimes_StatusIsCorrectPropertiesIsSet(ImmutableStudent ImmutableStudent, Status expectedStatus)
        {
            Assert.True(0 < ImmutableStudent.Id);
            Assert.NotEmpty(ImmutableStudent.GivenName);
            Assert.NotNull(ImmutableStudent.GivenName);
            Assert.NotEmpty(ImmutableStudent.Surname);
            Assert.NotNull(ImmutableStudent.Surname);
            Assert.NotEqual(DateTime.MinValue, ImmutableStudent.StartDate);
            Assert.Equal(expectedStatus, ImmutableStudent.Status);
        }



        [Fact]
        public void ToString_NewOrActiveImmutableStudent_ReturnStringWithGeneralInfoAndStartDate()
        {
            var immutableStudent = new ImmutableStudent{Id = 1, GivenName = "Peter", Surname = "Jensen", StartDate = DateTime.Now};
            string expected = $"Id: 1, Name: Peter Jensen, Status: Active, Start date: {immutableStudent.StartDate}, End date {immutableStudent.EndDate}, Graduation date {immutableStudent.GraduationDate}";
            Assert.Equal(expected,immutableStudent.ToString());
        }
        
        
    }
}
