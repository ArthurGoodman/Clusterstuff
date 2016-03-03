using System;

namespace DataAnalysis {
    class Perceptron : IAlgorithm {
        public string Info {
            get {
                return "No info.";
            }
        }

        private double lambda = 1;
        public double Param {
            get {
                return lambda / 2;
            }

            set {
                lambda = Math.Max(0, Math.Min(value, 1)) * 2;
            }
        }

        public Sample[] Samples { get; set; }

        public void Run() {
        }
    }
}
