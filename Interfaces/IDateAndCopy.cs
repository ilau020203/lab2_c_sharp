using System;

namespace lab2
{
    /// <summary>
    /// Interface indicating that object can be deep copied
    /// and has some sort of rate.
    /// </summary>
    public interface IRateAndCopy
    {
        double Rating { get; }

        object DeepCopy();
    }
}