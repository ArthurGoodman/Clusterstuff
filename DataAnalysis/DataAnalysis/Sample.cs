using System;

namespace DataAnalysis {
    class Sample : IComparable {
        public Vector4 Vector { get; set; }
        public int Cluster { get; set; }
        public bool Mark { get; set; }

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
