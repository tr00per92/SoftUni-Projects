namespace DistanceCalculator
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IDistanceCalculator
    {
        [OperationContract]
        decimal CalcDistance(Point startPoint, Point endPoint);
    }
}
