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
            {new Student {Id = 2, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now}, Status.Active},
            {new Student {Id = 2, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now, EndDate = DateTime.Now}, Status.Dropout},
            {new Student {Id = 2, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now, GraduationDate = DateTime.Now}, Status.Graduated}
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
            string expected = $"Id: 1 Name: Peter Jensen Status: New Start date: {student.StartDate}";
            Assert.Equal(expected,student.ToString());
        }
        
        
    }
}
