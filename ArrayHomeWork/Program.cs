using System;
using System.IO;


/// Test for GITHUB!
namespace ArrayHomeWork
{
    class Program
    {
        
        const string filePath = @"..\..\..\text.txt";
        /// <summary>
        /// Основная логика программы. 
        /// </summary>
        static void Main()
        {
            do
            {
                Console.Clear();

                int lengthArray = EnterCorrectLength();
                var arrA = new int[lengthArray];
                var arrB = new int[arrA.Length];

                FullArrOfRandomNumbers(arrA);
                CheckFileExist(filePath);
                PowOfTwo(arrA, out arrB);
                WirteArrayB(arrB);
                ShowTwoArrays(arrA, arrB);

                Console.WriteLine("Press ESCAPE to Exit. Press ANY KEY to start again.");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Вывод на экран двух массивов.
        /// Второй массив читается с файла.
        /// </summary>
        /// <param name="arrA">Исходная матрица.</param>
        /// <param name="arrB">Измененная матрица.</param>
        private static void ShowTwoArrays(int[] arrA, int[] arrB)
        {
            Console.WriteLine($"ArrayA: {string.Join(' ', arrA)}. {Environment.NewLine}");
            Console.WriteLine($"ArrayB: { File.ReadAllText(filePath)}. {Environment.NewLine}");
        }

        /// <summary>
        /// Ввод длины массива. От 1 до 1000.
        /// </summary>
        /// <returns>Длина массива.</returns>
        private static int EnterCorrectLength()
        {
            int n;
            do
            {
                Console.WriteLine("\bEnter length of array from 0 to 1000: ");
            } while ((!int.TryParse(Console.ReadLine(), out n)) || (n < 1) || (n > 1000));

            Console.Clear();
            return n;
        }
        /// <summary>
        /// Заполнение исходного массива рандомными значениями.
        /// </summary>
        /// <param name="arrA">Исходный массив, заполненнный нулями.</param>
        /// <returns>Заполненный массив.</returns>
        private static int[] FullArrOfRandomNumbers(int[] arrA)
        {
            var rnd = new Random();
            for (var i = 0; i < arrA.Length; i++)
            {
                arrA[i] = rnd.Next(0, 10001);
            }
            return arrA;
        }

        /// <summary>
        /// Записывает получившийся массив в текстовый файл.
        /// Также указывает директорию, куда был записан массив.
        /// </summary>
        /// <param name="arrB">Массив, состоящий из степеней двоек.</param>
        private static void WirteArrayB(int[] arrB)
        {
            var infoFile = new FileInfo(filePath);
            File.WriteAllText(filePath, string.Join(' ', arrB));
            Console.WriteLine($"Successfully! ArrayB located in {infoFile.Directory}!" +
                $"{Environment.NewLine}");
            
        }

        /// <summary>
        /// Поиск ближайшей степени двойки.
        /// Заполнение массива B найденными значениями.
        /// </summary>
        /// <param name="arrA">Исходный массив.</param>
        /// <param name="arrB">Массив степеней двоек.</param>
        private static void PowOfTwo(int[] arrA, out int[] arrB)
        {
            arrB = new int[arrA.Length];
            for (var i = 0; i < arrA.Length; i++)
            {
                double twoPow = 0;
                int pow = 0;
                // Поиск ближайшей степени двойки.
                while (arrA[i] > twoPow)
                {
                    twoPow = Math.Pow(2, pow);
                    pow++;
                }
                
                arrB[i] = (int)twoPow;
                
            }
        }

        /// <summary>
        /// Проверка на корректности пути. 
        /// </summary>
        /// <param name="filePath">Путь до файла.</param>
        private static void CheckFileExist(string filePath)
        {
            try
            {
                if (File.Exists(filePath) == false)
                {
                    File.WriteAllText(filePath, string.Empty);
                    Console.WriteLine("File was created.");
                }
                else
                {
                    Console.WriteLine("File already exist.");
                }
            }
            catch (Exception ex)
            {
                // Сообщение об ошибке, в случае некорректности заданного пути.
                Console.WriteLine($"Exception - ({ex.GetType()}): {ex.Message}");
            }
        }
    }
}
