using System;
using System.Threading.Tasks;
using Google.Cloud.PubSub.V1;
using Google.Protobuf;

namespace PublisherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().RunPublisherAsync().Wait();

            Console.WriteLine("\n\nTap to continue...");
            Console.ReadKey();
        }

        private async Task RunPublisherAsync()
        {
            // The GOOGLE_APPLICATION_CREDENTIALS environment variable contains the path to the
            // key json file.
            // string value = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
            // var credential = await GoogleCredential.GetApplicationDefaultAsync();

            // Make sure you topicId doesn't contain '/' symbols.
            var projectId = "{YOUR-PROJECT-ID}";
            var topicId = "{YOUR-TOPIC-ID}";
            var topicName = new TopicName(projectId, topicId);
            var topic = await PublisherClient.CreateAsync(topicName);

            var pubSubMessage = CreatePubSubMessage("Hello Ilya! This is my first message.");
            await topic.PublishAsync(pubSubMessage);
        }

        private PubsubMessage CreatePubSubMessage(string message)
        {
            return new PubsubMessage
            {
                Data = ByteString.CopyFromUtf8(message),
            };
        }
    }
}