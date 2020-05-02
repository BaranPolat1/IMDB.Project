using IMDB.Entites.Entity;
using IMDB.Infrastructure.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.BLL.Services.Abstract
{
   public interface IAppUserService
    {
        void Add(UserDTO user);
        void Update(UserDTO user);
        void Delete(AppUser user);
        AppUser GetById(string Id);
        ICollection<UserDTO> GetList();
        ICollection<UserDTO> GetByRole(string Id);
    }
}
