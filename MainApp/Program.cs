using WordCalc;
using System.Reflection;

namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime firstTime = DateTime.Now;
            string filePath = "text.txt";

            Type type = typeof(WordCalc.Calc);
            var a = type.GetMethod("CalculateWord", BindingFlags.NonPublic | BindingFlags.Instance);

            Dictionary<string, int> map = (Dictionary<string, int>) a.Invoke(new Calc(), new object[] { filePath });

            //Сортировка
            var sort = map.OrderByDescending(x => x.Value);

            //Вывод в файл
            using (StreamWriter sw = File.CreateText("textOut.txt"))
            {
                foreach (var x in sort)
                {
                    sw.WriteLine(x.Key + " " + x.Value);
                }
            }

            Console.WriteLine("Затрачено времени: " + (DateTime.Now - firstTime).TotalSeconds + " секунд");
        }
    }
}