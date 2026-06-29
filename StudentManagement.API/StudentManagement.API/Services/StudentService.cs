using StudentManagement.API.Models;

namespace StudentManagement.API.Services {
    public class StudentService : IStudentService {
        private static readonly List<Student> Students = new()
        {
            new Student { ID = 1, Name = "John Doe", Email = "johndoe@gmail.com", Course = "ASP .NET Core" },
           new Student { ID = 2, Name = "Jane Smith", Email = "janesmith@gmail.com", Course = "C#" }
        };

        public List<Student> GetAll() {
            return Students;
        }

        public Student? GetById(int id) {
            return Students.FirstOrDefault(student => student.ID == id);
        }

        public Student Add(Student student) {
            student.ID = Students.Max(x => x.ID) + 1;
            Students.Add(student);

            return student;
        }
    }
}