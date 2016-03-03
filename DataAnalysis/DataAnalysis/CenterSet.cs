using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalysis {
    class CenterSet : IEnumerable {
        private List<Sample> centers;
        private int nextCluster = 0;

        private IClusteringAlgorithm alg;

        public int Count {
            get {
                return centers.Count;
            }
        }

        public CenterSet(IClusteringAlgorithm alg) {
            centers = new List<Sample>();
            this.alg = alg;
        }

        public void Add(Sample sample) {
            sample.Center = true;
            sample.Cluster = nextCluster++;
            centers.Add(sample);
        }

        public IEnumerable<double> Distances(Sample sample) {
            return centers
                .Select(c => sample.Distance(c));
        }

        public void Assign(Sample sample) {
            sample.Cluster = centers
                .Select(c => new Tuple<double, Sample>(sample.Distance(c), c))
                .Min()
                .Item2.Cluster;
        }

        public double TypicalDistance() {
            if (centers.Count < 2)
                return 0;

            double dist = 0;

            for (int i = 0; i < centers.Count; i++)
                for (int j = 0; j < i; j++)
                    dist += centers[i].Distance(centers[j]);

            return alg.Param * dist / (centers.Count * (centers.Count - 1) / 2);
        }

        public void Reset() {
            nextCluster = 0;
            centers.Clear();
        }

        public void Forget() {
            foreach (Sample s in centers)
                s.Center = false;

            centers.Clear();
        }

        public IEnumerator GetEnumerator() {
            return centers.GetEnumerator();
        }

        public Sample this[int i] {
            get {
                return centers[i];
            }

            set {
                centers[i] = value;
            }
        }
    }
}
