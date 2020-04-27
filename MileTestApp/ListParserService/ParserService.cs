using System;
using System.Collections.Generic;
using System.Linq;
using SolutionPreferences.Interfaces;
using SolutionPreferences.Models;

namespace ListParserService
{
    public class ParserService : IListParserService
    {
        public Dictionary<string, string> Parse(string itemsList)
        {
            var strings = itemsList.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var result = new Dictionary<string, string>();
            for (var i = 0; i < strings.Length / 2; i++)
                result.Add(strings[i * 2], strings[i * 2 + 1]);
            result = result.OrderBy(i => i.Key).ToDictionary(t => t.Key, t => t.Value);

            return result;
        }

        public ItemNode CreateItemNode(Dictionary<string, string> data)
        {
            var firstNode = new ItemNode();
            var keys = data.Keys;
            foreach (var key in keys)
            {
                var resultNode = firstNode;
                var keyTree = key.Split(new[] {'.'}, StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < keyTree.Length-1; i++)
                {
                    var keyTreeToInt = Convert.ToInt32(keyTree[i])-1;
                    resultNode = resultNode.ChildNodes[keyTreeToInt];
                }

                var addingNode = new ItemNode {Id = key, Value = data[key], ParentNode = resultNode};
                resultNode.ChildNodes.Add(addingNode);
            }
            return firstNode;
        }
    }
}