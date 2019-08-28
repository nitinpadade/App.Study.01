using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Details
{
    public class PostDetails
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public bool IsPublished { get; set; }
    }
}
