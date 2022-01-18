using Core.Utilities.Results;

namespace eCademiaApp.Core.Utilities.BusinessRules
{
    // To make 'business rules' strict and readable
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
                if (!logic.Success)
                    return logic;

            return null;
        }
    }
}
