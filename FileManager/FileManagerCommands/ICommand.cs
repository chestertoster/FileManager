namespace FileManagerCommands;

internal interface ICommand
{
    /// <summary>
    /// Метод выполнить
    /// </summary>
    string Execute(Manager manager, string[] args);
    
    /// <summary>
    /// Возвращает описание команды
    /// </summary>
    /// <returns></returns>
    string CommandInfo();

    /// <summary>
    /// Словарь наименований
    /// </summary>
    /// <returns></returns>
    List<string> CommandNames();
}
