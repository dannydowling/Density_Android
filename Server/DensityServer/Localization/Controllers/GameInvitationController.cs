using DensityServer.Services;
using DensityServer.Services.GameInvitation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Localization;

namespace DensityServer.Controllers
{
    public class GameInvitationController : Controller
    {
        private IStringLocalizer<GameInvitationController> _stringLocalizer;        

        public GameInvitationController(IStringLocalizer<GameInvitationController> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;            
        }

        [HttpPost]
        public IActionResult Index(GameInvitationModel gameInvitationModel)
        {
            return Content(_stringLocalizer["GameInvitationConfirmationMessage", gameInvitationModel.EmailTo]);
        }

        [HttpPost]
        public IActionResult Index(GameInvitationModel gameInvitationModel, [FromServices] IEmailService emailService)
        {
            var gameInvitationService =
                Request.HttpContext.RequestServices.GetService<IGameInvitationService>();
            if (ModelState.IsValid)
            {
                emailService.SendEmail(gameInvitationModel.EmailTo,
                    _stringLocalizer["Invitation for playing a game of Hang from {0}", gameInvitationModel.InvitedBy],
                    _stringLocalizer["Hello, you've been invited to play a game of Hang. To join the game, please click here {0}", Url.Action("GameInvitationConfirmation"),
                    "GameInvitation",
                    new
                    {
                        
                        //make it so that remotesecuritystamp is sent as the value of the identity user security stamp, probably done in the setter...
                        gameInvitationModel.RemoteSecurityStamp,
                        gameInvitationModel.InvitedBy,
                        gameInvitationModel.EmailTo
                    },
                    Request.Scheme,
                    Request.Host.ToString()]);

                var invitation = gameInvitationService.Add(gameInvitationModel).Result;
                return RedirectToAction("GameInvitationConfirmation", new { id = invitation.gameId });
            }
            return View(gameInvitationModel);
        }

        [HttpGet]
        public IActionResult GameInformationConfirmation(Guid id, [FromServices] IGameInvitationService gameInvitationService)
        {
            var gameInvitation = gameInvitationService.Get(id).Result;
            return View(gameInvitation);
        }
    }
}
