using IMDB.BLL.Services.Abstract;
using IMDB.BLL.ValueInjecter;
using IMDB.DAL.Context;
using IMDB.DAL.Repository.Abstract;
using IMDB.Entites.Entity;
using IMDB.Infrastructure.DTO;
using Microsoft.AspNetCore.Identity;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.BLL.Services.Concrete
{
    public class AppUserService : IAppUserService
    {
        
        private IAppUserRepository userRepository;
        public AppUserService(IAppUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public void Add(UserDTO user)
        {
            AppUser appUser = new AppUser();
            appUser.InjectFrom(user);
            userRepository.Add(appUser);
        }

        public void Delete(AppUser user)
        {
            userRepository.Delete(user);
        }

        public AppUser GetById(string Id)
        {
            return userRepository.Get(x => x.Id == Id);
        }

        public ICollection<UserDTO> GetByRole(string Id)
        {  
            var user = userRepository.GetByRole(Id);
            List<UserDTO> users = new List<UserDTO>();
            users.InjectFrom(user);
            return users;
        }

        public ICollection<UserDTO> GetList()
        {
            var user = userRepository.GetList();
            List<UserDTO> users = new List<UserDTO>();
            users.InjectFrom(user);
            return users;
        }


        public void Update(UserDTO user)
        {
            AppUser appUser = userRepository.Get(x => x.Id == user.Id);
            appUser.InjectFrom<FilterId>(user);
            userRepository.Update(appUser);
            
        }
    }
}
