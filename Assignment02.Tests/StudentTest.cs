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
        }
        
        
    }
}
