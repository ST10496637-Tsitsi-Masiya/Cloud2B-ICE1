using Azure;
using Azure.Data.Tables;

namespace UniversityCourseApp.Models
{
    public class StudentEntity : ITableEntity
    {
        public string PartitionKey { get; set; } = "Student";

        public string RowKey { get; set; }

        public string StudentName { get; set; }

        public string Email { get; set; }

        public string EnrolledCourses { get; set; } = "";

        public ETag ETag { get; set; }

        public DateTimeOffset? Timestamp { get; set; }
    }
}
