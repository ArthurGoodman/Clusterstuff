namespace DataAnalysis {
    public interface IAlgorithm {
        double Param { get; set; }
        int ClusterCount { get; }
        string Info { get; }
        Sample[] Samples { get; set; }

        void Run();
    }
}
