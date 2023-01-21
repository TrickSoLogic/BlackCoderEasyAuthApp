using AspNetCoreAuth.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreAuth.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>
        {
            new User{Id=1,Name="ahasan",Password="jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=",
            FavoriteColor="Green",Role="Admin",GoogleId="116353184118060494413"},
             new User{Id=2,Name="zayn",Password="jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=",
            FavoriteColor="Green",Role="User",GoogleId="101517359495305583936"},
        };//Pass:123456
        public User GetByUsernameAndPassword(string username,string password) 
        {
                        
            var user = users.SingleOrDefault(u=>u.Name==username && u.Password==password.Sha256());
            return user;
        }
        public User GetByGoogleId(string googleId) 
        {
            var user=users.SingleOrDefault(u=>u.GoogleId==googleId);
            return user;
        }
    }
}
