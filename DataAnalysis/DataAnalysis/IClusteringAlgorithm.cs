namespace DataAnalysis {
    public interface IClusteringAlgorithm {
        double Param { get; set; }
        int ClusterCount { get; }
        Sample[] Samples { get; set; }

        void Run();
    }
}
