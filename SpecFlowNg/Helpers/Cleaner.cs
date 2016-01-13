using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowNg.Helpers
{
    /// <summary>
    /// Allows to register specific clean up actions which will be executed in reversed order at the end of the scenario.
    /// </summary>
    public class Cleaner
    {
        private readonly List<Action> actions = new List<Action>();

        /// <summary>
        /// Registers clean up action.
        /// </summary>
        /// <param name="action">Clean up action.</param>
        public void Register(Action action)
        {
            this.actions.Add(action);
        }

        /// <summary>
        /// Executes registered actiones in reversed order.
        /// </summary>
        public void Clean()
        {
            foreach (var action in Enumerable.Reverse(this.actions))
            {
                try
                {
                    action();
                }
                catch (Exception e)
                {
                    Console.Write(e);
                    //Log.Error(e, "Failed to cleanup");
                }
            }
        }
    }
}
