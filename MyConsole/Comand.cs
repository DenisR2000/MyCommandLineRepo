using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Channels;

namespace FileStreams
{
    public class Command
    {
        
        public string[] WordSplit(string str)
        {
            string[] words = new string[]{};
            if (str.IndexOf(" ") < 2)
            {
                words = str.Split(new char[] { ' ' });
            }
            else if (str.IndexOf(" ") > 2)
            {
                words = new string[3];
                words[0] = str.Substring(0, str.IndexOf(" "));
                words[1] = str.Substring(str.IndexOf(":") - 1, str.LastIndexOf(":") - str.IndexOf(" ")-2);
                words[2] = str.Substring(str.LastIndexOf(":") - 1);
            }
            return words;
        }

        public void cd(string ch)
        {
            string fileName = Console.ReadLine();
            try
            {
                string[] word = ch.Split(new char[] {' '});
                Directory.GetCurrentDirectory();
                Directory.SetCurrentDirectory(fileName);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public void pwd()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
        }

        public void dir(string str) //ls
        {
            foreach (var file in Directory.GetFiles("."))
            {
                Console.WriteLine(file);
            }

            foreach (var dir in Directory.GetDirectories("."))
            {
                Console.WriteLine(dir);
            }
        }
        
        public void cd_point2()
        {
            try
            {
                string str = Directory.GetCurrentDirectory();
                Directory.SetCurrentDirectory(str.Remove(str.LastIndexOf('/')));
                //Console.WriteLine(Directory.GetCurrentDirectory());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void cls(string str)
        {
            Console.Clear();
        }

        public void open(string str)
        {
            try
            {
                string fs = Console.ReadLine();
                foreach (var file in File.ReadAllLines(fs))
                {
                    Console.WriteLine(file);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            //Console.WriteLine(File.ReadLines(fs));
        }
        
        public void del(string files)
        {
            //string[] arr = file.Split(" ");
            string file = Console.ReadLine();
            FileInfo f = new FileInfo(file);
            if (f.Exists)
            {
                f.Delete();
            }
        }

        public void rd(string str)
        {
            string dir = Console.ReadLine();
            if (Directory.Exists(dir))
                Directory.Delete(dir);
        }

        public void copy(string ch)
        {
            try
            {
                string str1 = Console.ReadLine();
                string str2 = Console.ReadLine();
                if (Directory.Exists(str1))
                {
                    Console.WriteLine($"{str1} a folder, you can go to the manual (help)");
                    return;
                }

                if (Directory.Exists(str2))
                {
                    Console.WriteLine($"{str2} a folder, you can go to the manual (help)");
                    return;
                }

                File.Copy(str1, str2);

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void touch(string ch)
        {
            try
            {
                string path = Console.ReadLine();
                FileInfo f = new FileInfo(path);
                File.Create(path);
                //Console.WriteLine(f.Exists);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"{e.Message}");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"{e.Message}");
            }

        }

        public void mkdir(string ch)
        {
            try
            {
                string path = Console.ReadLine();
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"{e.Message}");
            } 
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public void Attrib(string str)
        {
            string file = Console.ReadLine();
            FileInfo f = new FileInfo(file);
            Console.WriteLine(f.Attributes);
        }

        public void help()
        {
            Console.WriteLine("cls - используется для очистки окна ");
            Console.WriteLine("pwd - текущий рабочий каталог");
            Console.WriteLine("dir - список файлов и папок, находящихся в заданном каталоге");
            Console.WriteLine("cd - смена текущего каталога\ncd .. - переход на каталог выше");
            Console.WriteLine("cls - очистка консоли");
            Console.WriteLine("open - открытие папки");
            Console.WriteLine("del - удаление файла");
            Console.WriteLine("touch - создание текстового документа");
            Console.WriteLine("mkdir - создание папки");
            Console.WriteLine("rd - удаление папки");
            Console.WriteLine("attrib - просмотр атрибутов указаного файла");
            Console.WriteLine("copy -  копирование в новый файл");
            Console.WriteLine("robocopy - копирование в новую папку");
            Console.WriteLine("find - поиск файлов");
            Console.WriteLine("exz - существует ли указаный файл");
            Console.WriteLine("mv - перемещение данных из файла");
            Console.WriteLine("move - перемещение данных из папок");
            Console.WriteLine("write - запись в файл");
        }

        public void robocopy(string ch)
        {
            
            string FirstFolder = Console.ReadLine();
            string SecondFolder = Console.ReadLine();
            foreach (string dirPath in Directory.GetDirectories(FirstFolder))
            {
                try
                {
                    Directory.CreateDirectory(dirPath.Replace(FirstFolder, SecondFolder));
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine($"cd: no such file or directory");
                }
            }
        }
        
        public void FindFiles(string str)
        {
            try
            {
                string file = Console.ReadLine();
                foreach (string d in Directory.GetDirectories(file))
                {
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void mv(string str)
        {
            try
            {
                string from = Console.ReadLine();
                string to = Console.ReadLine();
                File.Create(to);
                File.Move(from, to);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void move(string str)
        {
            string from = Console.ReadLine();
            string to = Console.ReadLine();
            DirectoryInfo dirinfo = new DirectoryInfo(to);
            try
            {
                Directory.Move(from, to);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //Console.WriteLine($"cd: {dirinfo.Name} no such directory ");
            }
        }

        public void exz(string files)
        {
            string file = Console.ReadLine();
            FileInfo f = new FileInfo(file);
            Console.WriteLine(f.Exists);
        }

        public void write(string str)
        {
            try
            {
                string path = Console.ReadLine();
                string text = Console.ReadLine();
                using (var fs = new FileStream(path, FileMode.Open,
                    FileAccess.Write))
                {
                    using (var bw = new BinaryWriter(fs, Encoding.Default))
                    {
                        bw.Write(text);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
    }
}