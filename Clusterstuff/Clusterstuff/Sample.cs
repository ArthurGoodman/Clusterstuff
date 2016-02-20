using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Clusterstuff {
    public class Sample : IComparable {
        private static int counter = 0;

        public Vector4 Data { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }
        public int Cluster { get; set; }
        public bool Center { get; set; }

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
            Data = new Vector4(data);
            Name = name;
            Index = counter++;
        }

        public double Distance(Sample other) {
            double squaredDist = 0;

            for (int i = 0; i < 4; i++)
                squaredDist += (Data[i] - other.Data[i]) * (Data[i] - other.Data[i]);

            return Math.Sqrt(squaredDist);
        }

        public int CompareTo(object obj) {
            return Index.CompareTo((obj as Sample).Index);
        }

        public void Reset() {
            Cluster = 0;
            Center = false;
        }

        public string Inspect() {
            return string.Format("{0}:\t{1}\t<{2} {3} {4} {5}>", Index, Name, Data[0], Data[1], Data[2], Data[3]);
        }

        public Sample Clone() {
            Sample clone = new Sample(Data.Data, Name);
            clone.Index = Index;
            clone.Cluster = Cluster;
            clone.Center = Center;
            return clone;
        }
    }
}
