using System;
using Twilio.Types;
using static Twilio.Rest.Api.V2010.Account.Call.FeedbackSummaryResource;

namespace AwsAuthUtility.Infrastructure.Models
{
    public class TwilioContent
    {
        public string Body { get; set; }

        public PhoneNumber From { get; set; }

        public string To { get; set; }

        public string Uri { get; set; }

        public StatusEnum Status { get; set; }

        public DateTime? DateSent { get; set; }

        public DateTime? DateUpdated { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
