# File Manager App
### Разработчик: Галичкин Дмитрий, ИСП-201
---
### Команды:
- **cd > <путь>** - изменение локальной директории +
- **ls | list** - просмотр файлов 1 уровня локальной директории +
- **f_info > <путь>** - просмотр информации о файле +
- **dir_info > <путь>** - просмотр информации о директории +
- **f_del > <путь>** - удаление файла по пути + 
- **dir_del > <путь>** - удаление директории по пути +
- **f_copy > <путь к файлу> > <директория>** - копирование файла +
- **dir_copy > <директория 1> > <директория 2>** - копирование директории +
- **f_move > <откуда> > <куда>** - перемещение файла
- **dir_move > <откуда> > <куда>** - перемещение директории
- **tree > <путь>** - показать всё дерево файлов и директорий +
### Описание реализованного функционала:
##### FileManagerCommands:
- ***Commands/*** :
    - Реализована логика для изменения локальной директории в **CdCommand.cs**
    - Реализована логика для копирования директории в **DirectoryCopyCommand.cs**
    - Реализована логика для удаления директории в **DirectoryDeleteCommand.cs**
    - Реализована логика для получения информации о директории в **DirectoryInfoCommand.cs**
    - Реализована логика для перемещения директории в **DirectoryMoveCommand.cs**
    - Реализована логика для копирования файла в **FileCopyCommand.cs**
    - Реализована логика для удаления файла в **FileDeleteCommand.cs**
    - Реализована логика для получения информации о файле в **FileInfoCommand.cs**
    - Реализована логика для перемещения файла в **FileMoveCommand.cs**
    - Реализована логика для просмотра файлов 1 уровня локальной директории в **ListCommand.cs**
    - Реализована логика для просмотра всех файлов и вложенных директорий в **TreeCommand.cs**
- Добавлена логика связанная с локальной директорией в **Manager.cs**
##### FileManagerConsoleApi:
- Реализована логика передачи комманд и аргументов в *Manager* в **MainPage.xaml**.
### Скриншоты работы программы:

**cd, list, tree:**
![Скриншот 1](https://sun7-13.userapi.com/impg/SQgypcOSNb6Bow9KstGTYQBLLoOGQdTVnx2Pbg/Pbx0yhdOrb4.jpg?size=975x498&quality=96&sign=e356b203ef815651f6efc8951dde289e&type=album)

**f_info, dir_info:**
![Скриншот 2](https://sun9-52.userapi.com/impg/Csl6jpYGaQgyNMcuxHaOFgobrvp6Qa8H7i7WLg/-zglQ9qt7nw.jpg?size=975x507&quality=96&sign=dd2f13fcfe569012abc8a3698159b88c&type=album)

**dir_del, f_del:**
![Скриншот 3](https://sun9-50.userapi.com/impg/AwSTPbsOfVQXLPXRbNIgyRx9iMJMmXCQ-yQ0EA/wWIaAhtWFBU.jpg?size=975x500&quality=96&sign=ad2a0f5d7ac37db62a47dbcbcc1c77d9&type=album)

**f_copy, dir_copy:**
![Скриншот 4](https://sun9-84.userapi.com/impg/k0PHeQz6O00e4BX4NzVfo6Ru8LV3L0zXWXimbQ/Gg05xiFnnIc.jpg?size=978x509&quality=96&sign=5a19d79c40a77b66cd512589fb8436cc&type=album)

**f_move, dir_move:**
![Скриншот 5](https://sun9-37.userapi.com/impg/lslt5ZCZhvU97FZXYuA-Nz8Dqofc5Qfr8yaK2Q/YeCBSik9_XQ.jpg?size=977x510&quality=96&sign=c1fe837946d109213e1e81fa7a3988cf&type=album)