using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure.Exceptions
{
    public class DatabaseExistingValueException : Exception
    {
        public DatabaseExistingValueException():base()
        {
            
        }

        public DatabaseExistingValueException(string? message) : base(message )
        {
        }

        public DatabaseExistingValueException(string? message, Exception? innerException) : base(message , innerException)
        {
        }

        protected DatabaseExistingValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
