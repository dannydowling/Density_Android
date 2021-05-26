﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DensityServer.ModelsandRepositories.GameInvitation
{
    public class GameInvitationModel
    {
        public Guid Id { get; set; }
        public string EmailTo { get; set; }
        public string InvitedBy { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime ConfirmationDate { get; set; }

    }
}
