﻿using System.Collections.Generic;

namespace NextLevelSeven.Core
{
    /// <summary>
    ///     Represents a subcomponent element in an HL7 message.
    /// </summary>
    public interface ISubcomponent
    {
        /// <summary>
        ///     Get data from a subcomponent.
        /// </summary>
        /// <returns>Subcomponent data.</returns>
        string GetValue();

        /// <summary>
        ///     Get data from a subcomponent. Because subcomponent level elements are at the lowest possible level, there will be at most one item.
        /// </summary>
        /// <returns>Subcomponent data.</returns>
        IEnumerable<string> GetValues();
    }
}