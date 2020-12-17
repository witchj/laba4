using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;

namespace Lab4_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Directory.GetFiles(@"D:\labs\Laba4_Task2\files\");//берет пути к файлам
            string[] names = Directory.GetFiles(@"D:\labs\Laba4_Task2\files\").Select(Path.GetFileName).ToArray();//берет имена файлов
            Regex regexExtForImage = new Regex("^((.bmp)|(.gif)|(.tiff?)|(.jpe?g)|(.png))$", RegexOptions.IgnoreCase);/*создаем регулярное выражения 
                                                                                                                       для расширений наших картинок.
                                                                                                                                                     */
            for (int i = 0; i < arr.Length; i++)//по индексам всех файлов
            {
                try
                {
                    if (regexExtForImage.IsMatch(Path.GetExtension(arr[i]))) //расширение файла соответсвует одному из тех, которые мы записали
                    {
                        Bitmap bitmap = (Bitmap)Bitmap.FromFile(arr[i]); //битмап - класс, в котором хранится картинка
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipY); //поворот на 180 градусов по оси У, слева-направо
                        bitmap.Save(@"D:\labs\Laba4_Task2\files\" + names[i].Split('.')[0] + "-changed.gif", ImageFormat.Gif);//пересохраняем картиночку, добавляет джендж и устанавливаем формат .гиф
                        Console.WriteLine("Фото4ка создана и сохранена.");
                    }
                }
                catch (System.OutOfMemoryException)
                {
                    Console.WriteLine("а файлик-то битый");
                }
            }
            Console.ReadKey();
        }
    }
}
