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
    public class CategoryCmd : ICmd<CategoryCmdModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Category> _catRepository;

        public CategoryCmd(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _catRepository = _unitOfWork.GetRepository<Category>();
        }

        public void Execute(CategoryCmdModel entity)
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

        void Insert(CategoryCmdModel entity)
        {
            var catEntity = new Category
            {
                Name = entity.Name
            };

            _catRepository.Add(catEntity);
            _unitOfWork.Commit();
        }

        void Modify(CategoryCmdModel entity)
        {
            var cattoModify = _catRepository.Find(n => n.Id == entity.Id).FirstOrDefault();
            cattoModify.Name = entity.Name;
            _catRepository.Update(cattoModify);
            _unitOfWork.Commit();
        }

        void Remove(int id)
        {
            var cattoDelete = _catRepository.Find(n => n.Id == id).FirstOrDefault();
            _catRepository.Delete(cattoDelete);
            _unitOfWork.Commit();
        }        
    }
}
