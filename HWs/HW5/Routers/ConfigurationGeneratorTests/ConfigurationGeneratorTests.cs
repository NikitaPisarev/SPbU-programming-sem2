namespace ConfigurationGeneratorTests;

using ConfigurationGenerator;

public class Tests
{
    [Test]
    public void CreateOptimalConfiguration_CorrectConfiguration_CorrectOptimalConfigurationReturn()
    {
        var network = """
        1: 2 (10), 3 (5)
        2: 3 (1)
        """;
        var expected = """
        1: 2 (10), 3 (5)
        """;

        var actual = ConfigurationGenerator.CreateOptimalConfiguration(network);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CreateOptimalConfiguration_LongCorrectConfiguration_CorrectOptimalConfigurationReturn()
    {
        var network = """
        1: 4 (4), 5 (11), 2 (6), 3 (5)
        2: 7 (12)
        3: 7 (10)
        4: 6 (9)
        5: 6 (1)
        6: 9 (11)
        7: 8 (30)
        8: 9 (15)
        """;
        var expected = """
        1: 5 (11), 2 (6)
        2: 7 (12)
        3: 7 (10)
        4: 6 (9)
        6: 9 (11)
        7: 8 (30)
        8: 9 (15)
        """;

        var actual = ConfigurationGenerator.CreateOptimalConfiguration(network);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CreateOptimalConfiguration_DisconnectedConfiguration_ArgumentException()
    {
        var network = """
        1: 3 (4), 2 (1), 6 (5), 5 (6)
        4: 7 (3)
        """;

        Assert.Throws<ArgumentException>(() => ConfigurationGenerator.CreateOptimalConfiguration(network));
    }
}