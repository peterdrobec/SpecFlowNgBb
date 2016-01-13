using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowNg.Extensions
{
    public static class ScenarioContextExtensions
    {
        /// <summary>
        /// Adds the or update.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void AddOrUpdate(this ScenarioContext source, string key, object value)
        {
            if (!source.ContainsKey(key))
            {
                source.Add(key, value);
            }
            else
            {
                source[key] = value;
            }
        }

        /// <summary>
        /// Get the ScenarioContext global variable or Default value
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="name">The name of global variable</param>
        /// <returns></returns>
        public static string GetGlobalVariable(this ScenarioContext source, string name)
        {
            string value;
            bool result;

            // try to get the ScenarioContext global variable value
            result = source.TryGetValue(name, out value);

            // if there is not such variable use the "name" as value
            if (!result) value = name;

            return value;
        }
    }
}
