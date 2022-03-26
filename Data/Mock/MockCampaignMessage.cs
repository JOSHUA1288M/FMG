using System;
using System.Collections.Generic;
using System.Text;
using Data.Interfaces;
using Data.Objects;

namespace Data.Mock
{
    public class MockCampaignMessage : ICampaignMessage 
    {
 

        public int Add(List<CampaignMessage> campaignMessage)
        {
            throw new NotImplementedException();
        }

        public List<CampaignMessage> GetCampaignByPartyId(int id)
        {
            var random = new Bogus.Randomizer();
            var randomCount = random.Number(1, 24);
            List<CampaignMessage> campaignList = new List<CampaignMessage>();
            for (var x = 0; x < randomCount; x++)
            {
                campaignList.Add(GetMockCampaignMessage());
            }

            return campaignList;
        }

        private CampaignMessage GetMockCampaignMessage()
        {
            var random = new Bogus.Randomizer();

            var randomDayCount = random.Number(1, 24);

            return new CampaignMessage()
            {
                CampaignID = random.Int(0, 10000),
                CampaignMessageID = random.Int(5450000, 5459000),
                Identifier = random.Guid(),
                SimpleEmailServiceMessageId = random.Word(),
                SimpleEmailServiceDateTimeCreated = DateTime.Now.AddMonths(randomDayCount),
                SimpleEmailServiceMessageDateTimeCreated = DateTime.Now.AddMonths(randomDayCount),
                SimpleEmailServiceMessageIdAddress = random.Word(),
                SimpleEmailServiceRequestId = random.Word(),
                SimpleQueryServiceMessageDateTimeCreated = DateTime.Now.AddMonths(randomDayCount),
                SimpleQueryServiceMessageId = random.Word(),
                SimpleQueryServiceRequestId = random.Word(),
                ClickedThrough = random.Bool(),
                ContactID = random.Int(),
                DateTimeCreated = DateTime.Now.AddMonths(-randomDayCount),
                Opened = random.Bool(),
                TotalClicks = random.Int(),
                TotalOpens = random.Int()

            };
        }



    }
}
