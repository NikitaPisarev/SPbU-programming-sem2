namespace BWT;

internal class RotationsComparer : IComparer<int>
{
    public RotationsComparer(byte[] bytes)
    {
        this._bytes = bytes;
    }

    private byte[] _bytes;

    int IComparer<int>.Compare(int firstElement, int secondElement)
    {
        for (int i = 0; i < _bytes.Length; ++i)
        {
            if (_bytes[(firstElement + i) % _bytes.Length] > _bytes[(secondElement + i) % _bytes.Length])
            {
                return 1;
            }
            else if (_bytes[(firstElement + i) % _bytes.Length] < _bytes[(secondElement + i) % _bytes.Length])
            {
                return -1;
            }
        }
        return 0;
    }
}

public class BWT
{
    private const int _alphabetSize = 256;

    public static (byte[], int) Encode(byte[] bytes)
    {
        if (bytes is null)
        {
            throw new ArgumentNullException(nameof(bytes), "can't be null.");
        }

        if (bytes.Length == 0)
        {
            throw new ArgumentException(nameof(bytes), "can't be empty.");
        }

        var rotations = new int[bytes.Length];
        for (int i = 0; i < rotations.Length; ++i)
        {
            rotations[i] = i;
        }

        Array.Sort(rotations, new RotationsComparer(bytes));

        var result = new List<byte>();
        int lineEndNumber = 0;
        for (int i = 0; i < bytes.Length; ++i)
        {
            result.Add(bytes[(rotations[i] + bytes.Length - 1) % bytes.Length]);

            if (rotations[i] == 0)
            {
                lineEndNumber = i;
            }
        }

        return (result.ToArray(), lineEndNumber);
    }

    public static byte[] Decode(byte[] bytes, int matrixIndex)
    {
        if (bytes is null)
        {
            throw new ArgumentNullException(nameof(bytes), "can't be null.");
        }

        if (bytes.Length == 0)
        {
            throw new ArgumentException(nameof(bytes), "can't be empty.");
        }

        var byteFrequencies = new int[_alphabetSize];
        for (int i = 0; i < bytes.Length; ++i)
        {
            ++byteFrequencies[bytes[i]];
        }

        int sum = 0;
        for (int i = 0; i < _alphabetSize; ++i)
        {
            sum += byteFrequencies[i];
            byteFrequencies[i] = sum - byteFrequencies[i];
        }

        var nextBytesIndexes = new int[bytes.Length];
        for (int i = 0; i < bytes.Length; ++i)
        {
            nextBytesIndexes[byteFrequencies[bytes[i]]] = i;
            ++byteFrequencies[bytes[i]];
        }

        var nextByte = nextBytesIndexes[matrixIndex];
        var result = new byte[bytes.Length];
        for (int i = 0; i < bytes.Length; ++i)
        {
            result[i] = bytes[nextByte];
            nextByte = nextBytesIndexes[nextByte];
        }

        return result;
    }
}