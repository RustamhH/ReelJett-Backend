using ReelJett.Domain.DTO;
using Microsoft.AspNetCore.SignalR;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;

namespace ReelJett.Infrastructure.Hubs;

public class NotificationHub : Hub {

    // Fields

    private readonly IReadUserRepository _readUserRepository;

    // Constructor

    public NotificationHub(IReadUserRepository readUserRepository) {
        _readUserRepository = readUserRepository;
    }

    public override async Task OnConnectedAsync() {
        var userId = Context.UserIdentifier;
        await base.OnConnectedAsync();
    }

    public async Task SendNotificationToUser(SendNotificationDTO sendNotificationDTO) {

        var receiver = await _readUserRepository.GetUserByUserName(sendNotificationDTO.ReceiverName);
        if (receiver == null) {
            throw new ArgumentException("Receiver not found");
        }

        var notification = new Notification {

            ReceiverName = sendNotificationDTO.ReceiverName,
            Message = sendNotificationDTO.Message,
            SenderName = "Admin", // Use UserManager to get the sender name if necessary
        };

        var receiverId = receiver.Id;
        if (string.IsNullOrEmpty(receiverId)) {
            throw new ArgumentException("Receiver ID is null or empty");
        }

        await Clients.User(receiverId).SendAsync("ReceiveNotification", notification);
    }

    public async Task SendNotificationToAll(SendNotificationDTO sendNotificationDTO) {

        //var allUsers = await _readUserRepository.GetAllAsync();
        //foreach (var user in allUsers)
        //{
        //    if (!string.IsNullOrEmpty(user.Id))
        //    {
        //        await Clients.User(user.Id).SendAsync("ReceiveNotification", notification);
        //    }
        //}

        //await Clients.All.SendAsync("ReceiveNotification", notification);
    }
}