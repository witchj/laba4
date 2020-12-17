using System;
using System.IO;

namespace Laba4_task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1;
            string line2;
            int line1_number, line2_number;
            int product = new Int32();
            long sum = 0;
            int dfiles = 0;

            for (int i = 10; i < 30; i++)
            {
                string path = @"D:\labs\Laba4_task1\txt\" + i + ".txt";
                try
                {
                    StreamReader f = new StreamReader(path);
                    line1 = f.ReadLine();//записуем строку в переменную
                    line1_number = Convert.ToInt32(line1);//то что мы записали, конвертируем в инт
                    line2 = f.ReadLine();
                    line2_number = Convert.ToInt32(line2);
                    product = line1_number * line2_number;
                    Console.WriteLine("Произведение чисел в файле с именем " + i + ".txt" + " равно: " + product);
                    sum += product;
                    dfiles++; //прибавляем кол-во обработанных файлов
                    f.Close();
                }
                catch (System.IO.FileNotFoundException)
                {
                    using (StreamWriter no_file = new StreamWriter(@"D:\labs\Laba4_task1\txt\no_file.txt",
                    true, System.Text.Encoding.Default))
                    {
                        no_file.WriteLine(i + ".txt");
                    }
                }
                catch (System.FormatException)
                {
                    using (StreamWriter bad_data = new StreamWriter(@"D:\labs\Laba4_task1\txt\bad_data.txt",
                    true, System.Text.Encoding.Default))
                    {
                        bad_data.WriteLine(i + ".txt");
                    }
                }
                catch (System.OverflowException)
                {
                    using (StreamWriter overflow = new StreamWriter(@"D:\labs\Laba4_task1\txt\overflow.txt",
                    true, System.Text.Encoding.Default))
                    {
                        overflow.WriteLine(i + ".txt");
                    }
                }
                catch (System.IO.IOException)
                {
                    Console.WriteLine("Возможно, файла еще не существует");
                }
            }

            Console.WriteLine("Корректные файлы: {0}. " +
            "Среднее арифметическое произведений двух чисел в каждом из этих файлов равно {1}",
            dfiles, sum / (double)dfiles);
            Console.ReadKey();
        }
    }
}