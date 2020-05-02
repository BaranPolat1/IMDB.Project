using IMDB.DAL.Context;
using IMDB.DAL.Repository.Abstract;
using IMDB.DAL.Repository.BaseRepositoryEF;
using IMDB.Entites.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDB.DAL.Repository.Concrete
{
    public class AppUserRepositoryEF : EntityRepositoryEF<AppUser, ProjectContext>, IAppUserRepository
    {

        public ICollection<AppUser> GetByRole(string Id)
        {
            using (var db = new ProjectContext())
            {
                var result = db.UserRoles.Where(x => x.RoleId == Id);
                List<AppUser> appUsers = new List<AppUser>();
                foreach (var item in result)
                {
                    appUsers.AddRange(db.Users.Where(x => x.Id == item.UserId));
                }
                return appUsers;
            }

        }
    }
}
