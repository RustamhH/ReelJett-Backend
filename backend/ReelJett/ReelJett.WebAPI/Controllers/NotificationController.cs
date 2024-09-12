using ReelJett.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ReelJett.Infrastructure.Hubs;
using ReelJett.Domain.Entities.Concretes;

namespace ReelJett.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase {

    // Fields

    private readonly IHubContext<NotificationHub> _hubContext;

    // Constructor

    public NotificationController(IHubContext<NotificationHub> hubContext) {

        _hubContext = hubContext;
    }

    // Methods

    [HttpPost("SendNotification")]
    public async Task<IActionResult> SendNotificationAsync([FromBody] SendNotificationDTO sendNotificationDTO) {

        if (sendNotificationDTO.ReceiverName != "All") {

            //await _hubContext.SendNotificationToUser(sendNotificationDTO);
        }
        else {

            var currentDateTime = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
            var notification = new Notification {

                ReceiverName = "All",
                Message = sendNotificationDTO.Message,
                SenderName = "Admin",
                SenderPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b5/Windows_10_Default_Profile_Picture.svg/1024px-Windows_10_Default_Profile_Picture.svg.png",
                SendingTime = currentDateTime
            };
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", notification);
        }
        return Ok();
    }
}