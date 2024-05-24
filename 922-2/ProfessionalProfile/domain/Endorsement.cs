using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class Endorsement
    {
        private int endorsementId;
        private int endorserId;
        private int recipientid;
        private int skillId;

        public Endorsement(int endorsementId, int endorserid, int recipientid, int skillId)
        {
            this.endorsementId = endorsementId;
            this.endorserId = endorserid;
            this.recipientid = recipientid;
            this.skillId = skillId;
        }

        public int EndorsementId
        {
            get { return endorsementId; }

            set { endorsementId = value; }
        }

        public int EdorserId
        {
            get { return endorserId; }
            set { endorserId = value; }
        }

        public int RecipientId
        {
            get { return recipientid; }
            set { this.recipientid = value; }
        }

        public int SkillId
        {
            get { return skillId; }
            set { skillId = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is Endorsement endorsement &&
                   endorsementId == endorsement.endorsementId &&
                   endorserId == endorsement.endorserId &&
                   recipientid == endorsement.recipientid &&
                   skillId == endorsement.skillId &&
                   EndorsementId == endorsement.EndorsementId &&
                   EdorserId == endorsement.EdorserId &&
                   RecipientId == endorsement.RecipientId &&
                   SkillId == endorsement.SkillId;
        }
    }
}
