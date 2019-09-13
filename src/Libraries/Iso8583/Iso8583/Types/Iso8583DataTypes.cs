namespace Iso8583.Types

{
    /// <summary>
    /// ISO 8583 data types
    /// </summary>
    public enum Iso8583DataTypes
    {
        /// <summary>
        /// Numeric values only
        /// </summary>
        NUMERIC,

        /// <summary>
        /// Alpha, including blanks
        /// </summary>
        ALPHA,

        /// <summary>
        /// Binary data
        /// </summary>
        BINARY,

        /// <summary>
        /// Nested message
        /// </summary>
        NESTED,
    }
}