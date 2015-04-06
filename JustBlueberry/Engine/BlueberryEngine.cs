namespace JustBlueberry.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    using JustBlueberry.ApplicationExceptions;
    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Common;
    using JustBlueberry.Common.Extensions;
    using JustBlueberry.Engine.Contracts;
    using JustBlueberry.Engine.Operation;
    using JustBlueberry.Factory;
    using JustBlueberry.Operator;
    using JustBlueberry.Operator.Contracts;
    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Renderer;
    using JustBlueberry.Renderer.Contracts;

    public class BlueberryEngine : IEngine
    {
        private BlueberryOperationStrategy strategy;
        private IOperator particleOperator;
        private IList<IMatter> substance;
        private IRenderer renderer;
        private int framesPerSecond;
        private int threadSleepParameter;

        public BlueberryEngine(IRenderer renderer, IOperator particleOperator, IOperationStrategy operationStrategy,
            int framesPerSecond = GlobalConstants.DefaultEngineFramesPerSecond)
        {
            this.Renderer = renderer;
            this.ParticleOperator = particleOperator;
            this.FramesPerSecond = framesPerSecond;
            this.strategy = new BlueberryOperationStrategy(this.ParticleOperator);
            this.substance = this.strategy.SendInstancesToEngine();

            this.threadSleepParameter = GlobalConstants.OneSecondInMilliseconds / this.FramesPerSecond;
        }

        public int FramesPerSecond
        {
            get { return this.framesPerSecond; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("ThreadSleep parameter must be larger than zero.");
                }
                this.framesPerSecond = value;
            }
        }

        public IRenderer Renderer
        {
            get { return this.renderer; }
            set
            {
                if (value == null)
                {
                    throw new RendererMissingException("Render can not be null!");
                }
                this.renderer = value;
            }
        }

        private IOperator ParticleOperator
        {
            get { return this.particleOperator; }
            set
            {
                if (value == null)
                {
                    throw new HadronMissingException("Hadron operator can not be null!");
                }
                this.particleOperator = value;
            }
        }

        public IList<IMatter> Substance
        {
            // Use of defensive programming for the collection of blueberries.
            get { return new List<IMatter>(this.substance); }
            set
            {
                if (value == null)
                {
                    throw new InvalidBlueberryException("No blueberries, man...");
                }
                this.substance = value;
            }
        }

        public void AddHadron(IMatter matter)
        {
            this.substance.Add(matter);
        }

        public void Run()
        {
            // Central loop.
            while (true)
            {
                // Update all particles' and objects' positions.
                this.Update();

                // Process the particles by stacking them updated for rendering.
                this.Process();

                // Perform rendering operations.
                this.Render();

                // Ensure constant app flow.
                Thread.Sleep(this.threadSleepParameter);
            }
        }

        private void Render()
        {
            // Render current frame
            renderer.Print();
            // Release all particles from rendering
            renderer.Release();

            // Perform end-of-frame actions.
            particleOperator.EndOperationCycle();
        }

        private void Process()
        {
            // Filter only renderable particles and then push them for rendering (prevents unwanted exceptions).
            this.substance.ForEach(blueberry => blueberry.Particles
                                                .Where(particle => particle is IRenderable)
                                                .ForEach(renderableParticle => renderer.Push(renderableParticle as IRenderable)));
        }

        private void Update()
        {
            // Update state of all blueberries.
            this.substance.ForEach(blueberry => particleOperator.OperateOn(blueberry));

            // Update all available particles (both renderable and not renderable).
            this.substance.ForEach(blueberry => blueberry.Particles.ForEach(particle => particleOperator.OperateOn(particle)));
        }

        public void OperatorCyclesElapsed(object sender, EventArgs e)
        {
            this.substance = this.strategy.SendInstancesToEngine();
        }
    }
}
