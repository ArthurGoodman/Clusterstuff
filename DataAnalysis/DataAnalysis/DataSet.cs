using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataAnalysis {
    class DataSet : IEnumerable {
        private static string fileName = @"..\..\iris.dat";

        public Sample[] Data { get; set; }

        public Sample this[int i] {
            get {
                return Data[i];
            }

            set {
                Data[i] = value;
            }
        }

        public int Length {
            get {
                return Data.Length;
            }
        }

        public void Load() {
            string[] lines = File.ReadAllLines(fileName);

            List<Sample> samples = new List<Sample>();
            List<string> names = new List<string>();

            foreach (string line in lines) {
                if (line.Length == 0)
                    continue;

                string[] values = line.Split(',');

                samples.Add(new Sample(values.Take(4).Select(v => double.Parse(v)).ToArray()));

                if (!names.Contains(values[4]))
                    names.Add(values[4]);

                samples.Last().Cluster = names.IndexOf(values[4]);
            }

            Data = samples.ToArray();
        }

        public void Randomize() {
            const int max = 5;
            Random r = new Random();

            Data = new Sample[500];
            Sample[] centers = new Sample[r.Next(3, 6)];

            int i = 0;

            foreach (Sample s in centers) {
                Data[i] = centers[i] = new Sample(new double[] { r.NextDouble() * max, r.NextDouble() * max, r.NextDouble() * max, r.NextDouble() * max });
                centers[i].Cluster = i;
                i++;
            }

            for (; i < Data.Length; i++) {
                Data[i] = new Sample(new double[] { r.NextDouble() * max, r.NextDouble() * max, r.NextDouble() * max, r.NextDouble() * max });

                Sample c = centers[r.Next() % centers.Length];

                Data[i].Vector += (c.Vector - Data[i].Vector) * r.Next(int.MaxValue / 2, int.MaxValue) / int.MaxValue;
                Data[i].Cluster = c.Cluster;
            }
        }

        public IEnumerator GetEnumerator() {
            return Data.GetEnumerator();
        }
    }
}
