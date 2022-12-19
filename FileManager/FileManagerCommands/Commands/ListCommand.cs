using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCommands.Commands
{
    internal class ListCommand : ICommand
    {
        public string CommandInfo() => "Показывает файлы и папки в текущей директории";
        public List<string> CommandNames() => new List<string>() { "list", "ls" };

        public string Execute(Manager manager, string[] args)
        {
            StringBuilder result = new();
            DirectoryInfo info = new DirectoryInfo(manager.RelativePath);

            result.AppendLine();

            foreach (var directory in info.GetDirectories())
                result.AppendLine(directory.Name + "/");

            foreach (var file in info.GetFiles())
                result.AppendLine(file.Name);

            return result.ToString();
        }
    }
}
