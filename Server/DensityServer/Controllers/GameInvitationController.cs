using DensityServer.Services;
using DensityServer.Services.GameInvitation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using System;


namespace DensityServer.Controllers
{
    public class GameInvitationController : Controller
    {        
        [HttpPost]
            public IActionResult Index(GameInvitationModel gameInvitationModel, [FromServices]IEmailService emailService)
        {
            var gameInvitationService = 
                Request.HttpContext.RequestServices.GetService<IGameInvitationService>();
            if (ModelState.IsValid)
            {
                emailService.SendEmail(gameInvitationModel.EmailTo, _stringLocalizer["Invitation for playing a game of Hang from {0}, to join the game, please click here {1}", gameInvitationModel.InvitedBy, Url.Action("GameInvitationConfirmation", "GameInvitation", new { gameInvitationModel.InvitedBy, gameInvitationModel.EmailTo }, Request.Scheme, Request.Host.ToString())]);

                var invitation = gameInvitationService.Add(gameInvitationModel).Result;
                return RedirectToAction("GameInvitationConfirmation", new { id = invitation.Id });
            }
            return View(gameInvitationModel);
        }

        [HttpGet]
        public IActionResult GameInformationConfirmation (Guid id, [FromServices] IGameInvitationService gameInvitationService)
        {
            var gameInvitation = gameInvitationService.Get(id).Result;
            return View(gameInvitation);
        }
    }
}
