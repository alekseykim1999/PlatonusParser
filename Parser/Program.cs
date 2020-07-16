using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Parser.Core.Platonus;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {

            string login = "990909350469";
            string password = "Deathgrind1234@";


            Console.WriteLine("Список всех ссылок на странице авторизации\n");
            ParserWorker<string[]> parser = new ParserWorker<string[]>(
                new PlatonusParser());


            parser.ParserSettings = new PlatonusSettings();

            //установить данные для входа
            parser.Login = login;
            parser.Password = password;


            parser.onCompleted += parser_on_completed;
            parser.onNewData += parser_on_new_data;
            parser.Start();


            Console.ReadKey();

           
        }

        private static void parser_on_completed(object obj)
        {
            Console.WriteLine("\nРабота завершена");
        }

        private static void parser_on_new_data(object arg1, string[] arg2)
        {
            for (int i = 0; i < arg2.Length; i++)
                Console.WriteLine(arg2[i]);
        }
    }
}
