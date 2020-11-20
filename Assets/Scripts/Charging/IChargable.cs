public interface IChargable
{
    bool Charged { get; }
    void Discharge();
}