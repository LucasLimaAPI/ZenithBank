using System.Collections.Generic;
using ZENITHBANK.Conta;
using ZENITHBANK.Util;
using System.Threading.Tasks;

namespace ZENITHBANK.zenithbank.Exceptions
{
    #nullable disable
    [System.Serializable]
    public class ZenithBankException : Exception
    {
        public ZenithBankException() { }
        public ZenithBankException(string message) : base("Aconteceu uma Exceçãp ->"+ message) { }
        public ZenithBankException(string message, System.Exception inner) : base(message, inner) { }
        protected ZenithBankException(
            System.Runtime.Serialization.SerializationInfo info,
#pragma warning disable SYSLIB0051 // Type or member is obsolete
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
#pragma warning restore SYSLIB0051 // Type or member is obsolete
    }
}