﻿using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IEmailSender
    {
        Task SendWelcomeEmailAsync(string email, string subject);
    }
}
