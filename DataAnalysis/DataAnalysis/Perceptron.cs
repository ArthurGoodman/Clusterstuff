using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalysis {
    class Perceptron : IAlgorithm {
        private static int maxLearningEpochs = 10000;

        private string info = "No info.";
        public string Info {
            get {
                return info;
            }
        }

        private double c = 1;
        public double Param {
            get {
                return c / 2;
            }

            set {
                c = Math.Max(0, Math.Min(value, 1)) * 2;
            }
        }

        public DataSet Samples { get; set; }

        private Vector[] w;
        private Sample[] data;

        private int iterations;

        public void Run() {
            Initialize();

            int i;
            for (i = 0; i < maxLearningEpochs && !Learn(); i++) {
            }

            iterations = i;

            Mark();
            BuildInfo();
        }

        private void Initialize() {
            w = new Vector[Samples.CountClusters()];

            for (int i = 0; i < w.Length; i++)
                w[i] = new Vector(5);

            data = Samples.Data.Select(s => s.CloneExpanded()).ToArray();
        }

        private bool Learn() {
            bool corrected = false;

            List<double> d;

            foreach (Sample s in data) {
                d = w.Select(v => v.Dot(s.Vector)).ToList();

                double max = d.Max();
                int maxIndex = d.IndexOf(max);

                if (maxIndex != s.Cluster) {
                    corrected = true;

                    Vector delta = s.Vector * c;

                    w[s.Cluster] += delta;
                    w[maxIndex] -= delta;
                }
            }

            return !corrected;
        }

        private void Mark() {
            List<double> d;

            for (int i = 0; i < data.Length; i++) {
                d = w.Select(v => v.Dot(data[i].Vector)).ToList();

                double max = d.Max();
                int maxIndex = d.IndexOf(max);

                Samples[i].Mark = maxIndex != data[i].Cluster;
            }
        }

        private void BuildInfo() {
            info = string.Format("{0} iterations\n\n", iterations);

            foreach (Vector v in w)
                info += string.Format("{0}*x1 + {1}*x2 + {2}*x3 + {3}*x4 + {4}\n", v[0], v[1], v[2], v[3], v[4]);
        }
    }
}
