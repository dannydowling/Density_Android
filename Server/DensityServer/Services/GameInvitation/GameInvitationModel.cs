using System;

namespace DensityServer.Services
{
    public class GameInvitationModel
    {
       public Guid Id { get; set; }

        public string EmailTo { get; set; }

        public string InvitedBy { get; set; }
    }
}