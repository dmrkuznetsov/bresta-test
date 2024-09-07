using BrestaTest.Core.Models.Abstract;

namespace BrestaTest.Core.Models.Scales
{
    public class Scales : BaseEntity
    {
        public string FullPathToFile { get; set; }
        public string Sign { get; set; }
        public float Capacity { get; set; }
        public float Minimal { get; set; }
        public float Accuracy { get; set; }
        public string Algo { get; set; }
    }
}
