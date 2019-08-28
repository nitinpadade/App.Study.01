using App.Core.List;
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
    public class CategoryListQry : IQryWithoutParameters<CategoryList>
    {
        public readonly IRepository<Category> _catRepository;

        public CategoryListQry(IUnitOfWork unitOfWork)
        {
            _catRepository = unitOfWork.GetRepository<Category>();
        }

        public CategoryList Execute()
        {
            return new CategoryList
            {
                Categories = _catRepository.All().Select(n => new CategoryListModel
                {
                    Id = n.Id,
                    Name = n.Name
                }).ToList()
            };
        }
    }
}
