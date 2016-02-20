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

        public Vector4 Center { get; private set; }

        public int ClusterCount {
            get {
                return centers.Count;
            }
        }

        public MaxMin(Sample[] samples) {
            this.samples = samples;

            Center = new Vector4();

            foreach (Sample s in samples)
                Center += s.Data;

            Center /= samples.Length;
        }

        public void Run() {
            if (samples.Length == 0)
                return;

            centers.Reset();

            foreach (Sample s in samples)
                s.Reset();

            centers.Add(samples[0]);

            while (true) {
                Tuple<double, Sample> max = samples
                    .Where(s => !s.Center)
                    .Select(s => new Tuple<double, Sample>(centers.Distances(s).Min(), s))
                    .Max();

                if (max.Item1 <= centers.TypicalDistance())
                    break;

                centers.Add(max.Item2);
            }

            foreach (Sample s in samples) {
                if (s.Center)
                    continue;

                centers.Assign(s);
            }
        }
    }
}
