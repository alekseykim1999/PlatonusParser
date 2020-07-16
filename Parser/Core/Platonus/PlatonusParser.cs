using AngleSharp;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Parser.Core.Platonus
{
    class PlatonusParser : IParser<string[]> //сам парсер платонуса
    {
        public string[] Parse(IHtmlDocument document) //функци, которая выводит нужную информацию
        {

            var list = new List<string>(); //спсиок всех найденных надписей
            var items = document.QuerySelectorAll("a").Where(i=>i.ClassName!=null && i.ClassName.Contains("dropdown-toggle"));


            var teacher_names = document.QuerySelectorAll("tr").Where(i => i.ClassName != null && i.ClassName.Contains("subject"));

            //взять весь текст в тегах <a>, где имя класса не пустое и равно "deopdown-toggle"
            foreach (var item in items)
                list.Add(item.TextContent); //добавить содержание тегов - их текст

            //foreach (var item in teacher_names)
            //     list.Add(item.TextContent); //добавить содержание тегов - их текст


            return list.ToArray();
        }


        public void Authorization(string _login, string _password)
        {
            if (_login != null && _password != null)
                Console.WriteLine("{0}, {1}", _login, _password);

            IConfiguration config = Configuration.Default.WithDefaultLoader().WithDefaultCookies();
            IBrowsingContext browsingContext = BrowsingContext.New(config);

            try
            {
                browsingContext.OpenAsync("https://edu.enu.kz/index").Wait();
                (browsingContext.Active.QuerySelector("input[name = 'iin']") as IHtmlInputElement).Value = _login;
                (browsingContext.Active.QuerySelector("input[name = 'password']") as IHtmlInputElement).Value = _password;
                (browsingContext.Active.QuerySelector("form") as IHtmlFormElement).SubmitAsync().Wait();

                Console.WriteLine("Авторизация удалась");
            }
            catch
            {
                Console.WriteLine("Авторизация не удалась");
            }
           

           
        }
    }
}
