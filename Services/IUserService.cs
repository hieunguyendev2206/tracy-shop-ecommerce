﻿namespace TracyShop.Services
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}