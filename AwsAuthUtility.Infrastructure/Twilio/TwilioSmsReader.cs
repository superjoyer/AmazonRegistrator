using AwsAuthUtility.Infrastructure.Interfaces;
using AwsAuthUtility.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;
using Twilio.Rest.Api.V2010.Account;

namespace AwsAuthUtility.Infrastructure.Twilio
{
    public class TwilioSmsReader : IRemoteReader<TwilioContent>
    {
        public TwilioContent Read()
        {
            throw new NotImplementedException();
        }



        public List<TwilioContent> ReadAsList()
        {
            List<TwilioContent> accountSmsList = new List<TwilioContent>();
            try
            {
                ResourceSet<MessageResource> resourceListSet = MessageResource.Read();
                if (resourceListSet.Any())
                {
                    accountSmsList = resourceListSet
                        .Select(res => new TwilioContent()
                        {
                            Body = res.Body,
                            DateCreated = res.DateCreated,
                            DateUpdated = res.DateUpdated,
                            From = res.From,
                            To = res.To,
                            Uri = res.Uri

                        }).OrderBy(n => n.DateCreated)
                      .ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(-1);
            }

            return accountSmsList;
        }
    }
}
