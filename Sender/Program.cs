using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using Microsoft.ServiceBus.Messaging;

namespace Sender
{
    class Program
    {
        static string eventHubname = "hub01";
        static string connectionString = "Endpoint=sb://damien-eventhub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8CfLa8nCPQuLkYLh8lbLv7JPbaXWed0V/8Fnzq8eB1s=";

        static void SendindRandomMessages()
        {
            var eventHubClient = EventHubClient.CreateFromConnectionString(connectionString, eventHubname);
            int count = 0;
            while (count < 100)
            {
                try
                {
                    var message = "Message";
                    Console.WriteLine("{0} > Sneding message : {1}", DateTime.Now, message + count);
                    eventHubClient.Send(new EventData(Encoding.UTF8.GetBytes(message + count)));//Sending msg through EHClient.
                    count += 1;
                }
                catch (Exception exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} > Sneding message: {1}", DateTime.Now, exception.Message);
                    Console.ResetColor();
                }
                Thread.Sleep(200);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Press Ctrl+C to stop the sender process");
            Console.WriteLine("Press Enter to start Now");
            Console.ReadLine();
            SendindRandomMessages();
        }
    }
}
