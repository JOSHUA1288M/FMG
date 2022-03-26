using Data.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ICampaignFunctions
    {
        public int ScheduleCampaign(int partyId, Guid AssetIdentifier, DateTime scheduledDatetime, List<int> Contacts);
        public int AddCampaign(int partyId, Guid AssetIdentifier, List<int> Contacts);
        public void CancelCampaign(int campaignId);
        public List<Campaign> GetScheduledCampaignsByPartyId(int partyId);
        public List<Campaign> GetSentCampaignMessagesByPartyId(int partyId);
        public Campaign GetCampainRecordByCampaignIdwithSummaryData(int campaignId);

    }
}
