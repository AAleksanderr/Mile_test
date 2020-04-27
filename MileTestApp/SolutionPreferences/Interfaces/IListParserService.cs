using System.Collections.Generic;
using SolutionPreferences.Models;

namespace SolutionPreferences.Interfaces
{
    public interface IListParserService
    {
        Dictionary<string, string> Parse(string itemsList);
        ItemNode CreateItemNode(Dictionary<string, string> data);
    }
}