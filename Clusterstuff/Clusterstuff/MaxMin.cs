using System;
using System.Linq;

namespace Clusterstuff {
    public class MaxMin {
        private static double alpha = 0.5;
        public static double Alpha {
            get {
                return alpha;
            }

            set {
                alpha = Math.Max(0, Math.Min(value, 1));
            }
        }

        private Sample[] samples;
        private CenterSet centers = new CenterSet();

        public int ClusterCount {
            get {
                return centers.Count;
            }
        }

        public MaxMin(Sample[] samples) {
            this.samples = samples;
        }

        public void Run() {
            if (samples.Length == 0)
                return;

            centers.Add(samples[0]);

            while (true) {
                Tuple<Sample, double> max = samples
                    .Where(s => !s.Center)
                    .Select(s => new Tuple<Sample, double>(s, centers.Distances(s).Min()))
                    .OrderByDescending(t => t.Item2)
                    .First();

                if (max.Item2 <= centers.TypicalDistance())
                    break;

                centers.Add(max.Item1);
            }

            foreach (Sample s in samples) {
                if (s.Center)
                    continue;

                centers.Assign(s);
            }
        }
    }
}
