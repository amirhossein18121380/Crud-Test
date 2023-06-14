using System.Security.Cryptography;

namespace Mc2.CrudTest.Presentation.Server.Extension;

public class HelperExtensions
{
    public static ulong GenerateRandomULong()
    {
        byte[] buffer = new byte[8];

        using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(buffer);
        }
        ulong randomULong = BitConverter.ToUInt64(buffer, 0);

        return randomULong;
    }

    public static DateTime RandomDay()
    {
        Random gen = new();
        DateTime start = new DateTime(1995, 1, 1);
        int range = (DateTime.Today - start).Days;
        return start.AddDays(gen.Next(range));
    }
}

