using Azure.Storage.Queues;
using System.Text.Json;

namespace UniversityCourseApp.Services
{
    public class QueueStorageService
    {
        private readonly QueueClient queueClient;

        public QueueStorageService(IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("StorageConnection");

            queueClient = new QueueClient(connection, "CourseEnrollmentQueue");

            queueClient.CreateIfNotExists();
        }

        public void SendEnrollmentMessage(string studentId, string courseId)
        {
            var message = new
            {
                StudentId = studentId,
                CourseId = courseId
            };

            string json = JsonSerializer.Serialize(message);

            queueClient.SendMessage(json);
        }
    }
}
