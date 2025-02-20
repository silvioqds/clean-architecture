using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string errorMessage) : base(errorMessage) { }

        public static void When(bool hasError, string errorMessage)
        {
            if (hasError)
                throw new DomainExceptionValidation(errorMessage);
        }
    }
}
