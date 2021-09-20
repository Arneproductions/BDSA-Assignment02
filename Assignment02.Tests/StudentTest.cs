using System;
using System.Collections.Generic;
using Xunit;

namespace Assignment02.Tests
{
    public class StudentTest
    {
        public static TheoryData<Student, Status> CtorStudents => new TheoryData<Student, Status>
        {
            {new Student {Id = 1, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(1)}, Status.New},
            {new Student {Id = 2, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1)}, Status.Active},
            {new Student {Id = 3, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now}, Status.Dropout},
            {new Student {Id = 4, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1), GraduationDate = DateTime.Now}, Status.Graduated},
            {new Student {Id = 5, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-2), GraduationDate = DateTime.Now}, Status.Graduated},
            {new Student {Id = 6, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(3), GraduationDate = DateTime.Now}, Status.Graduated},
            {new Student {Id = 7, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), GraduationDate = DateTime.Now}, Status.Dropout},
            {new Student {Id = 7, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now, EndDate = DateTime.Now, GraduationDate = DateTime.Now}, Status.Graduated}
        };

        [Theory]
        [MemberData(nameof(CtorStudents))]
        public void Ctor_StatusWhenProvidingDateTimes_StatusIsCorrectPropertiesIsSet(Student student, Status expectedStatus)
        {
            Assert.True(0 < student.Id);
            Assert.NotEmpty(student.GivenName);
            Assert.NotNull(student.GivenName);
            Assert.NotEmpty(student.Surname);
            Assert.NotNull(student.Surname);
            Assert.NotEqual(DateTime.MinValue, student.StartDate);
            Assert.Equal(expectedStatus, student.Status);
        }



        [Fact]
        public void ToString_NewOrActiveStudent_ReturnStringWithGeneralInfoAndStartDate()
        {
            var student = new Student{Id = 1, GivenName = "Peter", Surname = "Jensen", StartDate = DateTime.Now};
            string expected = $"Id: 1, Name: Peter Jensen, Status: Active, Start date: {student.StartDate}, End date {student.EndDate}, Graduation date {student.GraduationDate}";
            Assert.Equal(expected,student.ToString());
        }
        
        
    }
}
