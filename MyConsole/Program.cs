using System;
using System.IO;

using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using Microsoft.VisualBasic.CompilerServices;

namespace FileStreams
{
    class Program
    {
        static void Main(string[] args)
        {

            //EXZ
            Console.ResetColor();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Command command = new Command(); 
            
            bool t = true;
            while (t == true)
            {
                Console.Write($"{Directory.GetCurrentDirectory()} ~ % ");
                string ch = Console.ReadLine();
                string[] word = ch.Split(new char[] {' '});
                switch (ch)
                {
                    case "help":
                        command.help();
                        break;
                    case "pwd":
                        command.pwd();
                        break;
                    case "dir":
                        command.dir(ch);
                        break;
                    case "cd ..":
                        command.cd_point2();
                        break;
                    case "cd":
                        command.WordSplit(ch);
                        command.cd(ch);
                        break;
                    case "cls":
                        command.cls(ch);
                        break;
                    case "open":
                        command.open(ch);
                        break;
                    case "del":
                        command.del(ch);
                        break;
                    case "touch":
                        command.touch(ch);
                        break;
                    case "mkdir":
                        command.mkdir(ch);
                        break;
                    case "rd":
                        command.rd(ch);
                        break;
                    case "attrib":
                        command.Attrib(ch);
                        break;
                    case "copy":
                        command.copy(ch);
                        break;
                    case "robocopy":
                        command.robocopy(ch);
                        break;
                    case "find":
                        command.FindFiles(ch);
                        break;
                    case "exz":
                        command.exz(ch);
                        break;
                    case "mv":
                        command.mv(ch);
                        break;
                    case "move":
                        command.move(ch);
                        break;
                    case "write":
                        command.write(ch);
                        break;
                    default:
                        Console.WriteLine("zsh: command not found");
                        break;
                }
            }
        }
    }
}