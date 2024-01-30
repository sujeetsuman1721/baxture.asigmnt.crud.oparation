using baxture.asigmnt.crud.oparation.domain.Models;
using baxture.asigmnt.crud.oparation.domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baxture.asigmnt.crud.oparation.persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<bool> CreateUser(RegisterUser registerUser)
        {
            throw new NotImplementedException();
        }
    }
}
