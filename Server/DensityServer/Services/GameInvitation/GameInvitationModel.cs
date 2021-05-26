using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DensityServer.Services
{
    [Table("GameInvitation", Schema = "GameInvitations")]
    public class GameInvitationModel
    {
       public Guid Id { get; set; }

        public string EmailTo { get; set; }

        public string InvitedBy { get; set; }
    }
}