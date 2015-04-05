﻿namespace JustBlueberry.Engine
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;

    using JustBlueberry.Operator;
    using JustBlueberry.Factory;
    using JustBlueberry.Common;
    using JustBlueberry.Renderer;
    using JustBlueberry.Common.Extensions;
    using JustBlueberry.Engine.Operation;
    using JustBlueberry.ApplicationExceptions;
    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Operator.Contracts;
    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Renderer.Contracts;



    public class BlueberryEngine
    {
        private BlueberryOperationStrategy strategy;
        private IOperator particleOperator;
        private IList<IMatter> substance;
        private IRenderer renderer;
        private int threadSleepParam;

        public BlueberryEngine(IRenderer renderer, IOperator particleOperator, IOperationStrategy operationStrategy,
            int threadSleepParam = GlobalConstants.DefaultEngineThreadSleepParameter)
        {
            this.Renderer = renderer;
            this.ParticleOperator = particleOperator;
            this.ThreadSleepParam = threadSleepParam;
            this.strategy = new BlueberryOperationStrategy(this.ParticleOperator);
            this.Substance = this.strategy.SendInstancesToEngine();
        }

        public int ThreadSleepParam
        {
            get { return this.threadSleepParam; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("ThreadSleep parameter must be larger than zero.");
                }
                this.threadSleepParam = value;
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

        private IList<IMatter> Substance
        {
            get { return this.substance; }
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
                // Update all particles' positions.
                Update();

                // Process the particles by stacking them updated for rendering.
                Process();

                // Perform rendering operations.
                Render();

                // Ensure constant app flow.
                Thread.Sleep(this.ThreadSleepParam);
            }
        }

        private void Render()
        {
            // Render current frame and release all particles from rendering.
            renderer.Print();

            Thread.Sleep(this.ThreadSleepParam);

            renderer.Release();

            // Perform end-of-frame actions.
            particleOperator.EndOperationCycle();
        }

        private void Process()
        {
            // Filter only renderable particles and then push them for rendering (prevents unwanted exception throw).
            this.Substance.ForEach(x => x.Particles.Where(y => y is IRenderable).ForEach(z => renderer.Push(z as IRenderable)));
        }

        private void Update()
        {
            // Update state of all available instances of matter.
            substance.ForEach(s => particleOperator.OperateOn(s));

            // Update all available particles (both renderable and not renderable).
            substance.ForEach(x => x.Particles.ForEach(y => particleOperator.OperateOn(y)));
        }

        public void OperatorCyclesElapsed(object sender, EventArgs e)
        {
            this.Substance = this.strategy.SendInstancesToEngine();
        }
    }
}
