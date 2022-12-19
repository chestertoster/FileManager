using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCommands.Commands
{
    internal class DirectoryDeleteCommand : ICommand
    {
        public string CommandInfo() => "Удаляет директорию по указанному пути";

        public List<string> CommandNames() => new List<string> { "dir_del" };

        public string Execute(Manager manager, string[] args)
        {
            if (args.Length < 1 || args[0].Trim() == "") return "Введите путь к директории!";

            string path = manager.GetDirectoryPath(args[0]);

            if (path != "")
            {
                DirectoryInfo info = new DirectoryInfo(path);
                info.Delete(true);
                return "Директория успешно удалена!";
            }

            return "Не найдена директория с таким путём!";
        }
    }
}