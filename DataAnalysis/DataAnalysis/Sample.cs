using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataAnalysis {
    public class Sample : IComparable {
        private static int counter = 0;

        public Vector4 Vector { get; set; }
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
                samples.Add(new Sample(values.Take(4).Select(v => double.Parse(v)).ToArray()));
            }

            return samples.ToArray();
        }

        public Sample(double[] data) {
            Vector = new Vector4(data);
            Index = counter++;
        }

        public double Distance(Sample other) {
            double squaredDist = 0;

            for (int i = 0; i < 4; i++)
                squaredDist += (Vector[i] - other.Vector[i]) * (Vector[i] - other.Vector[i]);

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
            return string.Format("{0}:\t<{1} {2} {3} {4}>", Index, Vector[0], Vector[1], Vector[2], Vector[3]);
        }

        public Sample Clone() {
            Sample clone = new Sample(Vector.Data);
            clone.Index = Index;
            clone.Cluster = Cluster;
            clone.Center = Center;
            return clone;
        }
    }
}
