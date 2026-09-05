using System;
using AutomationTests.Interfaces;

namespace AutomationTests.Repositories;

public class UserNotifier
{
    private readonly IEmailSender _emailSender;

    public UserNotifier(IEmailSender emailSender)
    {
        _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
    }

    public void Notify(int userId)
    {
        _emailSender.Send("user@mail.com", $"Hello, user {userId}!");
    }
}