using System;

public class KafkaException : Exception
{
    public KafkaException(string message) : base(message)
    {
       
    }
}