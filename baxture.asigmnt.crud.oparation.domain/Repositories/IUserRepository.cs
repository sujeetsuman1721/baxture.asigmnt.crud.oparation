using baxture.asigmnt.crud.oparation.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baxture.asigmnt.crud.oparation.domain.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(RegisterUser registerUser);
    }
}
