using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators_Task1
{
    [Serializable]
    class IncompatibleComponentsException : Exception
    {
        public IncompatibleComponentsException() { }
        public IncompatibleComponentsException(string str) : base(str) { }
        public IncompatibleComponentsException(
        string str, Exception inner) : base(str, inner)
        { }
        protected IncompatibleComponentsException(
        System.Runtime.Serialization.SerializationInfo si,
        System.Runtime.Serialization.StreamingContext sc) : base(si, sc)
        { }

        public override string Message
        {
            get
            {
                return "IncompatibleComponentsException: Hardware from different vendors!!!";
            }
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
