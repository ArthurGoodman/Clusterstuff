using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataAnalysis {
    class Sample : IComparable {
        public Vector4 Vector { get; set; }
        public int Cluster { get; set; }
        public bool Mark { get; set; }

        public static Sample[] Load(string fileName) {
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

            return samples.ToArray();
        }

        public Sample(double[] data) {
            Vector = new Vector4(data);
        }

        public double Distance(Sample other) {
            double squaredDist = 0;

            for (int i = 0; i < 4; i++)
                squaredDist += (Vector[i] - other.Vector[i]) * (Vector[i] - other.Vector[i]);

            return Math.Sqrt(squaredDist);
        }

        public int CompareTo(object obj) {
            return Vector.CompareTo((obj as Sample).Vector);
        }

        public void Reset() {
            Cluster = 0;
            Mark = false;
        }

        public Sample Clone() {
            Sample clone = new Sample(Vector.Data);
            clone.Cluster = Cluster;
            clone.Mark = Mark;
            return clone;
        }
    }
}
