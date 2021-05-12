using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DensityServer.Services.GameInvitation
{
    public interface IGameInvitationService
    {
        Task<GameInvitationModel> Add(GameInvitationModel gameInvitationModel);

        Task Update(GameInvitationModel gameInvitationModel);

        Task<GameInvitationModel> Get(Guid Id);
    }
}
