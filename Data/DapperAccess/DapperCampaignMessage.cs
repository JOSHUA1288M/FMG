using Dapper;
using Data.Interfaces;
using Data.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data.DapperAccess
{
    public class DapperCampaignMessage : ICampaignMessage
    {
  

        public int Add(List<CampaignMessage> campaignMessages)
        {

            StringBuilder query = new StringBuilder();
            query.AppendLine("INSERT INTO[nwsltr].[CampaignMessage]");
            query.AppendLine(" ([CampaignID]");
            query.AppendLine(",[Identifier]");
            query.AppendLine(",[SimpleQueryServiceMessageId]");
            query.AppendLine(",[SimpleQueryServiceRequestId]");
            query.AppendLine(",[DateTimeCreated]");
            query.AppendLine(",[SimpleEmailServiceMessageId]");
            query.AppendLine(",[SimpleEmailServiceRequestId]");
            query.AppendLine(",[SimpleEmailServiceDateTimeCreated]");
            query.AppendLine(",[ContactID]");
            query.AppendLine(",[Opened]");
            query.AppendLine(",[ClickedThrough]");
            query.AppendLine(",[SimpleQueryServiceMessageDateTimeCreated]");
            query.AppendLine(",[SimpleEmailServiceMessageDateTimeCreated]");
            query.AppendLine(",[TotalOpens]");
            query.AppendLine(",[TotalClicks])");
            query.AppendLine("VALUES");
            query.AppendLine("(@CampaignID");
            query.AppendLine(",@Identifier");
            query.AppendLine(",@SimpleQueryServiceMessageId");
            query.AppendLine(",@SimpleQueryServiceRequestId");
            query.AppendLine(",@DateTimeCreated");
            query.AppendLine(",@SimpleEmailServiceMessageId");
            query.AppendLine(",@SimpleEmailServiceRequestId");
            query.AppendLine(",@SimpleEmailServiceDateTimeCreated");
            query.AppendLine(",@ContactID");
            query.AppendLine(",@Opened");
            query.AppendLine(",@ClickedThrough");
            query.AppendLine(",@SimpleQueryServiceMessageDateTimeCreated");
            query.AppendLine(",@SimpleEmailServiceMessageDateTimeCreated");
            query.AppendLine(",@TotalOpens");
            query.AppendLine(",@TotalClicks)");
            query.AppendLine(" SELECT CAST(SCOPE_IDENTITY() as int)");
      
            using (SqlConnection connection = new SqlConnection(Configurations.ConnectionString))
            {
                connection.Open();
                
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                         connection.Execute(query.ToString(), campaignMessages,tran);
                        tran.Commit();
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        //Roll Back
                        tran.Rollback();
                        throw new Exception("Failed To Add Emails: " + ex.Message);
                       
                    }
                }
            }
            }
        }

    }

