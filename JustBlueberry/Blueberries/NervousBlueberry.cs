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

    public class NervousBlueberry : IMatter, IRadioactive
    {
        private bool hasPowerElectron;
        private IEnumerable<IHadron> particles;
        private bool hasChangedState;

        public NervousBlueberry(IList<IHadron> particles)
        {
            this.Particles = particles;
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
            this.particles.Where(p => p is GreenElectron).ForEach(p => powerElectron = p as GreenElectron);

            return powerElectron.IsDead;
        }

        public IEnumerable<IHadron> Particles
        {
            get { return new List<IHadron>(this.particles); }
            private set { this.particles = value; }
        }

        public void ChangeState()
        {
            this.particles.Where(p => p is DynamicProton).ForEach(p => this.PowerProtonHalt(p as DynamicProton));
        }

        private void PowerProtonHalt(DynamicProton p)
        {
            p.ResetPosition();
            p.ResetSpeed();
        }
    }
}
