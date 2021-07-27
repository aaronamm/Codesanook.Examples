using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Codesanook.Examples.DotNet.AwsApi
{
    public class SesClientTest
    {
        [Fact]
        public async Task Test()
        {
            // Replace USWest2 with the AWS Region you're using for Amazon SES.
            // Acceptable values are EUWest1, USEast1, and USWest2.
            const string apiKey = "";
            const string apiSecret = "";

            var fromAddress = "xxx@your-domain.com";
            var fromName = "Name of sender";

            // Replace recipient@example.com with a "To" address. If your account 
            // is still in the sandbox, this address must be verified.
            var toAddress = "yyy@gmail.com";
            var subject = "Hello world";

            // The HTML body of the email.
            string htmlBody =
                @"<html>
                <head></head>
                <body>
                  <h1>Amazon SES Test (AWS SDK for .NET)</h1>
                  <p>This email was sent with
                    <a href='https://aws.amazon.com/ses/'>Amazon SES</a> using the
                    <a href='https://aws.amazon.com/sdk-for-net/'>
                      AWS SDK for .NET</a>.</p>
                </body>
                </html>";

            using var client = new AmazonSimpleEmailServiceClient(
                apiKey,
                apiSecret,
                RegionEndpoint.USWest2
            );

            var sendRequest = new SendEmailRequest
            {
                Source = $"{fromName} <{fromAddress}>",
                Destination = new Destination
                {
                    ToAddresses = new List<string> { toAddress }
                },
                Message = new Message
                {
                    Subject = new Content(subject),
                    Body = new Body
                    {
                        Html = new Content
                        {
                            Charset = "UTF-8",
                            Data = htmlBody
                        }
                    }
                },
            };

            try
            {
                Console.WriteLine("Sending email using Amazon SES...");
                var response = await client.SendEmailAsync(sendRequest);
                Console.WriteLine("The email was sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("The email was not sent.");
                Console.WriteLine("Error message: " + ex.Message);
            }
        }
    }
}
