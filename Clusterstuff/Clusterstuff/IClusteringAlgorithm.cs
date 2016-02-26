namespace Clusterstuff {
    public interface IClusteringAlgorithm {
        double Param { get; set; }
        int ClusterCount { get; }
        Sample[] Samples { get; set; }

        void Run();
    }
}
