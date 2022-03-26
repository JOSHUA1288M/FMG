using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FMG_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Data.Objects;

namespace FMG_Project.Controllers
{
    [ApiController]

    public class CampaignController : ControllerBase
    {

        private readonly ILogger<CampaignController> _logger;
        private readonly ICampaignFunctions _campaignFunctions;
        private readonly ICampaignMessageFunctions _campaignMessageFunctions;
        private readonly ILoginLayer _loginLayer;

        public CampaignController(ILogger<CampaignController> logger,  ILoginLayer loginLayer, ICampaignFunctions campaignFunctions, ICampaignMessageFunctions campaignMessageFunctions)
        {
            _loginLayer = loginLayer;
            _logger = logger;
            _campaignFunctions = campaignFunctions;
            _campaignMessageFunctions = campaignMessageFunctions;
        }

        [HttpPost]
        [Route("ScheduleEmailCampaign")]
        public ActionResult ScheduleEmailCampaign(string token, ScheduleEmailRequest scheduleEmailRequest  )
        {

            try
            {

                if (!_loginLayer.ValidateToken(token))

                    throw new Exception("Invalid Token");

                if (scheduleEmailRequest.DateTimeScheduled < DateTime.Now)
                    throw new Exception("Invalid Date: Must be later than now.");


                if (scheduleEmailRequest.ContactIds.Count == 0)
                    throw new Exception("Invalid Contacts: Must include contacts for your campaign.");

                if (!Guid.TryParse(scheduleEmailRequest.AssetIdentifier, out Guid validGuid))
                    throw new Exception("Invalid Asset Identifier.");


                int campaignId = _campaignFunctions.ScheduleCampaign(scheduleEmailRequest.PartyId, validGuid, scheduleEmailRequest.DateTimeScheduled, scheduleEmailRequest.ContactIds);

                return new ActionResult(campaignId);

            }
            catch (Exception e)
            {
                var errorMessage = "SendEmailCampaign Failed: " + e.Message ;
                _logger.LogError(e, errorMessage);
                return new ActionResult(errorMessage);
            }
        
        }


        [HttpGet]
        [Route("CancelEmail")]
        public ActionResult CancelEmail( string token,  int campaignId)
        {
            try
            {

                if (!_loginLayer.ValidateToken(token))

                    throw new Exception("Invalid Token");

                _campaignFunctions.CancelCampaign(campaignId);


                return new ActionResult(campaignId);

            }
            catch (Exception e)
            {

                _logger.LogError(e, "Cancel Campaign Failed:" + e.Message);

                return new ActionResult("Cancel Campaign Failed");
            }
        }

        [HttpGet]
        [Route("GetScheduledEmailsByPartyId")]
        public List<Campaign> GetScheduledEmailsByPartyId( string token,  int partyId)
        {
            try
            {

                if (!_loginLayer.ValidateToken(token))

                    throw new Exception("Invalid Token");

                List<Campaign> scheduledEmails = _campaignFunctions.GetScheduledCampaignsByPartyId(partyId);

                return scheduledEmails;

            }
            catch (Exception e)
            {

                _logger.LogError(e, "Failed to get scheduled emails:" + e.Message);

                throw new Exception("Failed to get scheduled emails:");
            }
        }

        [HttpGet]
        [Route("GetSentEmailsByPartyId")]
        public List<Campaign> GetSentEmailsByPartyId( string token,  int partyId)
        {
            try
            {

                if (!_loginLayer.ValidateToken(token))

                    throw new Exception("Invalid Token");

                List<Campaign> scheduledEmails = _campaignFunctions.GetSentCampaignMessagesByPartyId(partyId);

                return scheduledEmails;

            }
            catch (Exception e)
            {

                _logger.LogError(e, "Failed to get sent emails:" + e.Message);

                throw new Exception("Failed to get sent emails");
            }
        }

        [HttpGet]
        [Route("GetCampaignRecordByCampaignId")]
        public Campaign GetCampaignRecordByCampaignId(string token, int campaignId)
        {
            try
            {

                if (!_loginLayer.ValidateToken(token))

                    throw new Exception("Invalid Token");

                Campaign campaign = _campaignFunctions.GetCampainRecordByCampaignIdwithSummaryData(campaignId);

                return campaign;

            }
            catch (Exception e)
            {

                _logger.LogError(e, "Failed to get campaign record: " + e.Message);

                throw new Exception("Failed to get campaign record");
            }
        }
    }
}
