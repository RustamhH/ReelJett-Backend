﻿namespace ReelJett.Domain.ViewModels;

public class GetAccountData {

    // Fields

    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public string ProfilePhoto { get; set; }
    public string Error { get; set; } = "";
}
