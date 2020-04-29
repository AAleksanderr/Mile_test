using System;
using System.Collections.Generic;
using System.Linq;
using DbStoreService;
using ListParserService;
using ListSourceService;
using SolutionPreferences.Models;

namespace MileTestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string list;
            try
            {
                list = new SourceService().GetList();
            }
            catch
            {
                Console.WriteLine("Ошибка получения списка.");
                return;
            }

            ParserService parser;
            Dictionary<string, string> parsedList;
            try
            {
                parser = new ParserService();
                parsedList = parser.Parse(list);
            }
            catch
            {
                Console.WriteLine("Не правильный формат списка.");
                return;
            }

            ItemNode itemNode;
            try
            {
                itemNode = parser.CreateItemNode(parsedList);
            }
            catch
            {
                Console.WriteLine("Ошибка создания дерева списка.");
                return;
            }
            
            MsSqlStorageService storage;
            try
            {
                storage = new MsSqlStorageService();
                storage.UploadData(itemNode);
            }
            catch
            {
                Console.WriteLine("Ошибка записи в базу данных.");
                return;
            }

            List<string> parentKeys;
            try
            {
                parentKeys = storage.ReadAll().Select(i => i.ParentId).ToList();
            }
            catch
            {
                Console.WriteLine("Ошибка получения первичных ключей.");
                return;
            }

            Console.WriteLine("Список первичных ключей:");
            foreach (var key in parentKeys) Console.WriteLine(key);

            Console.ReadLine();
        }
    }
}