using SolutionPreferences.Interfaces;

namespace ListSourceService
{
    public class SourceService : IListSourceService
    {
        public string GetList()
        {
            return @"1. Шторы
            1.1 Двери
            1.3 Окна
            1.2 Пальмы
            2. Цемент
            2.2 Краска
            2.1 Плодовые
            2.1.2 Монеты
            2.1.1 Скатерть";
        }
    }
}