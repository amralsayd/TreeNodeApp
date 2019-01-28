using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TreeNodeApp.Models
{
    public class TreeNode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int node_id { set; get; }
        public int? node_parent_id { set; get; }
        public string node_name_ar { set; get; }
        public string node_name_en { set; get; }
        public string node_url { set; get; }
        [ForeignKey("node_parent_id")]
        public virtual TreeNode ParentNode { set; get; }
        public virtual ICollection<TreeNode> TreeNodeChilds { set; get; }
    }
}