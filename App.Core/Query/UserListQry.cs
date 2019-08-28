using App.Core.List;
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
    public class UserListQry : IQryWithParameters<UsersList, UserListParameters>
    {

        public readonly IRepository<User> _userRepository;
        public readonly IRepository<Role> _rolesRepository;

        public UserListQry(IUnitOfWork unitOfWork)
        {
            _userRepository = unitOfWork.GetRepository<User>();
            _rolesRepository = unitOfWork.GetRepository<Role>();
        }

        public UsersList Execute(UserListParameters parameters)
        {
            return new UsersList
             {
                 Result = _userRepository.Find(n => n.RoleId != 1).Select(n => new UserListModel
                 {
                     Id = n.Id,
                     Name = n.Name,
                     Email = n.Email,
                     Role = n.Role.Name,
                     RoleId = n.RoleId
                 }).ToList()
             };
        }
    }
}
