using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DensityServer.Services
{
    [Table("GameInvitation", Schema = "GameInvitations")]
    public class GameInvitationModel : IdentityUser
    {
        //If we're setting, we're going to send the security stamp off.
        //If we're getting, we're going to need the remote users security stamp.
        //look at GameInvitationConfirmation.cshtml for the script that sets the remote users value.

        IdentityUser user;
        private string _remoteSecurityStamp;

        public string RemoteSecurityStamp
        {
            get { return _remoteSecurityStamp; }
            set { _remoteSecurityStamp = user.SecurityStamp; }
        }

        public Guid gameId { get; set; }

        public string EmailTo { get; set; }

        public string InvitedBy { get; set; }
    }
}