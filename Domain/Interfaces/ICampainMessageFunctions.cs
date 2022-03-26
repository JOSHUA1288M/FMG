using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ICampaignMessageFunctions
    {
        public int AddCampaignMessages(List<int> contactId, int campaignId, DateTime scheduledDate);

    }
}
