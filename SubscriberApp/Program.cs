using System;
using System.Threading.Tasks;
using Google.Cloud.PubSub.V1;
using System.Threading;

namespace SubscriberApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().RunSubscriberAsync().Wait();

            Console.WriteLine("\n\nTap to continue...");
            Console.ReadKey();
        }

        private async Task RunSubscriberAsync()
        {
            // The GOOGLE_APPLICATION_CREDENTIALS environment variable contains the path to the
            // key json file.
            // string value = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
            // var credential = await GoogleCredential.GetApplicationDefaultAsync();

            // Make sure you subscriptionId doesn't contain '/' symbols.
            var projectId = "{YOUR-PROJECT-ID}";
            var subscriptionId = "{YOUR-SUBSCRIPTION-ID}";
            var subscriptionName = new SubscriptionName(projectId, subscriptionId);

            var subscription = await SubscriberClient.CreateAsync(subscriptionName);

            await subscription.StartAsync(HandleMessage);
        }

        private Task<SubscriberClient.Reply> HandleMessage(PubsubMessage message, CancellationToken token)
        {
            var receivedMessage = message.Data.ToStringUtf8();
            Console.WriteLine($"New message has been received!\nMessage: {receivedMessage}");

            return Task.Run(() => SubscriberClient.Reply.Ack);
        }
    }
}