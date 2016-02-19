using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Clusterstuff {
    class Sample {
        private static int counter = 0;

        public string Name { get; set; }
        public int Index { get; set; }
        public int Cluster { get; set; }
        public bool Center { get; set; }

        private double[] data;

        public static Sample[] Load(string fileName) {
            string[] lines = File.ReadAllLines(fileName);

            List<Sample> samples = new List<Sample>();

            foreach (string line in lines) {
                if (line.Length == 0)
                    continue;

                string[] values = line.Split(',');
                samples.Add(new Sample(values.Take(4).Select(v => double.Parse(v)).ToArray(), values.Last()));
            }

            return samples.ToArray();
        }

        public Sample(double[] data, string name) {
            this.data = data;
            Name = name;
            Index = counter++;
        }

        public double Distance(Sample other) {
            double squaredDist = 0;

            for (int i = 0; i < data.Length; i++)
                squaredDist += (data[i] - other.data[i]) * (data[i] - other.data[i]);

            return Math.Sqrt(squaredDist);
        }
    }
}
