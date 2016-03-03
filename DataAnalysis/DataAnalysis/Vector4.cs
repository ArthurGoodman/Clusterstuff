using System;
using System.Linq;

namespace DataAnalysis {
    public class Vector4 : IComparable {
        public double[] Data { get; private set; }

        public Vector4() {
            Data = new double[4];
        }

        public Vector4(double[] data) {
            Data = data.Take(4).ToArray();
        }

        public static Vector4 operator +(Vector4 a, Vector4 b) {
            double[] data = new double[4];

            for (int i = 0; i < 4; i++)
                data[i] = a.Data[i] + b.Data[i];

            return new Vector4(data);
        }

        public static Vector4 operator -(Vector4 a, Vector4 b) {
            double[] data = new double[4];

            for (int i = 0; i < 4; i++)
                data[i] = a.Data[i] - b.Data[i];

            return new Vector4(data);
        }

        public static Vector4 operator *(Vector4 a, double f) {
            double[] data = new double[4];

            for (int i = 0; i < 4; i++)
                data[i] = a.Data[i] * f;

            return new Vector4(data);
        }

        public static Vector4 operator /(Vector4 a, double f) {
            double[] data = new double[4];

            for (int i = 0; i < 4; i++)
                data[i] = a.Data[i] / f;

            return new Vector4(data);
        }

        public double this[int i] {
            get {
                return Data[i];
            }

            set {
                Data[i] = value;
            }
        }

        public bool Equals(Vector4 v) {
            for (int i = 0; i < 4; i++)
                if (Data[i] != v.Data[i])
                    return false;

            return true;
        }

        public int CompareTo(object obj) {
            return Data[0].CompareTo((obj as Vector4).Data[0]);
        }
    }
}
