namespace FileManagerCommands.Commands
{
    internal class FileCopyCommand : ICommand
    {
        public string CommandInfo() => "Копирует файл в указанный путь";

        public List<string> CommandNames() => new List<string> { "f_copy" };

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
                File.Copy(pathFrom, filePath, true);
            }
            catch (UnauthorizedAccessException e)
            {
                return "Не удается получить доступ к файлу из-за уровня защиты!";
            }
            catch(Exception e)
            {
                return $"Неудачная попытка скопировать файл! ({e.Message})";
            }

            return "Файл успешно скопирован в указанную директорию";
        }
    }
}