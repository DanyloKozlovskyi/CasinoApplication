﻿using AutoMapper;
using Casino.DataAccess.Dtos;
using Casino.DataAccess.MenuVoting.DataAccess;
using Casino.DataAccess.Models;
using Casino.DataAccess.Repository;
using Casino.Util;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Core;

namespace Casino.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;
        private readonly IMapper mapper;

        public UsersService(IUsersRepository _usersRepository)
        {
            usersRepository = _usersRepository;

            var map = new MapperConfiguration
            (
                mc => mc.AddProfile(new MappingProfile())
            );
            mapper = map.CreateMapper();
        }
        public async Task<User> AddUser(UserCreate? userCreate)
        {
            if (userCreate == null)
                throw new ArgumentNullException(nameof(UserCreate));

            User user = mapper.Map<User>(userCreate);
            await usersRepository.AddUser(user);
            return user;
        }

        public async Task DeleteUser(Guid id)
        {
            bool checkExist = await usersRepository.UserExists(id);
            if (!checkExist)
                throw new ArgumentException($"User with Id = {id} doesn't exist in the system.");

            await usersRepository.DeleteUser(id);
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await usersRepository.GetUserById(id);
        }

        public async Task<ICollection<User>> GetUsers()
        {
            return await usersRepository.GetUsers();
        }

        public async Task<User> UpdateUser(User user)
        {
            bool checkExist = await usersRepository.UserExists(user.Id);

            if (!checkExist)
                throw new ArgumentException(nameof(user));

            User modifiedUser = await usersRepository.UpdateUser(user);

            return modifiedUser;
        }

        public async Task<ICollection<User>> GetPage(int page, int pageSize)
        {
            return await usersRepository.GetPage(page, pageSize);
        }

        public async Task<int> CountUsers()
        {
            return await usersRepository.CountUsers();
        }

    }
}
