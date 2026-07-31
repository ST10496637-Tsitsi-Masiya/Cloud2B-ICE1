using Azure;
using Azure.Data.Tables;

namespace UniversityCourseApp.Models
{
    public class CourseEntity : ITableEntity
    {
        public string PartitionKey { get; set; } = "Course";

        public string RowKey { get; set; }

        public string CourseName { get; set; }

        public string Instructor { get; set; }

        public int Credits { get; set; }

        public ETag ETag { get; set; }

        public DateTimeOffset? Timestamp { get; set; }
    }
}
