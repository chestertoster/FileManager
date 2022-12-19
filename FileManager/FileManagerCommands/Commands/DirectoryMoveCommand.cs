using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCommands.Commands
{
    internal class DirectoryMoveCommand : ICommand
    {
        public string CommandInfo() => "Перемещает директорию с файлами в указанный путь";

        public List<string> CommandNames() => new List<string> { "dir_move" };

        public string Execute(Manager manager, string[] args)
        {
            if (args.Length < 2) return "Ошибка!";

            string pathFrom = manager.GetDirectoryPath(args[0]);
            string pathTo = manager.GetDirectoryPath(args[1]);

            if (pathFrom == "" || pathTo == "")
                return "Не найдена директория с таким путём!";

            if (MoveDirectory(pathFrom, pathTo))
                return "Директория успешно перенесена!";

            return "Не найдена директория с таким путём!";
        }

        //Перемещает директорию
        private static bool MoveDirectory(string sourceDir, string destinationDir)
        {
            var dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
                return false;

            DirectoryInfo[] dirs = dir.GetDirectories();

            try
            {
                dir.MoveTo(Path.Combine(destinationDir, dir.Name));
                if (Directory.Exists(sourceDir))
                    Directory.Delete(sourceDir, true);
            }
            catch { return false; }

            return true;
        }
    }
}
