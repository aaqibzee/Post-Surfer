using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Post_Surfer.Domain
{
    public class PostTag
    {
        [ForeignKey(nameof(TagName))]
        public virtual Tag Tag { get; set; }
        [Key]
        public string TagName { get; set; }

        public virtual Post Post { get; set; }

        public Guid PostId { get; set; }
    }
}
