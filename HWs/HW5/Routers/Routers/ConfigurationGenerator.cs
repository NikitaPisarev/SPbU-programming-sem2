namespace ConfigurationGenerator;

using System.Text;
using System.Text.RegularExpressions;
using UniqueList;

/// <summary>
/// A class for building the optimal configuration of routers, which is the maximum spanning tree.
/// </summary>
public static class ConfigurationGenerator
{
    /// <summary>
    /// Generation of the maximum spanning tree by the Prim's algorithm.
    /// </summary>
    /// <param name="network"> Initial network. </param>
    /// <returns> Optimal network. </returns>
    public static string CreateOptimalConfiguration(string network)
    {
        if (network == string.Empty)
        {
            throw new ArgumentException("Network can't be empty.");
        }

        EdgeOfTheNetwork[]? edges = null;
        int routersCount = 0;

        try
        {
            (edges, routersCount) = ParseNetwork(network);
        }
        catch (ArgumentException)
        {
            throw;
        }

        var configuration = new List<EdgeOfTheNetwork>();
        var connectedRouters = new UniqueList();
        connectedRouters.Add(1);

        while (connectedRouters.Count < routersCount)
        {
            EdgeOfTheNetwork currentMaximumEdge = CurrentMaximumEdge(edges, connectedRouters);

            if (currentMaximumEdge.Bandwidth == -1)
            {
                throw new ArgumentException("The network is disconnected.");
            }

            connectedRouters.Add(currentMaximumEdge.FirstRouter);
            connectedRouters.Add(currentMaximumEdge.SecondRouter);

            configuration.Add(currentMaximumEdge);
        }

        return BuildConfigurationForFile(configuration, routersCount);
    }

    private class EdgeOfTheNetwork
    {
        internal EdgeOfTheNetwork(int firstRouter, int secondRouter, int bandwidth)
        {
            this.FirstRouter = firstRouter;
            this.SecondRouter = secondRouter;
            this.Bandwidth = bandwidth;
        }

        internal int FirstRouter { get; }
        internal int SecondRouter { get; }
        internal int Bandwidth { get; }
    }

    private static EdgeOfTheNetwork CurrentMaximumEdge(EdgeOfTheNetwork[] edges, UniqueList connectedRouters)
    {
        var result = new EdgeOfTheNetwork(0, 0, -1);
        foreach (var edge in edges)
        {
            var incidentWithTheFirst = connectedRouters.Contains(edge.FirstRouter) && !connectedRouters.Contains(edge.SecondRouter);
            var incidentWithTheSecond = !connectedRouters.Contains(edge.FirstRouter) && connectedRouters.Contains(edge.SecondRouter);

            if ((incidentWithTheFirst || incidentWithTheSecond) && result.Bandwidth < edge.Bandwidth)
            {
                result = edge;
            }
        }
        return result;
    }

    private static (EdgeOfTheNetwork[], int) ParseNetwork(string network)
    {
        var routers = new UniqueList();
        var edges = new List<EdgeOfTheNetwork>();

        foreach (var routerInfo in network.Split("\n"))
        {
            if (!IsCorrectLine(routerInfo))
            {
                throw new ArgumentException("Invalid network.");
            }

            var dataMainRouter = routerInfo.Split(":");
            var mainRouter = int.Parse(dataMainRouter[0]);

            var bandwidths = new Regex(@"\(\d+\)").Matches(dataMainRouter[1]);
            var connectedRouters = new Regex(@" \d+ ").Matches(dataMainRouter[1]);

            for (int i = 0; i < connectedRouters.Count; ++i)
            {
                var currentConectedRouter = int.Parse(connectedRouters[i].Value);
                var currentBandwidth = int.Parse(bandwidths[i].Value.Trim(new char[] { '(', ')' }));

                edges.Add(new EdgeOfTheNetwork(mainRouter, currentConectedRouter, currentBandwidth));
                routers.Add(currentConectedRouter);
            }
            routers.Add(mainRouter);
        }

        return (edges.ToArray(), routers.Count);
    }

    private static string BuildConfigurationForFile(List<EdgeOfTheNetwork> edges, int routersCount)
    {
        var configuration = new StringBuilder();
        var connectedRouters = new UniqueList();

        for (int i = 1; i <= routersCount; ++i)
        {
            var line = new StringBuilder();
            foreach (var edge in edges)
            {
                if (edge.FirstRouter == i && !connectedRouters.Contains(edge.SecondRouter))
                {
                    line.Append($" {edge.SecondRouter} ({edge.Bandwidth}),");
                }
                if (edge.SecondRouter == i && !connectedRouters.Contains(edge.FirstRouter))
                {
                    line.Append($" {edge.FirstRouter} ({edge.Bandwidth}),");
                }
            }

            connectedRouters.Add(i);
            if (line.ToString() != string.Empty)
            {
                configuration.Append($"{i}:").Append(line.Remove(line.Length - 1, 1)).Append("\n");
            }
        }
        configuration.Remove(configuration.Length - 1, 1);
        return configuration.ToString();
    }
    private static bool IsCorrectLine(string line)
        => Regex.IsMatch(line, @"^\d+: (\d+ \(\d+\),? ?)+$");
}