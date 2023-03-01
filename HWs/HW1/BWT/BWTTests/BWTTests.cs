namespace BWTTests;

public class Tests
{
    [Test]
    public void Encode_BasicString_BasicStringReturned()
    {
        var originalString = "ABACABA";
        var expected = ("BCABAAA", 2);

        var actual = BWT.Program.Encode(originalString);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Encode_EmptyString_ZeroReturned()
    {
        var originalString = "";
        var expected = ("", 0);

        var actual = BWT.Program.Encode(originalString);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Decode_BasicStringAndNumber_BasicStringReturned()
    {
        var originalString = "BCABAAA";
        int originalNumber = 2;
        var expectedString = "ABACABA";

        var actual = BWT.Program.Decode(originalString, originalNumber);

        Assert.That(actual, Is.EqualTo(expectedString));
    }

    [Test]
    public void Decode_EmptyString_ExceptionReturned()
    {
        var originalString = "";
        var originalNumber = 0;

        try
        {
            var actual = BWT.Program.Decode(originalString, originalNumber);
        }
        catch (ArgumentException)
        {
            Assert.Pass();
        }
        Assert.Fail();
    }
}