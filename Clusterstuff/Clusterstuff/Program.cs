using System.IO;
using System.Linq;

namespace Iris {
    class Program {
        static void Main(string[] args) {
            string[] lines = File.ReadAllLines("iris.dat");

            double[][] data = new double[lines.Length][];

            int i = 0;

            foreach (string line in lines) {
                string[] values = line.Split(',');
                data[i++] = values.Take(4).Select(v => double.Parse(v)).ToArray();
            }
        }
    }
}
