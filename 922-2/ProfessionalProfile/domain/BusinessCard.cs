using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class BussinesCard
    {
        private int bcId;
        private int userId;
        private string summary;
        private string uniqueUrl;
        private List<Skill> keySkills;

        public BussinesCard(int bcId, string summary, string uniqueUrl, int userId, List<Skill> keySkills)
        {
            this.bcId = bcId;
            this.summary = summary;
            this.keySkills = keySkills;
            this.uniqueUrl = uniqueUrl;
            this.userId = userId;
        }

        public int BcId
        {
            get { return bcId; }
            set { bcId = value; }
        }

        public string Summary
        {
            get { return summary; }
            set { summary = value; }
        }

        public List<Skill> KeySkills
        {
            get { return keySkills; }
            set { this.keySkills = value; }
        }
        public string UniqueUrl
        {
            get { return uniqueUrl; }
            set { uniqueUrl = value; }
        }

        public int UserId
        {
            get { return userId; }
            set { this.userId = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is BussinesCard card &&
                   bcId == card.bcId &&
                   summary == card.summary &&
                   EqualityComparer<List<Skill>>.Default.Equals(keySkills, card.keySkills) &&
                   uniqueUrl == card.uniqueUrl &&
                   BcId == card.BcId &&
                   Summary == card.Summary &&
                   EqualityComparer<List<Skill>>.Default.Equals(KeySkills, card.KeySkills) &&
                   UniqueUrl == card.UniqueUrl;
        }
    }
}
