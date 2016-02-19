using System;
using System.Collections.Generic;
using System.Linq;

namespace Clusterstuff {
    class Sample {
        private static int counter = 0;

        public string Name { get; set; }
        public int Index { get; set; }
        public int Cluster { get; set; }
        public bool Center { get; set; }

        private double[] data;

        public Sample(double[] data, string name) {
            this.data = data;
            Name = name;
            Index = counter++;
        }

        public double Distance(Sample other) {
            double squaredDist = 0;

            for (int i = 0; i < data.Length; i++)
                squaredDist += (data[i] - other.data[i]) * (data[i] - other.data[i]);
            
            return Math.Sqrt(squaredDist);
        }
    }
}
