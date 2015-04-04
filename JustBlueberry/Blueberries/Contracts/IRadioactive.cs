namespace JustBlueberry.Blueberries.Contracts
{
    public interface IRadioactive
    {
        bool HasPowerElectron { get; set; }

        bool CheckState();

        void ChangeState();
    }
}
