using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Objects
{
    public class CampaignMessage
    {
        #region Instance Properties

        public int CampaignMessageID { get; set; }

        public int CampaignID { get; set; }

        public Guid Identifier { get; set; }

        public string SimpleQueryServiceMessageId { get; set; }

        public string SimpleQueryServiceRequestId { get; set; }

        public DateTime DateTimeCreated { get; set; }

        public string SimpleEmailServiceMessageId { get; set; }

        public string SimpleEmailServiceRequestId { get; set; }

        public DateTime? SimpleEmailServiceDateTimeCreated { get; set; }

        public int? ContactID { get; set; }

        public bool? Opened { get; set; }

        public bool? ClickedThrough { get; set; }

        public DateTime? SimpleQueryServiceMessageDateTimeCreated { get; set; }

        public DateTime? SimpleEmailServiceMessageDateTimeCreated { get; set; }

        public int TotalOpens { get; set; }

        public int TotalClicks { get; set; }

        public string SimpleEmailServiceMessageIdAddress { get; set; }

        #endregion Instance Properties
    }
}