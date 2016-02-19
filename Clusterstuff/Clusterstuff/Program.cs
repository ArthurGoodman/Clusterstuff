using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Clusterstuff {
    class Program {
        static void Main(string[] args) {
            string[] lines = File.ReadAllLines(@"..\..\iris.dat");
            List<Sample> samples = new List<Sample>();

            foreach (string line in lines) {
                if (line.Length == 0)
                    continue;

                string[] values = line.Split(',');
                samples.Add(new Sample(values.Take(4).Select(v => double.Parse(v)).ToArray(), values.Last()));
            }

            MaxMin maxMin = new MaxMin(samples.ToArray());
            maxMin.Run();

            for (int i = 0; i < maxMin.ClusterCount; i++) {
                Console.Write(string.Format("Cluster {0}:", i));

                foreach (Sample s in samples.Where(s => s.Cluster == i)) {
                    Console.Write(string.Format(" {0}", s.Index));
                }

                Console.WriteLine();
            }
        }
    }
}
