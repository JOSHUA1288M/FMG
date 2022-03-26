using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Objects
{
    public class Campaign
    {
        #region Instance Properties

        public int CampaignID { get; set; }

        public Guid Identifier { get; set; }

        public int PartyID { get; set; }

        public string Name { get; set; }

        public string UTM_Medium { get; set; }

        public string UTM_Source { get; set; }

        public string UTM_Term { get; set; }

        public string URL { get; set; }

        public DateTime DateTimeCreated { get; set; }

        public Guid? AssetIdentifier { get; set; }

        public int? NumberOfContacts { get; set; }

        public int? PartyCampaignId { get; set; }

        public DateTime? DateTimeScheduled { get; set; }

        public DateTime? DateTimeDeleted { get; set; }

        public DateTime? DateTimeSent { get; set; }

        public bool IsQueued { get; set; }

        public int? EmailTemplateId { get; set; }

        public int? PersonaId { get; set; }

        public int EmailTypeId { get; set; }

        public int? MasterCampaignId { get; set; }

        public int SendAsType { get; set; }

        public Guid? ApiClient { get; set; }

        #endregion Instance Properties



    }
}
