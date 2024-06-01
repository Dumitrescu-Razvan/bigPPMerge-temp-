using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class AssessmentResult
    {
        public int assesmentResultId { get; set; }
        public int assesmentTestId { get; set; }
        public int score { get; set; }
        public string userId { get; set; }
        public DateTime testDate { get; set; }
        
        //Navigation properties
        public AssessmentTest AssessmentTest { get; set; }
        public User User { get; set; }
    }
}
