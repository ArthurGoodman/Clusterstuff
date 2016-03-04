namespace DataAnalysis {
    class Matrix4x4 {
        private double[,] data;

        public Matrix4x4(double[,] data) {
            this.data = data;
        }

        public void Map(Vector v) {
            double[] mapped = new double[v.Size];

            for (int i = 0; i < v.Size; i++) {
                mapped[i] = 0;

                for (int j = 0; j < v.Size; j++)
                    mapped[i] += data[i, j] * v[j];
            }

            mapped.CopyTo(v.Data, 0);
        }
    }
}
