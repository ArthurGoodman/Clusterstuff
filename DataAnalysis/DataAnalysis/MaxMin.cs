using System;
using System.Linq;

namespace DataAnalysis {
    class MaxMin : IAlgorithm {
        private string info = "No info.";
        public string Info {
            get {
                return info;
            }
        }
        
        private double alpha = 0.5;
        public double Param {
            get {
                return alpha;
            }

            set {
                alpha = Math.Max(0, Math.Min(value, 1));
            }
        }

        public DataSet Samples { get; set; }

        private CenterSet centers;

        public MaxMin() {
            centers = new CenterSet(this);
        }

        public void Run() {
            if (Samples.Length == 0)
                return;

            int iterations = 0;

            centers.Reset();

            foreach (Sample s in Samples)
                s.Reset();

            centers.Add(Samples[0]);

            while (true) {
                Tuple<double, Sample> max = Samples.Data
                    .Where(s => !s.Mark)
                    .Select(s => new Tuple<double, Sample>(centers.Distances(s).Min(), s))
                    .Max();

                iterations++;

                if (max == null || max.Item1 <= centers.TypicalDistance())
                    break;

                centers.Add(max.Item2);

            }

            foreach (Sample s in Samples) {
                if (s.Mark)
                    continue;

                centers.Assign(s);
            }

            info = string.Format("{0} iterations", iterations);
        }
    }
}
