using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Parser.Core.Platonus
{
    class HtmlLoader //объект, который загружает страницу
    {
        readonly HttpClient client; //клиент 
        readonly string url; //путь к страницу

        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseUrl}/{settings.Prefix}"; //полный путь к нужному html
        }

        public async Task<string> getSourceByPageId(string id) //получить нужную страницу
        {
           
            var response = await client.GetAsync(url); //получить ответ клиенту
            string source = null;
            if(response!=null && response.StatusCode == HttpStatusCode.OK) //если статус ОК, то страница передалась
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source; //весь код страницы
        }
    }
}
