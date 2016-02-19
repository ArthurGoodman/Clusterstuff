using System;
using System.Linq;

namespace Clusterstuff {
    class Program {
        static void Main(string[] args) {
            Sample[] samples = Sample.Load(@"..\..\iris.dat");

            MaxMin maxMin = new MaxMin(samples);
            maxMin.Run();

            for (int i = 0; i < maxMin.ClusterCount; i++) {
                Console.Write(string.Format("Cluster {0}:", i));

                foreach (Sample s in samples.Where(s => s.Cluster == i))
                    Console.Write(string.Format(" {0}", s.Index));

                Console.WriteLine();
            }
        }
    }
}
