using AutoMapper;
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
        private IMapper _mapper;
        private IAppUserRepository userRepository;
        
        public AppUserService(IAppUserRepository _userRepository, IMapper mapper)
        {
            _mapper = mapper;
            userRepository = _userRepository;
        }
        public void Add(UserDTO model)
        {
            AppUser appUser = new AppUser();
            appUser.InjectFrom(model);
            userRepository.Add(appUser);
        }

        public void Delete(string Id)
        {
            var user = userRepository.Get(x => x.Id == Id);
            userRepository.Delete(user);
        }
        public AppUser GetById(string Id)
        {
            return userRepository.Get(x => x.Id == Id);
        }

       

        public ICollection<UserDTO> GetByRole(string Id)
        {  
            var user = userRepository.GetByRole(Id);
            List<UserDTO> users = _mapper.Map<List<UserDTO>>(user);
            return users;
        }
        public ICollection<UserDTO> GetList()
        {
            var user = userRepository.GetList();
            List<UserDTO> users = _mapper.Map<List<UserDTO>>(user);
            return users;
        }
        public void Update(UserDTO model)
        {
            AppUser appUser = userRepository.Get(x => x.Id == model.Id);
            appUser.InjectFrom<FilterId>(model);
            userRepository.Update(appUser);
            
        }
        ICollection<UserDTO> IAppUserService.GetByMovie(int Id)
        {
            var user = userRepository.GetByMovie(Id);
            List<UserDTO> model = _mapper.Map<List<UserDTO>>(user);
            return model;
        }
    }
}
