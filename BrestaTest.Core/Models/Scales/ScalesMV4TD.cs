using BrestaTest.Core.Interfaces;
using BrestaTest.Core.ModelPresentations;
using BrestaTest.Core.Models.Enums;

namespace BrestaTest.Core.Models.Scales
{
    public class ScalesMV4TD : Scales, IMV4TDCompliant
    {
        public int AddrErrorModule1 { get; set; }
        public int AddrErrorSensor1 { get; set; }
        public int AddrSensor1 { get; set; }
        public PauseOption CancelIfPause { get; set; }
        public int ErrArrivalTime { get; set; }
        public float ErrArrivalVal { get; set; }
        public int ErrTimeMax { get; set; }
        public string InFeederOutput { get; set; }
        public float EtalonMass { get; set; }
        public float EtalonMin { get; set; }
        public float EtalonRange { get; set; }
        public float MassReady { get; set; }
        public float WaitTime1 { get; set; }
        public float WeightMax { get; set; }
        public float WeightMin { get; set; }
        public ScalesUiHint UiHint { get; set; }
    }
}
