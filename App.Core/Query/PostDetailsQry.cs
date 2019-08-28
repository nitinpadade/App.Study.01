using App.Core.Details;
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
    public class PostDetailsQry : IQryWithParameters<PostDetails, PostDetailsParameters>
    {
        public readonly IRepository<Post> _postRepository;

        public PostDetailsQry(IUnitOfWork unitOfWork)
        {
            _postRepository = unitOfWork.GetRepository<Post>();
        }

        public PostDetails Execute(PostDetailsParameters parameters)
        {
            return _postRepository.Find(n => n.Id == parameters.PostId).Select(n => new PostDetails
            {
                CategoryId = n.CategoryId,
                Id = n.Id,
                Title = n.Title,
                Details = n.Details,
                IsPublished = (bool)n.IsPublished
            }).FirstOrDefault();
        }
    }
}
