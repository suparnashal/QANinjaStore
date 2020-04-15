using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Framework.Logging
{
   public static class TestContextData
    {
        static ConcurrentDictionary<string, List<string>> ContextData = new ConcurrentDictionary<string, List<string>>();

        public static void Add(string message)
        {
            if(!ContextData.ContainsKey(TestContext.CurrentContext.Test.ID))
            {
                ContextData.TryAdd(TestContext.CurrentContext.Test.ID, new List<string> { message });
            }
            else
            {
                ContextData[TestContext.CurrentContext.Test.ID].Add(message);
            }
        }
        public static void AddFail(string message)
        {
            Add($"Failure Reported:  {message}");
        }

        public static string GetAllTestContextMessages() =>        
            ContextData.ContainsKey(TestContext.CurrentContext.Test.ID) ?
                string.Join('\n', ContextData[TestContext.CurrentContext.Test.ID].ToArray()) :
                string.Empty;
        
    }
}
