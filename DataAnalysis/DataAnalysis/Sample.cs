using System;

namespace DataAnalysis {
    class Sample : IComparable {
        public Vector Vector { get; set; }
        public int Cluster { get; set; }
        public bool Mark { get; set; }

        public Sample(double[] data) {
            Vector = new Vector(data);
        }

        public Sample(int size) {
            Vector = new Vector(size);
        }

        public double Distance(Sample other) {
            double squaredDist = 0;

            for (int i = 0; i < Math.Min(Vector.Size, other.Vector.Size); i++)
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

        public Sample CloneExpanded() {
            Sample clone = new Sample(new double[] { Vector[0], Vector[1], Vector[2], Vector[3], 1 });
            clone.Cluster = Cluster;
            clone.Mark = Mark;
            return clone;
        }
    }
}
