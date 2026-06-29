using Moq;
using StudentManagement.API.Models;
using StudentManagement.API.Services;
using Xunit;

namespace StudentManagement.API.Test {
    public class StudentServiceTests {
        private readonly Mock<IStudentService> _mockService;

        public StudentServiceTests() {
            _mockService = new Mock<IStudentService>();
        }

        [Fact]
        public void GetAll_ShouldReturnStudents() {
            // Arrange
            var students = new List<Student>
            {
                new Student
                {
                    ID = 1,
                    Name = "John Doe",
                    Email = "johndoe@gmail.com",
                    Course = "ASP.NET Core"
                },
                new Student
                {
                    ID = 2,
                    Name = "Jane Smith",
                    Email = "janesmith@gmail.com",
                    Course = "C#"
                }
            };

            _mockService.Setup(s => s.GetAll())
                        .Returns(students);

            // Act
            var result = _mockService.Object.GetAll();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("John Doe", result[0].Name);
        }

        [Fact]
        public void GetById_ShouldReturnStudent() {
            // Arrange
            var student = new Student
            {
                ID = 1,
                Name = "John Doe",
                Email = "johndoe@gmail.com",
                Course = "ASP.NET Core"
            };

            _mockService.Setup(s => s.GetById(1))
                        .Returns(student);

            // Act
            var result = _mockService.Object.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("John Doe", result!.Name);
        }

        [Fact]
        public void Add_ShouldReturnAddedStudent() {
            // Arrange
            var student = new Student
            {
                ID = 3,
                Name = "Alice Johnson",
                Email = "alice@gmail.com",
                Course = "ASP.NET Core"
            };

            _mockService.Setup(s => s.Add(It.IsAny<Student>()))
                        .Returns(student);

            // Act
            var result = _mockService.Object.Add(new Student());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.ID);
            Assert.Equal("Alice Johnson", result.Name);
        }
    }
}