namespace Iso8583
{
    using System.Collections.Generic;

    public interface IIso8583Message
    {
        bool HasTypeIndicator { get; }

        bool HasBitmap { get; }

        decimal TypeIndicator { get; set; }

        ISet<int> PrimaryBitmap { get; }

        ISet<int> SecondBitmap { get; }
    }
}
