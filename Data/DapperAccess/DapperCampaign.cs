using Dapper;
using Data.Interfaces;
using Data.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Data.DapperAccess
{
    public class DapperCampaign : ICampaign
    {




        public void CancelCampaign(int campaignId)
        {
            using (SqlConnection connection = new SqlConnection(Configurations.ConnectionString))
            {
                connection.Execute("update Campaign set DatetimeDeleted =  GETDATE() WHERE CampaignId = @Id and datetimesent is null", new { Id = campaignId });
            }
        }


        public List<Campaign> GetScheduledCampaignsByPartyId(int partyId)
        {
            using (SqlConnection connection = new SqlConnection(Configurations.ConnectionString))
            {
                var myCampaign = connection.Query<Campaign>("SELECT * FROM nwsltr.Campaign WHERE  PartyId = @Id and datetimescheduled is not null and datetimedeleted is null and datetimesent is null ", new { Id = partyId });
                var campaignList = myCampaign.ToList();
                var orderedList = campaignList.OrderBy(o => o.DateTimeScheduled).ToList();
                return orderedList;
            }
        }

        public List<Campaign> GetSentCampaignMessagesByPartyId(int partyId)
        {
            using (SqlConnection connection = new SqlConnection(Configurations.ConnectionString))
            {

                var myCampaign = connection.Query<Campaign>("SELECT * FROM nwsltr.Campaign WHERE  PartyId = @Id and datetimesent is not null ", new { Id = partyId });
                var campaignList = myCampaign.ToList();
                var orderedList = campaignList.OrderByDescending(o => o.DateTimeSent).ToList();

                return orderedList;
            }
        }

        public Campaign GetCampainRecordByCampaignIdwithSummaryData(int campaignId)
        {
            StringBuilder query = new StringBuilder();

            using (SqlConnection connection = new SqlConnection(Configurations.ConnectionString))
            {
                //We should be grouping this but im kinda iffy on the tables relation.
                var myCampaign = connection.QueryFirst<Campaign>("SELECT * FROM nwsltr.Campaign WHERE Campaignid = @Id ", new { Id = campaignId });
                var campaignMessageCount = connection.QueryFirst<int>("SELECT count(*) FROM nwsltr.CampaignMessage WHERE  CampaignId = @Id ", new { Id = campaignId });

                myCampaign.NumberOfContacts = campaignMessageCount;

                return myCampaign;
            }

        }


        public int AddCampaign(Campaign campaign)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("INSERT INTO[nwsltr].[Campaign] ");
            query.AppendLine("([Identifier]");
            query.AppendLine(",[PartyID]");
            query.AppendLine(",[Name]");
            query.AppendLine(",[UTM_Medium]");
            query.AppendLine(",[UTM_Source]");
            query.AppendLine(",[UTM_Term]");
            query.AppendLine(",[URL]");
            query.AppendLine(",[DateTimeCreated]");
            query.AppendLine(",[AssetIdentifier]");
            query.AppendLine(",[NumberOfContacts]");
            query.AppendLine(",[PartyCampaignId]");
            query.AppendLine(",[DateTimeScheduled]");
            query.AppendLine(",[DateTimeDeleted]");
            query.AppendLine(",[DateTimeSent]");
            query.AppendLine(",[IsQueued]");
            query.AppendLine(",[EmailTemplateId]");
            query.AppendLine(",[PersonaId]");
            query.AppendLine(",[EmailTypeId]");
            query.AppendLine(",[MasterCampaignId]");
            query.AppendLine(",[SendAsType]");
            query.AppendLine(",[ApiClient])");
            query.AppendLine(" VALUES ");
            query.AppendLine("(@Identifier,");
            query.AppendLine("@PartyID,");
            query.AppendLine("@Name,");
            query.AppendLine("@UTM_Medium,");
            query.AppendLine("@UTM_Source,");
            query.AppendLine("@UTM_Term,");
            query.AppendLine("@URL,");
            query.AppendLine("@DateTimeCreated,");
            query.AppendLine("@AssetIdentifier,");
            query.AppendLine("@NumberOfContacts,");
            query.AppendLine("@PartyCampaignId,");
            query.AppendLine("@DateTimeScheduled,");
            query.AppendLine("@DateTimeDeleted,");
            query.AppendLine("@DateTimeSent,");
            query.AppendLine("@IsQueued,");
            query.AppendLine("@EmailTemplateId,");
            query.AppendLine("@PersonaId,");
            query.AppendLine("@EmailTypeId,");
            query.AppendLine("@MasterCampaignId,");
            query.AppendLine("@SendAsType,");
            query.AppendLine("@ApiClient)");
            query.AppendLine(" SELECT CAST(SCOPE_IDENTITY() as int)");

            using (SqlConnection connection = new SqlConnection(Configurations.ConnectionString))
            {
                return connection.QuerySingle<int>(query.ToString(), campaign);
            }

        }


    }
}
