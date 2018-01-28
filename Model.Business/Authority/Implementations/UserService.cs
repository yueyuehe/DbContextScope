using Mehdime.Entity.Extension;
using Model.Entity.Authority;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Business.Authority
{
    public class UserService : BasicBLL<User,AuthorityContainer> , IUserService
    {


    }
}
