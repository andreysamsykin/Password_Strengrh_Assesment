using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIB_1
{
    class Program
    {
        static void Main(string[] args)
        {
            short PwdMaxScore = 0; //максимальна оценка, которую может получить пароль
            short UserPwdScore = 0; // общая оценка пароля
            short N = 0; //длина пароля

            string usersPwd;
            Console.WriteLine("Вас приветствует мастер оценки стойкости пароля. Пожалуйста, ввидети пароль для оценки:");
            usersPwd = Console.ReadLine();
            Console.WriteLine($"Ваш пароль: {usersPwd}");
            N = Convert.ToInt16(usersPwd.Length); //получаем кол-во симолов пароля
            
            
            
            Console.ReadKey();
        }
    }
}
