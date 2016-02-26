using System;
using System.Linq;

namespace Clusterstuff {
    class Program {
        static void Main(string[] args) {
            Sample[] samples = Sample.Load(@"..\..\iris.dat");

            IClusteringAlgorithm maxMin = new MaxMin();
            maxMin.Samples = samples;
            maxMin.Run();

            Console.WriteLine("Cluster centers:");

            foreach (Sample s in samples.Where(s => s.Center))
                Console.WriteLine(s.Inspect());

            Console.WriteLine();

            for (int i = 0; i < maxMin.ClusterCount; i++) {
                Console.WriteLine(string.Format("Cluster {0}:", i));

                foreach (Sample s in samples.Where(s => s.Cluster == i))
                    Console.WriteLine(s.Inspect());

                Console.WriteLine();
            }
        }
    }
}
