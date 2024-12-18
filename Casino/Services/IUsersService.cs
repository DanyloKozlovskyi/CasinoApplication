﻿using Casino.DataAccess.Dtos;
using Casino.DataAccess.Models;
using System.Linq.Expressions;

namespace Casino.Services
{
    public interface IUsersService
    {
        Task<User> AddUser(UserCreate? userCreate);
        Task<ICollection<User>> GetUsers();
        Task<User?> GetUserById(Guid id);
        Task<User> UpdateUser(User user);
        Task DeleteUser(Guid id);
        Task<ICollection<User>> GetPage(int page, int pageSize);
        Task<int> CountUsers();

    }
}
