using System;
using System.Linq;

namespace DataAnalysis {
    class Vector : IComparable {
        public double[] Data { get; private set; }

        public int Size {
            get {
                return Data.Length;
            }
        }

        public Vector(int size) {
            Data = new double[size];
        }

        public Vector(double[] data) {
            Data = data.ToArray();
        }

        public static Vector operator +(Vector a, Vector b) {
            double[] data = new double[Math.Min(a.Size, b.Size)];

            for (int i = 0; i < data.Length; i++)
                data[i] = a.Data[i] + b.Data[i];

            return new Vector(data);
        }

        public static Vector operator -(Vector a, Vector b) {
            double[] data = new double[Math.Min(a.Size, b.Size)];

            for (int i = 0; i < data.Length; i++)
                data[i] = a.Data[i] - b.Data[i];

            return new Vector(data);
        }

        public static Vector operator *(Vector a, double f) {
            double[] data = new double[a.Size];

            for (int i = 0; i < data.Length; i++)
                data[i] = a.Data[i] * f;

            return new Vector(data);
        }

        public static Vector operator /(Vector a, double f) {
            double[] data = new double[a.Size];

            for (int i = 0; i < data.Length; i++)
                data[i] = a.Data[i] / f;

            return new Vector(data);
        }

        public double Dot(Vector v) {
            double s = 0;

            for (int i = 0; i < Math.Min(Size, v.Size); i++)
                s += this[i] * v[i];

            return s;
        }

        public double this[int i] {
            get {
                return Data[i];
            }

            set {
                Data[i] = value;
            }
        }

        public bool Equals(Vector v) {
            if (Size != v.Size)
                return false;

            for (int i = 0; i < Size; i++)
                if (Data[i] != v.Data[i])
                    return false;

            return true;
        }

        public int CompareTo(object obj) {
            return Data[0].CompareTo((obj as Vector).Data[0]);
        }
    }
}
