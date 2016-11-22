using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace net1
{
    /// <summary>
    /// Логирование исключений
    /// </summary>
    class ExceptionsLogger
    {
        public static string FilePath = "Exceptions.txt";

        public static bool ToFile = true;
        /// <summary>
        /// Лог пользовательского исключения
        /// </summary>
        /// <param name="ex"></param>
        public static void LogUserException(UserException ex)
        {
            if (FilePath != null && ToFile)
            {
                if (!File.Exists(FilePath))
                {
                    var fs = File.Create(FilePath);
                    fs.Close();
                }
            }
            using (var writer = ToFile && FilePath != null ? File.AppendText(FilePath) : Console.Out)
            {
                writer.WriteLine(DateTime.Now.ToString("HH:mm:ss") + ": " + ex.Message + " (Пользовательское исключение)");
            }
        }
        /// <summary>
        /// Лог системного исключения
        /// </summary>
        /// <param name="ex"></param>
        public static void LogSystemException(Exception ex)
        {
            if (FilePath != null && ToFile)
            {
                if (!File.Exists(FilePath))
                {
                    var fs = File.Create(FilePath);
                    fs.Close();
                }
            }
            using (var writer = ToFile && FilePath != null ? File.AppendText(FilePath) : Console.Out)
            {
                writer.WriteLine(DateTime.Now.ToString("HH:mm:ss") + ": " + ex.Message + " (Системное исключение)");
            }
        }
    }
}
