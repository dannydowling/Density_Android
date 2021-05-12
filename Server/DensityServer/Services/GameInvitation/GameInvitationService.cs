﻿using DensityServer.Services.GameInvitation;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DensityServer.Services
{
    public class GameInvitationService : IGameInvitationService
    {
        private static ConcurrentBag<GameInvitationModel> _gameInvitations;
        public GameInvitationService()
        {
            _gameInvitations = new ConcurrentBag<GameInvitationModel>();
        }

        public Task<GameInvitationModel> Add (GameInvitationModel gameInvitationModel)
        {
            gameInvitationModel.Id = Guid.NewGuid();
            _gameInvitations.Add(gameInvitationModel);
            return Task.FromResult(gameInvitationModel);
        }

        public Task Update(GameInvitationModel gameInvitationModel)
        {
            _gameInvitations = new ConcurrentBag<GameInvitationModel>(_gameInvitations.Where(x => x.Id != gameInvitationModel.Id))
            {
                gameInvitationModel
            };
            return Task.CompletedTask;
        }

        public Task<GameInvitationModel> Get (Guid Id)
        {
            return Task.FromResult(_gameInvitations.Single(x => x.Id == Id));
        } 
    }
}
