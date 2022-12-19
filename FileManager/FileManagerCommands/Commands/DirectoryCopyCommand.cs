namespace FileManagerCommands.Commands
{
    internal class DirectoryCopyCommand : ICommand
    {
        public string CommandInfo() => "Копирует директорию с файлами в указанный путь";

        public List<string> CommandNames() => new List<string> { "dir_copy" };

        public string Execute(Manager manager, string[] args)
        {
            if (args.Length < 2) return "Ошибка!";

            string pathFrom = manager.GetDirectoryPath(args[0]);
            string pathTo = manager.GetDirectoryPath(args[1]);

            if (pathFrom == "" || pathTo == "")
                return "Не найдена директория с таким путём!";

            if (CopyDirectory(pathFrom, pathTo))
                return "Директория успешно скопирована!";

            return "Не найдена директория с таким путём!";
        }

        //Копирует директорию
        private static bool CopyDirectory(string sourceDir, string destinationDir)
        {
            var dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
                return false;

            DirectoryInfo[] dirs = dir.GetDirectories();

            try
            {
                Directory.CreateDirectory(destinationDir);

                foreach (FileInfo file in dir.GetFiles())
                {
                    string targetFilePath = Path.Combine(destinationDir, file.Name);
                    file.CopyTo(targetFilePath);
                }

                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir);
                }
            }
            catch { return false; }

            return true;
        }
    }
}