namespace DistanceCalculator
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Point
    {
        [DataMember]
        public decimal X { get; set; }

        [DataMember]
        public decimal Y { get; set; }
    }
}