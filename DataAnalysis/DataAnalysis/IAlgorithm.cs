namespace DataAnalysis {
    interface IAlgorithm {
        double Param { get; set; }
        string Info { get; }
        DataSet Samples { get; set; }

        void Run();
    }
}
