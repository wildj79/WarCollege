using System;

namespace WarCollege
{
    /// <summary>
    /// An enumeration of the various types that a trait can have.
    /// </summary>
    [Flags]
    public enum CharacterTraitType
    {
        None = 0,
        Neutral = 1,
        Positive = 2,
        Negative = 4,
        Flexible = 8,
        Character = 16,
        Vehicle = 32,
        Identity = 64,
    }
}
