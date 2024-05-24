using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class Volunteering
    {
        private int volunteeringId;
        private int userId;
        private string organisation;
        private string role;
        private string description;

        public Volunteering(int volunteeringId, int userId, string organisation, string role, string description)
        {
            this.volunteeringId = volunteeringId;
            this.organisation = organisation;
            this.role = role;
            this.description = description;
            this.userId = userId;
        }

        public int VolunteeringId
        {
            get { return volunteeringId; } set { this.volunteeringId = value; }
        }

        public string Organisation
        {
            get { return organisation; } set { this.organisation = value; }
        }

        public string Role
        {
            get { return role; } set { this.role = value; }
        }

        public string Description
        {
            get { return description; } set { this.description = value; }
        }

        public int UserId
        {
            get { return userId; } set { userId = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is Volunteering volunteering &&
                   volunteeringId == volunteering.volunteeringId &&
                   organisation == volunteering.organisation &&
                   role == volunteering.role &&
                   description == volunteering.description &&
                   userId == volunteering.userId &&
                   VolunteeringId == volunteering.VolunteeringId &&
                   Organisation == volunteering.Organisation &&
                   Role == volunteering.Role &&
                   Description == volunteering.Description &&
                   UserId == volunteering.UserId;
        }

        public override string ToString()
        {
            return role + "\n" + organisation + "\n" + description;
        }
    }
}
