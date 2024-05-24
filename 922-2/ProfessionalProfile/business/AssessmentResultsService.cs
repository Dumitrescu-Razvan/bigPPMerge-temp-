using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;
using ProfessionalProfile.RepoInterfaces;

namespace ProfessionalProfile.Business
{
    public class AssessmentResultsService
    {
        // private AssessmentResultRepo AssessmentResultRepo { get; }
        private IAssessmentResultRepoInterface<AssessmentResult> AssessmentResultRepo { get; }
        private IAssessmentTestRepoInterface<AssessmentTest> AssessmentTestRepo { get; }
        /*public AssessmentResultsService()
        {
            this.AssessmentResultRepo = new AssessmentResultRepo();
            this.AssessmentTestRepo = new AssessmentTestRepo();
        }*/

        public AssessmentResultsService(IAssessmentResultRepoInterface<AssessmentResult> assessmentResultRepo, IAssessmentTestRepoInterface<AssessmentTest> assessmentTestRepo)
        {
            this.AssessmentResultRepo = assessmentResultRepo;
            this.AssessmentTestRepo = assessmentTestRepo;
        }

        public List<AssessmentResult> GetResultsByUserId(int userId)
        {
            return this.AssessmentResultRepo.GetAssessmentResultsByUserId(userId);
        }

        public AssessmentTest GetTestById(int testId)
        {
            return this.AssessmentTestRepo.GetById(testId);
        }
    }
}
