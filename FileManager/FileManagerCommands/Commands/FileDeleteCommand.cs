using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCommands.Commands
{
    internal class FileDeleteCommand : ICommand
    {
        public string CommandInfo() => "Удаляет файл по указанному пути";

        public List<string> CommandNames() => new List<string> { "f_del" };

        public string Execute(Manager manager, string[] args)
        {
            if (args.Length < 1) return "Ошибка!";

            string path = manager.GetFilePath(args[0]);

            if (path != "")
            {
                try
                {
                    FileInfo info = new FileInfo(path);
                    info.Delete();
                    return "Файл успешно удален!";
                }
                catch 
                {
                    return "Возникли ошибки при удалении файла!";
                }
            }

            return "Не найден файл с таким путём!";
        }
    }
}
