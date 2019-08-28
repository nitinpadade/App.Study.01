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
    public class PostTitleListQry : IQryWithParameters<PostTitleList, PostTitleListParameters>
    {
        public readonly IRepository<Post> _postRepository;

        public PostTitleListQry(IUnitOfWork unitOfWork)
        {
            _postRepository = unitOfWork.GetRepository<Post>();
        }

        public PostTitleList Execute(PostTitleListParameters parameters)
        {
            if (parameters.CategoryId > 0)
            {
                return new PostTitleList
                {
                    PostTitles = _postRepository.Find(n => n.CategoryId == parameters.CategoryId).Select(n => new PostTitleModel
                    {
                        Id = n.Id,
                        Title = n.Title
                    }).OrderByDescending(n => n.Id).ToList()
                };
            }
            else
            {
                return new PostTitleList
                {
                    PostTitles = _postRepository.All().Select(n => new PostTitleModel
                    {
                        Id = n.Id,
                        Title = n.Title
                    }).OrderByDescending(n => n.Id).ToList()
                };
            }

        }
    }
}
