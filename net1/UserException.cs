using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net1
{   
    /// <summary>
    /// Абстрактный класс
    /// </summary>
    public abstract class UserException: Exception
    {
        protected UserException(string message) : base(message) { }
    }
    /// <summary>
    /// Пользовательское исключение
    /// </summary>
    public class ClientException : UserException
    {
        public ClientException(string message) : base(message) { }
    }
    /// <summary>
    /// Исключение ошибки формата файла
    /// </summary>
    public class FileFormatException : UserException
    {
        public FileFormatException(string message) : base(message) { }
    }
}
