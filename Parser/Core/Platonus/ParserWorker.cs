using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core.Platonus
{
    class ParserWorker<T> where T : class //сам класс парсера, который управляет процессом
    {
        IParser<T> parser;
        IParserSettings parserSettings;

        private string login;
        private string password;


        bool isActive;
        HtmlLoader loader;
        #region Properties

        public string Login
        {
            set
            {
                login = value;
            }
        }

        public string Password
        {
            set
            {
                password = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }

        public IParser<T> Parser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }
        }

        public IParserSettings ParserSettings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }


        #endregion
        public ParserWorker(IParser<T> _parser)
        {
            this.parser = _parser;
        }

        public ParserWorker(IParser<T> _parser, IParserSettings _settings) : this(_parser)
        {
            this.parserSettings = _settings;
        }

        public void Start()
        {
            isActive = true;
            Work();
        }

        public void Abort()
        {
            isActive = false;
        }

        public async void Work()
        {
            if(!isActive)
            {
                onCompleted?.Invoke(this);
                return;
            }
            else
            {
                var source = await loader.getSourceByPageId("");
                var domParser = new HtmlParser();

                var documentPage = await domParser.ParseDocumentAsync(source);



                parser.Authorization(login, password); //авторизоваться на странице

                var result = parser.Parse(documentPage); //получить нужную страницу

                onNewData.Invoke(this, result);
            }

            onCompleted?.Invoke(this);
        }


        public event Action<object, T> onNewData;
        public event Action<object> onCompleted;



    }
}
