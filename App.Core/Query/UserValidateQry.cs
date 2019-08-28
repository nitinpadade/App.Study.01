using App.Core.Parameters;
using App.Core.ViewModels;
using App.Data;
using App.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Query
{
    public class UserValidateQry : IQryWithParameters<UserData, ValidationParameters>
    {

        public readonly IRepository<User> _userRepository;
        public readonly IRepository<Role> _rolesRepository;

        public UserValidateQry(IUnitOfWork unitOfWork)
        {
            _userRepository = unitOfWork.GetRepository<User>();
            _rolesRepository = unitOfWork.GetRepository<Role>();
        }

        public UserData Execute(ValidationParameters parameters)
        {
            var hasUser = _userRepository.Find(n => n.Email.Equals(parameters.Email) && n.Password.Equals(parameters.Password)).FirstOrDefault();
            if (hasUser != null)
            {
                var _roles = _rolesRepository.All().ToList();
                return new UserData
                {
                    IsAuthenticated = true,
                    Roles = _roles.Select(n => n.Id.ToString()).ToArray(),
                    Name = hasUser.Name,
                    RoleId = hasUser.RoleId,
                    Role = hasUser.Role.Name,
                    Email = hasUser.Email,
                    UserId = hasUser.Id
                };
            }
            return new UserData { IsAuthenticated = false };
        }
    }
}
