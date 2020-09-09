using System;
using System.Text.RegularExpressions;
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
            int PwdMaxScore = 50; //максимальна оценка, которую может получить пароль без учета длины
            int UserPwdScore = 0; // общая оценка пароля
            int N = 0; //длина пароля

            string PwdLengthAnalysys = ""; // результат анализа длины пароля
            string usersPwd;
            string PwdContainsAnalysys = "";
            bool PwdContainsAnalysysFlag = false;
            string FinalAnalysys = "";


            Regex BigLetters = new Regex(@"[A-Z]", RegexOptions.Singleline); //проверка пароля на наличие больших букв
            Regex Digits = new Regex(@"\d", RegexOptions.Singleline); //проверка пароля на наличие цифр
            Regex SmallLetters = new Regex(@"[a-z]", RegexOptions.Singleline); //проверка пароля на наличие маленьких букв
            Regex Symbols = new Regex(@"[!@#$%^&*()_+=\-№;:?'₴~`[\]\\|/.,]", RegexOptions.Singleline); //проверка пароля на наличие спец.символов
            Regex RussLetters = new Regex(@"[А-я]"); //проверка пароля на наличие кириллических символов
            Regex Spaces = new Regex(@"\s");



            Console.WriteLine("Вас приветствует мастер оценки стойкости пароля. Пожалуйста, ввидети пароль для оценки:");
            usersPwd = Console.ReadLine(); //считывание пароля с клавиатуры
            Console.WriteLine($"Ваш пароль: {usersPwd}");

            MatchCollection SpacesCollection = Spaces.Matches(usersPwd);
            MatchCollection RussLettersCollection = RussLetters.Matches(usersPwd);
            MatchCollection BigLettersCollection = BigLetters.Matches(usersPwd);
            MatchCollection DigitsCollection = Digits.Matches(usersPwd);
            MatchCollection SmallLettersCollection = SmallLetters.Matches(usersPwd);
            MatchCollection SymbolsCollection = Symbols.Matches(usersPwd);

            if (RussLettersCollection.Count > 0)
            {
                Console.WriteLine("Пароль не может быть написан c примением кириллических символов.");
            }
            else if (SpacesCollection.Count>0)
            {
                Console.WriteLine("Пароль не может быть написан c примением пробелов.");
            }

            else
            {
                if (BigLettersCollection.Count > 0 && DigitsCollection.Count > 0 && SmallLettersCollection.Count > 0 && SymbolsCollection.Count > 0)
                {
                    PwdContainsAnalysys += "Ваш пароль удовлетворяет всем требованиям.";
                    PwdContainsAnalysysFlag = true;
                }


                N = usersPwd.Length; //получаем кол-во симолов пароля
                if (N < 6)
                {
                    PwdMaxScore += (N - 6) * 10;
                    if (PwdContainsAnalysysFlag)
                    {
                        PwdLengthAnalysys += "Однако, Ваш пароль слишком короткий!";
                    }
                    else
                    {
                        PwdLengthAnalysys += "Также Ваш пароль слишком короткий!";
                    }
                }
                else if (8 < N && N < 6)
                {
                    PwdMaxScore += N * 5 + 10;
                    PwdLengthAnalysys += "Также Ваш пароль имеет оптимальную длину.";


                }

                else if (8 < N)
                {
                    PwdMaxScore += 50 + (8 - N) * 2;
                    if (PwdContainsAnalysysFlag)
                    {
                        PwdLengthAnalysys += "Однако, Ваш пароль слишком длинный!";
                    }
                    else
                    {
                        PwdLengthAnalysys += "Также Ваш пароль слишком длинный!";
                    }
                }
                UserPwdScore = PwdMaxScore;
                if (BigLettersCollection.Count <= 0)
                {
                    UserPwdScore -= 10;
                    PwdContainsAnalysys += "Пароль должен содержать заглавные буквы.\n";
                }

                if (DigitsCollection.Count <= 0)
                {
                    UserPwdScore -= 10;
                    PwdContainsAnalysys += "Пароль должен содержать цифры.\n";
                }

                if (SymbolsCollection.Count <= 0)
                {
                    UserPwdScore -= 20;
                    PwdContainsAnalysys += "Пароль должен содержать спец. символы.\n";
                }

                if (SmallLettersCollection.Count <= 0)
                {
                    UserPwdScore -= 10;
                    PwdContainsAnalysys += "Пароль должен содержать строчные буквы.\n";
                }
                FinalAnalysys += PwdContainsAnalysys;
                FinalAnalysys += PwdLengthAnalysys;
                Console.WriteLine($"Ваш пароль был проанализирован. Итоговая оценка: {UserPwdScore}/{PwdMaxScore}.\n{FinalAnalysys}");
            }
            Console.ReadKey();
        }
    }
}
