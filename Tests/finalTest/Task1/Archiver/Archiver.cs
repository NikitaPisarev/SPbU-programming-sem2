namespace Archiver;

/// <summary>
/// Class of archiver
/// </summary>
public static class Archiver
{
    /// <summary>
    /// Method for data compression.
    /// </summary>
    /// <param name="bytes"> Byte array for compression. </param>
    /// <returns> Compressed byte array. </returns>
    /// <exception cref="ArgumentNullException"> Byte array can't be null. </exception>
    /// <exception cref="ArgumentException"> Byte array can't be empty. </exception>
    public static byte[] Compress(byte[]? bytes)
    {
        if (bytes is null)
        {
            throw new ArgumentNullException(nameof(bytes), "can't be null.");
        }

        if (bytes.Length == 0)
        {
            throw new ArgumentException("File empty.");
        }

        var result = new List<byte>();
        byte countCurrentBytes = 1;
        for (int i = 1; i < bytes.Length; i++)
        {
            if (bytes[i] == bytes[i - 1] && countCurrentBytes != 255)
            {
                ++countCurrentBytes;
            }
            else
            {
                result.Add((byte)countCurrentBytes);
                result.Add(bytes[i - 1]);
                countCurrentBytes = 1;
            }
        }
        result.Add((byte)countCurrentBytes);
        result.Add(bytes[bytes.Length - 1]);
        return result.ToArray();
    }

    /// <summary>
    /// Method for data decompression.
    /// </summary>
    /// <param name="bytes"> Byte array for decompression. </param>
    /// <returns> Decompressed byte array. </returns>
    /// <exception cref="ArgumentNullException"> Byte array can't be null. </exception>
    /// <exception cref="ArgumentException"> Byte array can't be empty. </exception>
    public static byte[] Decompress(byte[]? bytes)
    {
        if (bytes is null)
        {
            throw new ArgumentNullException(nameof(bytes), "can't be null.");
        }

        if (bytes.Length == 0)
        {
            throw new ArgumentException("File empty.");
        }

        var result = new List<byte>();
        for (int i = 0; i < bytes.Length; i = i + 2)
        {
            for (int j = 0; j < bytes[i]; j++)
            {
                result.Add(bytes[i + 1]);
            }
        }
        return result.ToArray();
    }
}
