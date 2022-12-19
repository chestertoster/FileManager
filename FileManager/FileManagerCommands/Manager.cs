using FileManagerCommands.Commands;
using System.IO;
using System.Reflection;

namespace FileManagerCommands
{
    public class Manager
    {
        public Manager()
        {
            SetCommandsList();
        }

        private string _relavitePath;
        public string RelativePath 
        { 
            get 
            { 
                if(!Directory.Exists(_relavitePath))
                    _relavitePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                return _relavitePath;
            }
            set 
            {
                _relavitePath = value;
            }
        } 
        private static List<ICommand> _commands = new List<ICommand>();

        //Выгружает из сборки массив команд
        private void SetCommandsList()
        {
            Assembly asm = Assembly.LoadFrom("FileManagerCommands.dll");       // создание сборки из библиотеки классов
            Type[] types = asm.GetTypes();                                     // выгрузка классов в массив
            foreach (Type type in types)                                       // перебираем классы и интерфейсы
            {
                if ((type.IsInterface == false)
                    && (type.IsAbstract == false)
                    && (type.GetInterface("ICommand") != null))                // не добавляем абстрактные классы и интерфейсы
                {
                    ICommand value = (ICommand)Activator.CreateInstance(type);
                    _commands.Add(value);                                      // подгружаем этот класс в список уроков
                }
            }
        }

        // Вызывает комманду в зависисмости от аргументов командной строки
        public string ExecuteCommand(string command)
        {            
            string[] args = ParseCommandString(command);

            if (args.Length < 1) return "Ошибка";

            foreach (ICommand com in _commands)
            {
                if (com.CommandNames().Contains(args[0]))
                {
                    return com.Execute(this, args.Skip(1).ToArray());
                }
            }
            
            return "Ошибка!";
        }

        /// <summary>
        /// Метод "парсит" строку команды
        /// </summary>
        private string[] ParseCommandString(string command)
        {
            string[] parsedCommand = command.Split('>');

            for (int i = 0; i < parsedCommand.Length; i++)
                parsedCommand[i] = parsedCommand[i].Trim();

            return parsedCommand;
        }

        //Возвращает относительный путь к файлу, если такой существует; Иначе возвращает полный путь
        public string GetFilePath(string path) => GetPath(path, PathType.File);

        //Возвращает относительный путь к директории, если такой существует; Иначе возвращает полный путь
        public string GetDirectoryPath(string path) => GetPath(path, PathType.Directory);

        private string GetPath(string path, PathType type) 
        {
            path = path.Trim();
            string relatedPath = Path.Combine(RelativePath, path);

            bool isRelativeExist = type switch { 
                PathType.File => File.Exists(relatedPath), 
                PathType.Directory => Directory.Exists(relatedPath), 
                _ => false
                };

            if (isRelativeExist)
                return relatedPath;

            bool isPathExist = type switch
            {
                PathType.File => File.Exists(path),
                PathType.Directory => Directory.Exists(path),
                _ => false
            };

            if (isPathExist)
                return path;

            return "";
        }
        private enum PathType { Directory, File }
    }
}