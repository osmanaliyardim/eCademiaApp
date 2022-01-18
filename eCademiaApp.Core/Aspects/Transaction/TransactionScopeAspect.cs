using Castle.DynamicProxy;
using eCademiaApp.Core.Utilities.Interceptors;
using System.Transactions;

namespace eCademiaApp.Core.Aspects.Transaction
{
    // To make transactions when you want to revert a method in any step that occurs an error
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (var transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (Exception e)
                {
                    transactionScope.Dispose(); // When an error occured, dispose it
                    throw;
                }
            }
        }
    }
}
