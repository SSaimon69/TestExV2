namespace WordCalc
{
    public class Calc
    {
        Dictionary<string, int> CalculateWord(string filePath)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            string[] separators = { ",", ".", " ", " ", ";", ":", "?", "!", "\"", "(", ")", "—", "–", "[", "]", "»", "«" };

            using (StreamReader sr = File.OpenText(filePath))
            {
                string? s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] mas = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string ma in mas)
                        if (map.ContainsKey(ma)) map[ma]++;
                        else map.Add(ma, 1);
                }
            }

            return map;
        }
    }
}