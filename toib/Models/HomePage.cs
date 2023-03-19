using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToibSolovyov.Models
{
    public class HomePage
    {
        public Test Test1 { get; set; } = new Test() { 
            ControllerName = "Test1",  
            TestName= "RegEx с некорректными разрешенными символами для проверки e-mail",
            AdditionalInfo = "Регулярное выражение:\n" +
                "                                  ↓  \n" +
            " ^(?:[a-z0-9!#$%&'*+<span class=\"text-danger underline\">.</span>/=?^_`{|}~-]+"
                 + "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\""
                   + "(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|"
                   + "\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])"
                   + "*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9]"
                   + "(?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])"
                   + "|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])"
                   + "|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:"
                   + "(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|"
                   + "\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])$\n\n"
                    + "допускает email, не соответствующий RFC 5322 с последовательностью из " +
                     "более двух точек без взятия имени в двойные кавычки: <span class=\"text-danger \">{den..solo@list.ru}</span>.\n\n"
            + "Стандарт разрешает: {\"den..solo\"@list.ru} или {den.solo@list.ru}."
        };

        public Test Test2 { get; set; } = new Test() { 
            ControllerName = "Test2",
            TestName = "RegEx с незаданным концом шаблона",
            AdditionalInfo = "Регулярное выражение:\n" +
               "^[A-Za-z]+ \n"
                    + "не имеет ограничение конца строки, что представляет риск, " +
            "в случае его использования для валидации входных данных SQL-запроса вида: \n\n" +
            "SELECT id, name, age FROM users WHERE name LIKE '{userInput}'\n\n" +
            "где userInput берется из введенных в форму значений. \n" +
            "Это позволяет выполнить SQL-инъекцию вида:\n\n" +
            "<span class=\"text-danger \">alexey' INNER JOIN secrets ON users.id = secrets.id  --</span>\n\n" +
            "при условии, что есть таблицы users и secrets, где secrets хранит пароли по Id пользователя.\n\n" +
            "" +
            "Если инъекция есть в входном параметре - должен быть сформирован запрос без параметра."
        };

        public Test Test3 { get; set; } = new Test() { 
            ControllerName = "Test3",
            TestName = "Регулярное выражение с некорректным разрешенным набором символов \\w",
            AdditionalInfo = "Регулярное выражение:\n" +
               "^[\\w]+$ \n"
                    + "в реализации ECMAScript допускает только ASCII символы, " +
            "в то время как это же выражение в реализации C# Regex допускает unicode символы с " +
            "диакритическими знаками, например  a&#768;"

        };

        public Test TestFixed1 { get; set; } = new Test() { 
            ControllerName = "TestFixed1",
            TestName = "Исправление: RegEx с некорректными разрешенными символами для проверки e-mail",
            AdditionalInfo = "Регулярное выражение:\n" +
                "                                                            ↓  \n" +
            " ^(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+"
                 + "(?:<span class=\"text-danger underline\">\\.</span>[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\""
                   + "(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|"
                   + "\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])"
                   + "*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9]"
                   + "(?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])"
                   + "|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])"
                   + "|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:"
                   + "(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|"
                   + "\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])$\n\n"
                    + "НЕ допускает email, не соответствующий RFC 5322 с последовательностью из " +
                     "более двух точек без взятия имени в двойные кавычки: <span class=\"text-danger \">{den..solo@list.ru}</span>.\n\n"
            + "Стандарт разрешает: {\"den..solo\"@list.ru} или {den.solo@list.ru}."
        };

        public Test TestFixed2 { get; set; } = new Test() { 
            ControllerName = "TestFixed2",
            TestName = "Исправление: RegEx с незаданным концом шаблона",
            AdditionalInfo = "Регулярное выражение:\n" +
               "^[A-Za-z]+$ \n"
                    + "теперь имеет имеет ограничение конца строки." +
            "В случае его использования для валидации входных данных SQL-запроса вида: \n\n" +
            "SELECT id, name, age FROM users WHERE name LIKE '{userInput}'\n\n" +
            "где userInput берется из введенных в форму значений. \n" +
            "Оно  защищает от SQL-инъекции вида:\n\n" +
            "<span class=\"text-danger \">alexey' INNER JOIN secrets ON users.id = secrets.id  --</span>\n\n" +
            "при условии, что есть таблицы users и secrets, где secrets хранит пароли по Id пользователя.\n\n" +
            "" +
            "Если инъекция есть в входном параметре - должен быть сформирован запрос без параметра."
        };

        public Test TestFixed3 { get; set; } = new Test() { 
            ControllerName = "TestFixed3",
            TestName = "Исправление: Регулярное выражение с некорректным разрешенным набором символов \\w",
            AdditionalInfo = "Регулярное выражение:\n" +
               "^(?> *)[\\0-\\u007f]+$ \n"
                    + "в реализации C# допускает только ASCII символы, "
        };
    }
}