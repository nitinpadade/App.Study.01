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
    public class PostCmd : ICmd<PostCmdModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Post> _postRepository;

        public PostCmd(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _postRepository = _unitOfWork.GetRepository<Post>();
        }

        public void Execute(PostCmdModel entity)
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

        void Insert(PostCmdModel entity)
        {
            var postEntity = new Post
            {
                Title = entity.Title,
                CategoryId = entity.CategoryId,
                Details = entity.Details,
                IsPublished = entity.IsPublished,
                PostedBy = entity.PostedBy,
                PostedOn = System.DateTime.Now
            };

            _postRepository.Add(postEntity);
            _unitOfWork.Commit();
        }

        void Modify(PostCmdModel entity)
        {
            var post2Modify = _postRepository.Find(n => n.Id == entity.Id).FirstOrDefault();
            post2Modify.Title = entity.Title;
            post2Modify.CategoryId = entity.CategoryId;
            post2Modify.Details = entity.Details;
            post2Modify.IsPublished = entity.IsPublished;

            _postRepository.Update(post2Modify);
            _unitOfWork.Commit();
        }

        void Remove(int id)
        {
            var post2Delete = _postRepository.Find(n => n.Id == id).FirstOrDefault();
            _postRepository.Delete(post2Delete);
            _unitOfWork.Commit();
        }
    }
}
