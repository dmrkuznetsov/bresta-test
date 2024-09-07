using BrestaTest.Core.Models.Enums;

namespace BrestaTest.Core.Interfaces
{
    public interface IMV4TDCompliant
    {
        /// <summary>
        /// Адрес ошибки подключения измерительного модуля
        /// </summary>
        public int AddrErrorModule1 { get; set; }
        /// <summary>
        /// Адрес ошибки тензодатчика 
        /// </summary>
        public int AddrErrorSensor1 { get; set; }
        /// <summary>
        /// Адрес тензодатчика MV4TD_2.Sensor.2*1000
        /// </summary>
        public int AddrSensor1 { get; set; }
        /// <summary>
        /// 1 - При паузе, выполнить отмену.  2 - При критической ошибке, выполнить отмену. 
        /// </summary>
        public PauseOption CancelIfPause { get; set; }
        /// <summary>
        /// Через сколько секунд проверяем поступает ли химия 
        /// </summary>
        public int ErrArrivalTime { get; set; }
        /// <summary>
        /// Если этот объем воды не поступил после открытия клапана, то сигнализируем об ошибке. 
        /// </summary>
        public float ErrArrivalVal { get; set; }
        /// <summary>
        /// Максимально допустимое время подачи 
        /// </summary>
        public int ErrTimeMax { get; set; } 
        public string InFeederOutput { get; set; }
        /// <summary>
        /// Эталонная масса 
        /// </summary>
        public float EtalonMass { get; set; }
        /// <summary>
        /// Минимальное значение датчика 
        /// </summary>
        public float EtalonMin { get; set; }
        /// <summary>
        /// Значение датчика(минус минимальное) при эталоном весе. 
        /// </summary>
        public float EtalonRange { get; set; }
        /// <summary>
        /// Максимальная масса на весах, при которой они готовы для нового замеса.
        /// </summary>
        public float MassReady { get; set; }
        /// <summary>
        /// Время которое ждем после взвешивания и закрытия клапана, чтобы точнее рассчитать объем сброса материала
        /// </summary>
        public float WaitTime1 { get; set; }
        /// <summary>
        /// Максимальная допустимая масса на весах. При превышении которой происходит экстренная остановка алгоритмов подающих устройств.
        /// </summary>
        public float WeightMax { get; set; }
        /// <summary>
        /// Минимально допустимый взвешиваемая масса 
        /// </summary>
        public float WeightMin { get; set; } 
    }
}
