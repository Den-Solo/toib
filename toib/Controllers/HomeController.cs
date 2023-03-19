using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using ToibSolovyov.Models;

namespace ToibSolovyov.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(HomePage model)
        {
            return View(new HomePage());
        }

        /// <summary>
        /// Регулярное выражение с некорректными разрешенными символами для проверки e-mail.
        /// Согласно RFC 5322 email не должен иметь последовательно более
        /// двух точек без взятий имени в двойные кавычки.
        /// Допустимый некорректный вариант: den..solo@list.ru
        /// Допустимый корректный вариант: "den..solo"@list.ru или den.solo@list.ru
        /// </summary>
        public ActionResult Test1(Test model)
        {
            Regex regex = new Regex("^(?:[a-z0-9!#$%&'*+./=?^_`{|}~-]+"
                 + "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\""
                   + "(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|"
                   + "\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])"
                   + "*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9]"
                   + "(?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])"
                   + "|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])"
                   + "|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:"
                   + "(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|"
                   + "\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])$");
            var result = $"E-Mail {model.Input} ";
            var match = regex.Match(model.Input ?? "");
            if (match.Success)
                result += "корректный";
            else
                result += "некорректный";
            return PartialView("TestRes", result);
        }

        /// <summary>
        /// Регулярное выражение с незаданным концом шаблона.
        /// Если входные данные не соотвествуют шаблону, создается SQL-запрос без условий
        /// </summary>
        public ActionResult Test2(Test model)
        {
            Regex regex = new Regex("^[A-Za-z]+");
            var sqlRequest = "";
            if (regex.IsMatch(model.Input ?? ""))
                sqlRequest = $"SELECT id, name, age WHERE name LIKE '{model.Input}'";
            else
                sqlRequest = $"SELECT id, name, age";
            return PartialView("TestRes", $"Результирующий SQL-запрос: {sqlRequest}");
        }

        /// <summary>
        /// Регулярное выражение с некорректным разрешенным набором символов,
        /// связанная с конкретной реализацией регулярных выражений в языке программирования.
        /// ECMAScript: \w - только ASCII
        /// C#: \w - unicode (ю)
        /// </summary>
        public ActionResult Test3(Test model)
        {
            Regex regex = new Regex("^[\\w]+$");
            var result = "";
            if (regex.IsMatch(model.Input ?? ""))
                result = $"Тест пройден";
            else
                result = $"Тест НЕ пройден";
            return PartialView("TestRes", result);
        }

        /// Регулярное выражение с некорректными разрешенными символами для проверки e-mail.
        /// Согласно RFC 5322 email не должен иметь последовательно более
        /// двух точек без взятий имени в двойные кавычки.
        /// Недопустимый вариант: den..solo@list.ru
        /// Допустимый корректный вариант: "den..solo"@list.ru или den.solo@list.ru
        public ActionResult TestFixed1(Test model)
        {
            Regex regex = new Regex("^(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+"
                 + "(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\""
                   + "(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|"
                   + "\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])"
                   + "*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9]"
                   + "(?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])"
                   + "|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])"
                   + "|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:"
                   + "(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|"
                   + "\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])$");
            var result = $"E-Mail {model.Input} ";
            var match = regex.Match(model.Input ?? "");
            if (match.Success)
                result += "корректный";
            else
                result += "некорректный";
            return PartialView("TestRes", result);
        }

        /// <summary>
        /// Регулярное выражение с незаданным концом шаблона.
        /// Если входные данные не соотвествуют шаблону, создается SQL-запрос без условий
        /// </summary>
        public ActionResult TestFixed2(Test model)
        {
            Regex regex = new Regex("^[A-Za-z]+$");
            var sqlRequest = "";
            if (regex.IsMatch(model.Input ?? ""))
                sqlRequest = $"SELECT id, name, age WHERE name LIKE '{model.Input}'";
            else
                sqlRequest = $"SELECT id, name, age";
            return PartialView("TestRes", $"Результирующий SQL-запрос: {sqlRequest}");
        }

        /// <summary>
        /// Регулярное выражение с некорректным разрешенным набором символов,
        /// связанная с конкретной реализацией регулярных выражений в языке программирования.
        /// ECMAScript: \w - только ASCII
        /// C#: ^(?> *)[\x00-\x7F]+$ - только ASCII
        /// </summary>
        public ActionResult TestFixed3(Test model)
        {
            Regex regex = new Regex("^(?> *)[\x00-\x7F]+$");
            var result = "";
            if (regex.IsMatch(model.Input ?? ""))
                result = $"Тест пройден";
            else
                result = $"Тест НЕ пройден";
            return PartialView("TestRes", result);
        }
    }
}