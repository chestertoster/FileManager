using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCommands.Commands
{
    internal class FileMoveCommand : ICommand
    {
        public string CommandInfo() => "Перемещает файл в указанный путь";

        public List<string> CommandNames() => new List<string> { "f_move" };

        public string Execute(Manager manager, string[] args)
        {
            if (args.Length < 2) return "Ошибка! Недостаточно аргументов.";

            string pathFrom = manager.GetFilePath(args[0]);
            string pathTo = manager.GetDirectoryPath(args[1]);

            if (pathFrom == "" || pathTo == "")
                return "Не найдена директория с таким путём!";

            FileInfo info = new FileInfo(pathFrom);
            try
            {
                string filePath = Path.Combine(pathTo, info.Name);
                File.Move(pathFrom, filePath, true);
            }
            catch (UnauthorizedAccessException e)
            {
                return "Не удается получить доступ к файлу из-за уровня защиты!";
            }
            catch
            {
                return "Неудачная попытка перенести файл!";
            }

            return "Файл успешно перенесен в указанную директорию";
        }
    }
}
