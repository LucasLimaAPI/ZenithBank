using System.Collections.Generic;
using ZENITHBANK.Conta;
using ZENITHBANK.Util;
using System.Threading.Tasks;

namespace ZENITHBANK.zenithbank.Exceptions
{
    [System.Serializable]
    public class ZenithBankException : Exception
    {
        public ZenithBankException() { }
        public ZenithBankException(string message) : base("Aconteceu uma Exceçãp ->"+ message) { }
        public ZenithBankException(string message, System.Exception inner) : base(message, inner) { }
        protected ZenithBankException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}