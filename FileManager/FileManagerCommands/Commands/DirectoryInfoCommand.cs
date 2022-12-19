using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCommands.Commands
{
    internal class DirectoryInfoCommand : ICommand
    {
        public string CommandInfo() => "Выводит информацию о директории";

        public List<string> CommandNames() => new List<string> { "dir_info" };

        public string Execute(Manager manager, string[] args)
        {
            string arg = "";
            if (args.Length > 0) arg = args[0];

            string path = manager.GetDirectoryPath(arg);

            if (path != "")
            {
                DirectoryInfo info = new DirectoryInfo(path);
                return $"\nНазвание: {info.Name}\nВремя создания:" +
                    $" {info.CreationTime.ToShortDateString()} {info.CreationTime.ToShortTimeString()}\n" +
                    $"Корневая папка: {info.Root.FullName}\n";
            }

            return "Не найдена директория с таким путём!";
        }
    }
}
