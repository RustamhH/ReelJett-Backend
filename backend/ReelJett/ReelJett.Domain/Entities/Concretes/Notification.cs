namespace ReelJett.Domain.Entities.Concretes;

public class Notification : BaseEntity {

    // Fields

    public string Message { get; set; }
    public string SenderName { get; set; }
    public string SendingTime { get; set; }
    public string SenderPhoto { get; set; }
    public string ReceiverName { get; set; }
    public bool IsRead { get; set; } = false;
}

// ** NOTE **

// paylasilan videoya like atmaq 1 userin digerine gonderdiyi notificaiondur. Adminin 1 usere gonderdiyi her hansi notification (for example)
// adminin butun userlere gonderdiyi mesaj toplu mesajdir.