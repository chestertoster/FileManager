using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCommands.Commands
{
    internal class CdCommand : ICommand
    {
        public string CommandInfo() => "Изменяет относительный путь";
        public List<string> CommandNames() => new List<string>() { "cd" };

        public string Execute(Manager manager, string[] args)
        {
            if (args.Length < 1)
                return "Ошибка!";

            string directoryPath = manager.GetDirectoryPath(args[0]);
            if (directoryPath != "")
            {
                manager.RelativePath = directoryPath;
                return "Директория успешно изменена";
            }
            return "Такой директории не существует!";
        }
    }
}
