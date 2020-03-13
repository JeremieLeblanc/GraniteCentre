using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using GraniteCentre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteCentre.Helpers
{
    public class Helpers
    {
        public static async Task<ResponseModel> SendMailHelper(string senderAddress, List<string> receiverAddress, string subject, string htmlBody, string textBody, string configSet = "")
        {
            using (var client = new AmazonSimpleEmailServiceClient(RegionEndpoint.USEast1))
            {
                var sendRequest = new SendEmailRequest
                {
                    Source = "info@granitecentremoncton.com",
                    Destination = new Destination
                    {
                        ToAddresses = receiverAddress
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
                            },
                            Text = new Content
                            {
                                Charset = "UTF-8",
                                Data = textBody
                            }
                        }
                    },
                    ReplyToAddresses = new List<string>()
                    {
                        senderAddress
                    }
                    // If you are not using a configuration set, comment
                    // or remove the following line 
                    //ConfigurationSetName = configSet
                };
                try
                {
                    var response = await client.SendEmailAsync(sendRequest);
                    return new ResponseModel() { Success = true, Message = response.HttpStatusCode.ToString() } ;
                    //return new ResponseModel() { Success = true, Message = "Success" };
                }
                catch (Exception ex)
                {
                    return new ResponseModel() { Success = false, Message = ex.ToString() };
                }
            }
        }
    }
}
