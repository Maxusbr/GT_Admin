using System;

namespace Getticket.Web.DAL.Exeptions
{
    public class InternallProgrammErrorException : Exception
    {
        public InternallProgrammErrorException() : base() { }
        public InternallProgrammErrorException(string message) : base(message) { }
        public InternallProgrammErrorException(string message, Exception inner) : base(message, inner) { }
    }
}