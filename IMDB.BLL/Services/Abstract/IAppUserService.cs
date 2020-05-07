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
        void Add(UserDTO model);
        void Update(UserDTO model);
        void Delete(string Id);
        AppUser GetById(string Id);
        ICollection<UserDTO> GetList();
        ICollection<UserDTO> GetByRole(string Id);
        ICollection<UserDTO> GetByMovie(int Id);
    }
}
