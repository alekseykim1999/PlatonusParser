﻿using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core
{
    interface IParser<T> where T:class
    {
        T Parse(IHtmlDocument document);
        void Authorization(string _log, string _pass);
    }
}
