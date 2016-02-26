using System;

namespace Clusterstuff {
    public class KMeans : IClusteringAlgorithm {
        public int ClusterCount {
            get {
                return (int)(Samples.Length * Param);
            }
        }

        private double param = 0.5;
        public double Param {
            get {
                return param;
            }

            set {
                param = Math.Max(0, Math.Min(value, 1));
            }
        }

        public Sample[] Samples { get; set; }

        public void Run() {
        }
    }
}
