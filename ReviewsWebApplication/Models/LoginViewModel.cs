﻿namespace ReviewsWebApplication.Models;

public class LoginViewModel
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    public int Id { get; set; }
        
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string? UserName { get; set; }
        
    /// <summary>
    /// Пароль пользователя
    /// </summary>
    public string? Password { get; set; }
}