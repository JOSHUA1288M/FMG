using Data.DapperAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Objects;

namespace Data.Interfaces
{
    public interface ICampaignMessage: IDataAccess
    {
        public int Add(List<CampaignMessage> campaignMessage);

    }
}
