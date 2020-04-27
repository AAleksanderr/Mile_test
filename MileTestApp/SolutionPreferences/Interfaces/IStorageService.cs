using System.Collections.Generic;
using SolutionPreferences.Models;

namespace SolutionPreferences.Interfaces
{
    public interface IStorageService
    {
        void Create(ListItem listItem);
        IEnumerable<ListItem> ReadAll();
        ListItem ReadByTreeId(string treeId);
        void Update(ListItem item);
        void Delete(ListItem item);
        void DeleteByTreeId(string treeId);
    }
}