using System;
using System.Collections.Generic;
using System.Text;

namespace cAlgo.Exceptions
{
    /// <summary>
    /// Обработчик ошибок для листов
    /// </summary>
    public class ListException : Exception
    {
        /// <summary>
        /// Конструктор ошибок
        /// </summary>
        /// <param name="message">Сообщение ошибки</param>
        public ListException(string message) : base(message) { }
    }
}
