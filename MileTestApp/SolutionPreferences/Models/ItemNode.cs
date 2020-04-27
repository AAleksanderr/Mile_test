using System.Collections.Generic;

namespace SolutionPreferences.Models
{
    public class ItemNode
    {
        public List<ItemNode> ChildNodes = new List<ItemNode>();
        public string Id { get; set; }
        public string Value { get; set; }
        public ItemNode ParentNode { get; set; }
    }
}