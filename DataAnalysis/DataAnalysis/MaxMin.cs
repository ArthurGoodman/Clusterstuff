using System;
using System.Linq;

namespace DataAnalysis {
    class MaxMin : IAlgorithm {
        public string Info {
            get {
                return "No info.";
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

        public Sample[] Samples { get; set; }

        private CenterSet centers;

        public MaxMin() {
            centers = new CenterSet(this);
        }

        public void Run() {
            if (Samples.Length == 0)
                return;

            centers.Reset();

            foreach (Sample s in Samples)
                s.Reset();

            centers.Add(Samples[0]);

            while (true) {
                Tuple<double, Sample> max = Samples
                    .Where(s => !s.Mark)
                    .Select(s => new Tuple<double, Sample>(centers.Distances(s).Min(), s))
                    .Max();

                if (max == null || max.Item1 <= centers.TypicalDistance())
                    break;

                centers.Add(max.Item2);
            }

            foreach (Sample s in Samples) {
                if (s.Mark)
                    continue;

                centers.Assign(s);
            }
        }
    }
}
