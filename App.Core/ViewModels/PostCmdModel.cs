using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ViewModels
{
    public class PostCmdModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Required")]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Title Required")]
        [DisplayName("Title")]
        public string Title { get; set; }

        public string Details { get; set; }

        public bool IsPublished { get; set; }

        public Nullable<int> PostedBy { get; set; }

        public Nullable<DateTime> PostedOn { get; set; }

        public List<CategoryListModel> Categories { get; set; }

        public int ActionId { get; set; }
    }
}
