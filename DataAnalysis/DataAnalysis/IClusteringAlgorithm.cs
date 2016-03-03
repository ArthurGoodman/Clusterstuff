namespace DataAnalysis {
    public interface IAlgorithm {
        double Param { get; set; }
        string Info { get; }
        Sample[] Samples { get; set; }

        void Run();
    }
}
