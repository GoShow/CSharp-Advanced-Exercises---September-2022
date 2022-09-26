namespace LineNumbers
{
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder sb = new StringBuilder();

            string[] lines = File.ReadAllLines(inputFilePath);

            for (int i = 0; i < lines.Length; i++)
            {
                int lettersCount = lines[i].Count(ch => char.IsLetter(ch));
                int symbolsCount = lines[i].Count(ch => char.IsPunctuation(ch));

                sb.AppendLine($"Line {i + 1}: {lines[i]} ({lettersCount})({symbolsCount})");
            }

            File.WriteAllText(outputFilePath, sb.ToString());
        }
    }
}
