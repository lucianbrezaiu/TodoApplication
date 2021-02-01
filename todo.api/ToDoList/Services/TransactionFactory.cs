using System;
using System.Transactions;

namespace ToDoList.Services
{
    public static class TransactionFactory
    {
        public static TransactionScope New() => new TransactionScope(
           TransactionScopeOption.Required,
           new TransactionOptions
           {
               IsolationLevel = IsolationLevel.Snapshot,
               Timeout = TimeSpan.FromMinutes(1)
           },
           TransactionScopeAsyncFlowOption.Enabled);
    }
}
