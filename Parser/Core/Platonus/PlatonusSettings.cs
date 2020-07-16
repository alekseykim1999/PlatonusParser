using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core.Platonus
{
    class PlatonusSettings : IParserSettings //настройки парсируемого сайта
    {
        public string BaseUrl { get; set; } = "https://edu.enu.kz/"; //основной url
        public string Prefix { get; set; } = "index"; //дополнительные страницы, которые можно распарсить

        //public string Prefix { get; set; } = "current_progress_gradebook_student"; //страница с оценками. Так как нужна авторизация, пока не сработает


    }
}
