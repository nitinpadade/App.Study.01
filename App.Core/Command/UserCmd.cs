using App.Core.ViewModels;
using App.Data;
using App.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Command
{
    public class UserCmd : ICmd<UserCmdModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;

        public UserCmd(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
        }

        public void Execute(UserCmdModel entity)
        {
            switch (entity.ActionId)
            {
                case 1:
                    this.Insert(entity);
                    break;
                case 2:
                    this.Modify(entity);
                    break;
                case 3:
                    this.Remove(entity.Id);
                    break;
            }
        }

        void Insert(UserCmdModel entity)
        {
            var userEntity = new User
            {
                Name = entity.Firstname + " " + entity.Lastname,
                RoleId = entity.RoleId,
                Email = entity.Email,
                Password = entity.Password
            };

            _userRepository.Add(userEntity);
            _unitOfWork.Commit();
        }

        void Modify(UserCmdModel entity)
        {
            var usertoModify = _userRepository.Find(n => n.Id == entity.Id).FirstOrDefault();
            usertoModify.Name = entity.Firstname + " " + entity.Lastname;
            usertoModify.RoleId = entity.RoleId;
            usertoModify.Email = entity.Email;
            usertoModify.Password = entity.Password;
            _userRepository.Update(usertoModify);
            _unitOfWork.Commit();
        }

        void Remove(int id)
        {
            var usertoDelete = _userRepository.Find(n => n.Id == id).FirstOrDefault();
            _userRepository.Delete(usertoDelete);
            _unitOfWork.Commit();
        }        
    }
}
