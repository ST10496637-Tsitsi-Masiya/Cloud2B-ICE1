using Azure;
using Azure.Data.Tables;
using UniversityCourseApp.Models;

namespace UniversityCourseApp.Services
{
    public class TableStorageService
    {
        private readonly TableClient courseTable;

        private readonly TableClient studentTable;

        public TableStorageService(IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("StorageConnection");

            courseTable = new TableClient(connection, "Courses");

            studentTable = new TableClient(connection, "Students");

            courseTable.CreateIfNotExists();

            studentTable.CreateIfNotExists();
        }

        public void AddCourse(CourseEntity course)
        {
            courseTable.AddEntity(course);
        }

        public void AddStudent(StudentEntity student)
        {
            studentTable.AddEntity(student);
        }

        public Pageable<CourseEntity> GetCourses()
        {
            return courseTable.Query<CourseEntity>();
        }

        public Pageable<StudentEntity> GetStudents()
        {
            return studentTable.Query<StudentEntity>();
        }

        public void UpdateCourse(CourseEntity course)
        {
            courseTable.UpdateEntity(course, course.ETag);
        }

        public void UpdateStudent(StudentEntity student)
        {
            studentTable.UpdateEntity(student, student.ETag);
        }

        public void DeleteCourse(string partition, string row)
        {
            courseTable.DeleteEntity(partition, row);
        }

        public void DeleteStudent(string partition, string row)
        {
            studentTable.DeleteEntity(partition, row);
        }
    }
}
