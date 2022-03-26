using System;
using System.Collections.Generic;
using System.Text;
using Data.Objects;

namespace Data.Interfaces
{
    public interface ICampaign:IDataAccess
    {

        public int AddCampaign(Campaign campaign);
        public void CancelCampaign(int campaignId);
        public List<Campaign> GetScheduledCampaignsByPartyId(int partyId);
        public List<Campaign> GetSentCampaignMessagesByPartyId(int partyId);
        public Campaign GetCampainRecordByCampaignIdwithSummaryData(int campaignId);
    }
}
