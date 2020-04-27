using DbStoreService;
using ListParserService;
using ListSourceService;

namespace MileTestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var list = new SourceService().GetList();
            var parser = new ParserService();
            var parsedList = parser.Parse(list);
            var itemNode = parser.CreateItemNode(parsedList);
            var storage = new MsSqlStorageService();
            storage.UploadData(itemNode);


        }
    }
}