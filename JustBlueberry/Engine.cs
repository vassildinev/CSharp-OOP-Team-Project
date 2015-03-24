namespace JustBlueberry
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using JustBlueberry.Extensions;

    public class Engine
    {
        private IOperator hadronOperator;
        private IList<IHadron> hadrons;
        private IRenderer renderer;
        private int threadSleepParam;

        public Engine(IRenderer renderer, IOperator hadronOperator, IList<IHadron> hadrons, int threadSleepParam = 500)
        {
            this.Renderer = renderer;
            this.HadronOperator = hadronOperator;
            this.Hadrons = hadrons;
            this.ThreadSleepParam = threadSleepParam;
        }

        public int ThreadSleepParam
        {
            get { return this.threadSleepParam; }
            set
            {
                if (value==0)
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
                    // TODO: throw new RendererMissingException
                }
                this.renderer = value;
            }
        }

        private IOperator HadronOperator
        {
            get { return this.hadronOperator; }
            set
            {
                if (value == null)
                {
                    // TODO: throw new HadronMissingException
                }
                this.hadronOperator = value;
            }
        }

        private IList<IHadron> Hadrons
        {
            get { return this.hadrons; }
            set
            {
                if (value == null)
                {
                    throw new InvalidBlueberryException("No blueberries, man...");
                }
                this.hadrons = value;
            }
        }

        public void AddHadron(IHadron p)
        {
            this.hadrons.Add(p);
        }

        public void Run()
        {
            // Set Console parameters.
            SetConsole();

            // Central / Game loop.
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
            renderer.Release();

            // Perform end-of-frame actions.
            hadronOperator.EndFrame();
        }

        private void Process()
        {
            Hadrons.ForEach(x => renderer.Push(x as IRenderable));
        }

        private void Update()
        {
            hadrons.ForEach(x => hadronOperator.OperateOn(x));
        }

        private void SetConsole()
        {
            Console.WindowHeight = 30;
            Console.WindowWidth = 45;
            Console.BufferHeight = 30;
            Console.BufferWidth = 50;
            Console.CursorVisible = false;
            Console.Title = "JustBlueberries";
        }
    }
}
