using System;
using System.Collections.Generic;
using System.Linq;
using SolutionPreferences.Interfaces;
using SolutionPreferences.Models;

namespace DbStoreService
{
    public class MsSqlStorageService : IStorageService
    {
        private readonly ListItemContext _context = new ListItemContext();

        public void Create(ListItem listItem)
        {
            listItem.Id = -1;
            if (!_context.Items.Any())
                _context.Items.Add(listItem);
            else if (!_context.Items.Any(i => i.Tree.TreeId == listItem.Tree.TreeId))
                _context.Items.Add(listItem);
            _context.SaveChanges();
        }

        public IEnumerable<ListItem> ReadAll()
        {
            return _context.Items.ToList();
        }

        public ListItem ReadByTreeId(string treeId)
        {
            if (_context.Items.Any())
                return _context.Items.Single(i => i.Tree.TreeId == treeId);
            return null;
        }

        public void Update(ListItem item)
        {
            var res = _context.Items.Single(i => i.Id == item.Id);
            res.Tree = item.Tree;
            _context.SaveChanges();
        }

        public void Delete(ListItem item)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();
        }

        public void DeleteByTreeId(string treeId)
        {
            if (_context.Items.Any())
                Delete(_context.Items.Single(i => i.Tree.TreeId == treeId));
        }

        public void UploadData(ItemNode firstNode)
        {
            AddNodeRecursive("", firstNode);
        }

        private void AddNodeRecursive(string parentItem, ItemNode node)
        {
            var newItem = new ListItem
            {
                ParentId = parentItem,
                Tree = new Tree { TreeId = node.Id, Name = node.Value}
            };

            foreach (var child in node.ChildNodes)
                AddNodeRecursive(newItem.Tree.TreeId, child);
            if (parentItem != "")
                Create(newItem);
        }
    }
}