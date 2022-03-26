using Data.DapperAccess;
using Data.Interfaces;
using Data.Objects;
using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Domain.Functions
{
    public class CampaignFunctions : ICampaignFunctions
    {
        ICampaign _campaignData;
        ICampaignMessage _campaignMessageData;
        ICampaignMessageFunctions _campaignMessageFunctions;


        public CampaignFunctions(ICampaign campaignData, ICampaignMessage campaignMessageData, ICampaignMessageFunctions campaignMessageFunctions)
        {
            _campaignData = campaignData;
            _campaignMessageData = campaignMessageData;
            _campaignMessageFunctions = campaignMessageFunctions;
        }

        public void CancelCampaign(int campaignId)
        {
            _campaignData.CancelCampaign(campaignId);
        }

        public Campaign GetCampainRecordByCampaignIdwithSummaryData(int campaignId)
        {
            return _campaignData.GetCampainRecordByCampaignIdwithSummaryData(campaignId);
        }

        public List<Campaign> GetScheduledCampaignsByPartyId(int partyId)
        {
            return _campaignData.GetScheduledCampaignsByPartyId(partyId);
        }

        public List<Campaign> GetSentCampaignMessagesByPartyId(int partyId)
        {
            return _campaignData.GetSentCampaignMessagesByPartyId(partyId);
        }

        //Unfortunately im not 100% on this lingo, But We will run it as test information.
        public int ScheduleCampaign(int partyId, Guid AssetIdentifier, DateTime scheduledDatetime, List<int> Contacts)
        {
            int campaignId = AddCampaign(partyId, AssetIdentifier, Contacts);

            _campaignMessageFunctions.AddCampaignMessages(Contacts, campaignId, scheduledDatetime);

            return campaignId;
        }



        public int AddCampaign(int partyId, Guid AssetIdentifier, List<int> Contacts)
        {
            Data.Objects.Campaign c = new Data.Objects.Campaign();

            c.NumberOfContacts = Contacts.Count;
            c.DateTimeCreated = DateTime.Now;
            c.PartyID = partyId;
            c.AssetIdentifier = AssetIdentifier;
            //Me being someone who doesnt know. Ill do my best! Well do all the non nullables.
            c.Name = "We Need This";
            c.UTM_Medium = "We Need This";
            c.UTM_Source = "We Need This";
            c.UTM_Term = "We Need This";
            c.DateTimeCreated = DateTime.Now;
            c.IsQueued = false;
            c.EmailTypeId = 1;
            c.SendAsType = 1;

            return _campaignData.AddCampaign(c);
        }

      
    }
}
