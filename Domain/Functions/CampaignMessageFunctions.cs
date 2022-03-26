using Data.Interfaces;
using Data.Objects;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Functions
{
    public class CampaignMessageFunctions:ICampaignMessageFunctions
    {
        ICampaignMessage _CampaignMessageDataAccess;
        public CampaignMessageFunctions(ICampaignMessage cm) {
            _CampaignMessageDataAccess = cm;
        }


        public int AddCampaignMessages( List<int> contactIds, int campaignId, DateTime scheduledDate)
        {
            List<CampaignMessage> cmpMessages = new List<CampaignMessage>();
            foreach (var cmpId in contactIds)
            {
                CampaignMessage cm = new CampaignMessage();
                cm.CampaignID = campaignId;
                cm.ContactID = cmpId;
                cm.DateTimeCreated = DateTime.Now;
                cm.Identifier = Guid.NewGuid();
                cm.TotalClicks = 0;
                cm.TotalOpens = 0;
                cmpMessages.Add(cm);
            }

            return _CampaignMessageDataAccess.Add(cmpMessages);

        }

    }
}