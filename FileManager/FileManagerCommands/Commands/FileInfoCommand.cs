using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCommands.Commands
{
    internal class FileInfoCommand : ICommand
    {
        public string CommandInfo() => "Выводит информацию о файле";

        public List<string> CommandNames() => new List<string> { "f_info" };

        public string Execute(Manager manager, string[] args)
        {
            if (args.Length < 1) return "Ошибка!";

            string path = manager.GetFilePath(args[0]);

            if (path != "")
            {
                FileInfo info = new FileInfo(path);
                return $"\nНазвание: {info.Name}\nВремя создания:" + 
                    $" {info.CreationTime.ToShortDateString()} {info.CreationTime.ToShortTimeString()}\n" + 
                    $"Размер: {info.Length} байт\n";
            }

            return "Не найден файл с таким путём!";
        }
    }
}
