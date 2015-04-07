namespace JustBlueberry.Blueberries.Contracts
{
    public interface IRadioactive
    {
        bool HasPowerElectron { get; }

        bool CheckState();

        void ChangeState();
    }
}
