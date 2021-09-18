using System;
using System.Collections.Generic;
using Xunit;

namespace Assignment02.Tests
{
    public class StudentTest : IDisposable
    {
        public static TheoryData<Student, Status> CtorStudents => new TheoryData<Student, Status>
        {
            {new Student {Id = 1, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(1)}, Status.New},
            {new Student {Id = 2, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1)}, Status.Active},
            {new Student {Id = 3, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now}, Status.Dropout},
            {new Student {Id = 4, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1), GraduationDate = DateTime.Now}, Status.Graduated}
        };

        public static TheoryData<Student> Students => new TheoryData<Student>
        {
            {new Student {Id = 1, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(1)}},
            {new Student {Id = 2, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1)}},
            {new Student {Id = 3, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now}},
            {new Student {Id = 4, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1), GraduationDate = DateTime.Now}}
        };

        private Student _activeStudent;
        private Student _dropOutStudent;
        private Student _graduatedStudent;

        public StudentTest()
        {
            _activeStudent = new () {Id = 2, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1)};
            _dropOutStudent = new () {Id = 3, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now};
            _graduatedStudent = new () {Id = 4, GivenName = "Test", Surname = "Testesen", StartDate = DateTime.Now.AddDays(-1), GraduationDate = DateTime.Now};
        }

        public void Dispose()
        {
            _activeStudent = null;
        }

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
        public void SetGraduationDate_GraduationBehindStartDateOnActiveStudent_ThrowInvalidArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _activeStudent.GraduationDate = DateTime.MinValue);
        }

        [Fact]
        public void SetEndDate_EndDateBehindStartDateOnActiveStudent_ThrowInvalidArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _activeStudent.EndDate = DateTime.MinValue);
        }

        [Fact]
        public void SetEndDate_OnGraduatedStudent_ThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _graduatedStudent.EndDate = DateTime.MaxValue);
            Assert.Throws<InvalidOperationException>(() => _graduatedStudent.EndDate = DateTime.MinValue);
        }

        [Fact]
        public void SetGraduationDate_OnDropOutStudent_ThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _graduatedStudent.GraduationDate = DateTime.MaxValue);
            Assert.Throws<InvalidOperationException>(() => _graduatedStudent.GraduationDate = DateTime.MinValue);
        }

        [Fact]
        public void SetStartDate_DateBehindStartDate_ThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _activeStudent.StartDate = DateTime.MinValue);
            Assert.Throws<InvalidOperationException>(() => _dropOutStudent.StartDate = DateTime.MinValue);
            Assert.Throws<InvalidOperationException>(() => _graduatedStudent.StartDate = DateTime.MinValue);
        }

        [Theory]
        [MemberData(nameof(Students))]
        public void SetStartDate_NewStartDate_StartDateIsSetToNewAndOtherDatesIsReset(Student student) 
        {
            DateTime newStartDate = DateTime.Now.AddMonths(2);
            student.StartDate = newStartDate;

            Assert.Equal(newStartDate, student.StartDate);
            Assert.Equal(DateTime.MinValue, student.EndDate);
            Assert.Equal(DateTime.MinValue, student.GraduationDate);
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
