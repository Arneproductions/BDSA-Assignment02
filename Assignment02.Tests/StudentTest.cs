using System;
using Xunit;

namespace Assignment02.Tests
{
    public class StudentTest
    {
        [Fact]
        public void ToStringTest()
        {
            var student = new Student(1, "Peter","Jensen");
            string expected = $"Id: 1 Name: Peter Jensen Status: New Start date: {student.StartDate}";
            Assert.Equal(expected,student.ToString());

            var student2 = new Student(2,"Hans","Petersen",Status.Active,DateTime.Today,DateTime.Now,DateTime.MaxValue);
            string expected2 = $"Id: 2 Name: Hans Petersen Status: Active Start date: {student.StartDate} End date {student.EndDate} Graduation date {student.GraduationDate}";
        }
        
        
    }
}
