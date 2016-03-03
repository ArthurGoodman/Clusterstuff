using System;
using System.Drawing;
using System.Linq;

namespace DataAnalysis {
    class DataEngine {
        private static string fileName = @"..\..\iris.dat";

        private IAlgorithm alg = new MaxMin();
        public IAlgorithm Alg {
            get {
                return alg;
            }

            set {
                alg = value;
            }
        }

        public Sample[] Samples { get; set; }
        public Sample[] Rotated { get; private set; }

        public int ClusterCount { get; private set; }

        public bool AlgorithmActive { get; set; }

        public float AlphaX1 { get; private set; }
        public float AlphaY1 { get; private set; }
        public float AlphaX2 { get; private set; }
        public float AlphaY2 { get; private set; }

        private Vector4 center { get; set; }

        public DataEngine() {
            AlgorithmActive = true;
        }

        public void Calculate() {
            if (AlgorithmActive) {
                alg.Run();
                CountClusters();
            }

            Rotate();
        }

        public void LoadSamples() {
            CalculateCenter();
            CountClusters();

            alg.Samples = Samples;
            Calculate();
        }

        public void CalculateCenter() {
            center = new Vector4();

            foreach (Sample s in Samples)
                center += s.Vector;

            center /= Samples.Length;
        }

        public void CountClusters() {
            ClusterCount = Samples.Select(s => s.Cluster).Max() + 1;
        }

        public void LoadData() {
            Samples = Sample.Load(fileName);
            LoadSamples();
        }

        public void RandomizeData() {
            const int max = 5;
            Random r = new Random();

            Samples = new Sample[500];
            Sample[] centers = new Sample[r.Next(3, 6)];

            int i = 0;

            foreach (Sample s in centers) {
                Samples[i] = centers[i] = new Sample(new double[] { r.NextDouble() * max, r.NextDouble() * max, r.NextDouble() * max, r.NextDouble() * max });
                centers[i].Cluster = i;
                i++;
            }

            for (; i < Samples.Length; i++) {
                Samples[i] = new Sample(new double[] { r.NextDouble() * max, r.NextDouble() * max, r.NextDouble() * max, r.NextDouble() * max });

                Sample c = centers[r.Next() % centers.Length];

                Samples[i].Vector += (c.Vector - Samples[i].Vector) * r.Next(int.MaxValue / 2, int.MaxValue) / int.MaxValue;
                Samples[i].Cluster = c.Cluster;
            }

            LoadSamples();
        }

        public void ResetAngles() {
            AlphaX1 = 0;
            AlphaY1 = 0;
            AlphaX2 = 0;
            AlphaY2 = 0;
        }

        public void UpdateAngles(Point delta, bool control) {
            if (control) {
                AlphaX2 += delta.X / 400.0f;
                AlphaY2 += delta.Y / 400.0f;
            } else {
                AlphaX1 += delta.X / 400.0f;
                AlphaY1 += delta.Y / 400.0f;
            }
        }

        public void Rotate() {
            Matrix4x4 xMatrix1 = new Matrix4x4(new double[4, 4] {
                { Math.Cos(AlphaX1), 0, -Math.Sin(AlphaX1), 0 },
                { 0,                 1, 0,                  0 },
                { Math.Sin(AlphaX1), 0, Math.Cos(AlphaX1),  0 },
                { 0,                 0, 0,                  1 }
            });

            Matrix4x4 yMatrix1 = new Matrix4x4(new double[4, 4] {
                { 1, 0,                 0,                  0 },
                { 0, Math.Cos(AlphaY1), -Math.Sin(AlphaY1), 0 },
                { 0, Math.Sin(AlphaY1), Math.Cos(AlphaY1),  0 },
                { 0, 0,                 0,                  1 }
            });

            Matrix4x4 xMatrix2 = new Matrix4x4(new double[4, 4] {
                { Math.Cos(AlphaX2), 0, 0, -Math.Sin(AlphaX2) },
                { 0,                 1, 0, 0                  },
                { 0,                 0, 1, 0                  },
                { Math.Sin(AlphaX2), 0, 0, Math.Cos(AlphaX2)  }
            });

            Matrix4x4 yMatrix2 = new Matrix4x4(new double[4, 4] {
                { 1, 0,                 0, 0                  },
                { 0, Math.Cos(AlphaY2), 0, -Math.Sin(AlphaY2) },
                { 0, 0,                 1, 0                  },
                { 0, Math.Sin(AlphaY2), 0, Math.Cos(AlphaY2)  }
            });

            Rotated = Samples.Select(s => s.Clone()).ToArray();

            foreach (Sample s in Rotated) {
                s.Vector -= center;

                xMatrix2.Map(s.Vector);
                yMatrix2.Map(s.Vector);

                xMatrix1.Map(s.Vector);
                yMatrix1.Map(s.Vector);
            }

            Rotated = Rotated.OrderByDescending(s => s.Vector[2]).ToArray();
        }
    }
}
