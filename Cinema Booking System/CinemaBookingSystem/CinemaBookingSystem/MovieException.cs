using System;

namespace CinemaBookingSystem
{

    [Serializable()]
    public class MovieException : System.Exception
    {
        public MovieException() : base() { }
        public MovieException(string message) : base(message) { }
        public MovieException(string message, System.Exception inner) : base(message, inner) { }

        protected MovieException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
}
