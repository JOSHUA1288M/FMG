using System;
using System.Collections.Generic;
using System.Text;
using Data.Interfaces;
using Data.Objects;

namespace Data.Mock
{
    public class MockCampaign : ICampaign
    {


        public Campaign GetMockCampaign()
        {
            var random = new Bogus.Randomizer();

            var randomDayCount = random.Number(1, 24);

            return new Campaign()
            {
                CampaignID = random.Int(0, 10000),
                Identifier = random.Guid(),
                PartyID = random.Int(),
                Name = random.String(20),
                UTM_Medium = random.Word(),
                UTM_Source = random.Word(),
                UTM_Term = random.Word(),
                URL = random.Word() + ".com",
                DateTimeCreated = DateTime.Now.AddMonths(-randomDayCount),
                AssetIdentifier = random.Guid(),
                NumberOfContacts = random.Int(),
                PartyCampaignId = random.Int(),
                DateTimeScheduled = DateTime.Now.AddMonths(randomDayCount),
                DateTimeDeleted = null,
                DateTimeSent = DateTime.Now.AddMonths(-randomDayCount),
                IsQueued = random.Bool(),
                EmailTemplateId = random.Int(),
                PersonaId = random.Int(),
                EmailTypeId = random.Int(),
                MasterCampaignId = random.Int(),
                SendAsType = random.Int(),
                ApiClient = random.Guid()

            };
        }
        public int AddCampaign(Campaign campaign)
        {
            return 1;
        }

        public void CancelCampaign(int campaignId)
        {
        
        }

        public List<Campaign> GetCampaignByPartyId(int id)
        {
            var random = new Bogus.Randomizer();
            var randomCount = random.Number(1, 24);
            List <Campaign> campaignList = new List<Campaign>();
            for (var x = 0; x < randomCount; x++)
            {
                campaignList.Add(GetMockCampaign());
            }

            return campaignList;
        }

        public Campaign GetCampainRecordByCampaignIdwithSummaryData(int campaignId)
        {
            return GetMockCampaign();
        }


        public List<Campaign> GetScheduledCampaignsByPartyId(int partyId)
        {
            var random = new Bogus.Randomizer();
            var randomCount = random.Number(1, 24);
            List<Campaign> campaignList = new List<Campaign>();
            for (var x = 0; x < randomCount; x++)
            {
                campaignList.Add(GetMockCampaign());
            }
            return campaignList;
        }

        public List<Campaign> GetSentCampaignMessagesByPartyId(int partyId)
        {
            var random = new Bogus.Randomizer();
            var randomCount = random.Number(1, 24);
            List<Campaign> campaignList = new List<Campaign>();
            for (var x = 0; x < randomCount; x++)
            {
                campaignList.Add(GetMockCampaign());
            }
            return campaignList;
        }
    }
}
