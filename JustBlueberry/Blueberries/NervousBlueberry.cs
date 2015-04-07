namespace JustBlueberry.Blueberries
{
    using System.Collections.Generic;
    using System.Linq;

    using JustBlueberry.ApplicationExceptions;
    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Common;
    using JustBlueberry.Common.Extensions;
    using JustBlueberry.Particles;
    using JustBlueberry.Particles.Contracts;

    public class NervousBlueberry : JustMatter, IMatter, IRadioactive
    {
        private bool hasPowerElectron;

        public NervousBlueberry(IList<IHadron> particles)
            :base(particles)
        {
            this.CheckForPowerElectron();
        }

        private void CheckForPowerElectron()
        {
            foreach (var item in this.Particles)
            {
                if (item is GreenElectron)
                {
                    this.HasPowerElectron = true;
                }
            }

            if (this.HasPowerElectron == false)
            {
                throw new PowerElectronMissingException("Invalid NervousBlueberry - WARNING! Power Electron Missing");
            }
        }

        public bool HasPowerElectron
        {
            get { return this.hasPowerElectron; }
            set { this.hasPowerElectron = value; }
        }
        public bool CheckState()
        {
            GreenElectron powerElectron = null;
            this.Particles.Where(p => p is GreenElectron).ForEach(p => powerElectron = p as GreenElectron);

            return powerElectron.IsDead;
        }

        public void ChangeState()
        {
            this.Particles.Where(p => p is DynamicProton).ForEach(p => this.PowerProtonHalt(p as DynamicProton));
        }

        private void PowerProtonHalt(DynamicProton p)
        {
            p.ResetPosition();
            p.ResetSpeed();
        }

        public override string GetInfo()
        {
            return "This blueberry is very nervous! You must be careful with it!";
        }
    }
}
