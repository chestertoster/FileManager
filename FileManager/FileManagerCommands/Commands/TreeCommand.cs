using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCommands.Commands
{
    internal class TreeCommand : ICommand
    {
        public string CommandInfo() => "Показывает дерево папок и файлов";
        public List<string> CommandNames() => new List<string>() { "tree" };

        //Показывает дерево папок и файлов
        public string Execute(Manager manager, string[] args)
        {
            if (args.Length < 1) return "Ошибка! Недостаточно аргументов";
            string path = manager.GetDirectoryPath(args[0]);
            if (path == "") return "Ошибка! Директория с таким путем не найдена!";

            StringBuilder result = new();
            DirectoryInfo info = new DirectoryInfo(path);

            result.AppendLine();
            try
            {
                AddDirectoryStrings(info, result, 0);
            }
            catch (UnauthorizedAccessException e)
            {
                return "Ошибка! Недостаточно прав для просмотра файлов!";
            }
            catch (Exception e)
            {
                return "Ошибка! Невозможно просмотреть дерево файлов!";
            }

            return result.ToString();
        }

        //Вносит данные о директории в строку
        private void AddDirectoryStrings(DirectoryInfo directory, StringBuilder sb, int level) 
        {
            for(int i = 0; i < level; i++)
                    sb.Append("| ");
            sb.AppendLine(directory.Name + "/");

            foreach (var dir in directory.GetDirectories()) 
            {
                AddDirectoryStrings(dir, sb, level + 1);
            }

            AddFilesStrings(directory.GetFiles(), sb, level);
        }

        //Вносит данные о файлах в строку
        private void AddFilesStrings(FileInfo[] files, StringBuilder sb, int level) 
        {
            foreach (var file in files)
            {
                for (int i = 0; i < level; i++)
                    sb.Append("| ");
                sb.AppendLine(file.Name);
            }
        }
    }
}
