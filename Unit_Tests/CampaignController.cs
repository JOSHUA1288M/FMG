using Microsoft.Extensions.Logging;
using Moq;
using FMG_Project.Controllers;
using FMG_Project.Data;
using NUnit.Framework;
using System;
using Domain.Functions;
using FMG_Project;
using System.Collections.Generic;
using Unity.RegistrationByConvention;
using Data.Interfaces;
using Unity;
using Domain.Interfaces;

namespace Unit_Tests
{
    public class FMGTests
    {
        private CampaignController controller { get; set; }

       [SetUp]
        public void Setup()
        {
            var logger = Mock.Of<ILogger<CampaignController>>();
            var loginLayer = Mock.Of<MockLoginLayer>();
            var campaignFunctions = Mock.Of<ICampaignFunctions>();
            var campaignMessageFunctions = Mock.Of<ICampaignMessageFunctions>();

            controller = new CampaignController(logger,  loginLayer, campaignFunctions, campaignMessageFunctions);
        }

    

        [Test]

        public void SchedulingDateTooEarly()
        {
            ScheduleEmailRequest ser = new ScheduleEmailRequest();
            ser.AssetIdentifier = "17869a22-8dcc-486a-80c4-9c2b2a2c72c9";
            ser.ContactIds = new List<int>(new int[] { 1, 2, 3 });
            ser.DateTimeScheduled = DateTime.Now.AddDays(-1);
            ser.PartyId = 5;


            var campaignTest = controller.ScheduleEmailCampaign("MockLoginToken", ser);


            Assert.IsTrue(campaignTest.Success == false);

        }

        [Test]
        public void EmptyList()
        {

            ScheduleEmailRequest ser = new ScheduleEmailRequest();
            ser.AssetIdentifier = "17869a22-8dcc-486a-80c4-9c2b2a2c72c9";
            ser.ContactIds = new List<int>(new int[] {});
            ser.DateTimeScheduled = DateTime.Now.AddDays(1);
            ser.PartyId = 5;

            var campaignTest = controller.ScheduleEmailCampaign("MockLoginToken", ser);

            Assert.IsTrue(campaignTest.Success == false);
        }

        [Test]
        public void InvalidIdentifier()
        {

            ScheduleEmailRequest ser = new ScheduleEmailRequest();
            ser.AssetIdentifier = "BadGuid";
            ser.ContactIds =  new List<int>(new int[] { 1, 2, 3 });
            ser.DateTimeScheduled = DateTime.Now.AddDays(1);
            ser.PartyId = 5;

            var campaignTest = controller.ScheduleEmailCampaign("MockLoginToken", ser);


            Assert.IsTrue(campaignTest.Success == false);
        }

        [Test]
        public void ValidRequest()
        {
            ScheduleEmailRequest ser = new ScheduleEmailRequest();
            ser.AssetIdentifier = "17869a22-8dcc-486a-80c4-9c2b2a2c72c9";
            ser.ContactIds = new List<int>(new int[] { 1, 2, 3 });
            ser.DateTimeScheduled = DateTime.Now.AddDays(1);
            ser.PartyId = 5;

            var campaignTest = controller.ScheduleEmailCampaign("MockLoginToken", ser);

            Assert.IsTrue(campaignTest.Success == true);
           
        }

    }
}