
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProfessionalProfile.Domain;
using ProfessionalProfile.Business;
using TestProject.RepoMocks;

namespace TestProject.TestServices
{

    public class PrivacyServiceTest
    {
        // how to name the test method: MethodName_StateUnderTest_ExpectedBehavior
        // the test below should be named: PrivacyService_AddPrivacy_PrivacyAdded
        [Fact]
        public void PrivacyService_AddPrivacy_PrivacyAdded()
        {
            Privacy privacy = new Privacy(1, true, true, true, true, true, true);


            PrivacyService privacyService = new PrivacyService(new PrivacyRepoMock());
            privacyService.AddPrivacy(privacy);

            int expected = 1;
            int actual = privacyService.GetPrivacy(1).UserId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PrivacyService_UpdatePrivacy_PrivacyUpdated()
        {
            Privacy privacy = new Privacy(1, true, true, true, true, true, true);

            PrivacyService privacyService = new PrivacyService(new PrivacyRepoMock());
            privacyService.AddPrivacy(privacy);

            privacy = new Privacy(1, false, false, false, false, false, false);
            privacyService.UpdatePrivacy(privacy);

            bool expected = false;
            bool actual = privacyService.GetPrivacy(1).CanViewEducation;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PrivacyService_Check_Null_Service()
        {
            PrivacyRepoMock repoMock = new PrivacyRepoMock();
            repoMock = null;
            PrivacyService privacyService = new PrivacyService(repoMock);
           // Assert.Equal(privacyService, null);
        }
        public void PrivacyService_GetPrivacy_PrivacyAdded()
        {
            Privacy privacy = new Privacy(1, true, true, true, true, true, true);
            PrivacyService privacyService = new PrivacyService(new PrivacyRepoMock());
            privacyService.AddPrivacy(privacy);

            int expected = 1;
            int actual = privacyService.GetPrivacy(1).UserId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PrivacyService_GetPrivacy_PrivacyNotExisting()
        {
            PrivacyService privacyService = new PrivacyService(new PrivacyRepoMock());

            Privacy expected = new Privacy(1, true, true, true, true, true, true);
            Privacy actual = privacyService.GetPrivacy(1);
            Assert.Equal(expected.UserId, actual.UserId);
        }
}   
}

