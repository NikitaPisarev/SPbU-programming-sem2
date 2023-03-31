namespace ConfigurationGenerator;

using System.Text;
using System.Text.RegularExpressions;
using UniqueList;

public static class ConfigurationGenerator
{
    public static string CreateOptimalConfiguration(string network)
    {
        if (network == string.Empty)
        {
            throw new ArgumentException("Network can't be empty.");
        }

        (var edges, var routersCount) = _parseNetwork(network);

        var configuration = new List<_edgeOfTheNetwork>();
        var connectedRouters = new UniqueList();
        connectedRouters.Add(1);

        while (connectedRouters.Count < routersCount)
        {
            _edgeOfTheNetwork currentMaximumEdge = _currentMaximumEdge(edges, connectedRouters);

            if (currentMaximumEdge.Bandwidth == -1)
            {
                throw new ArgumentException("The network is disconnected.");
            }

            connectedRouters.Add(currentMaximumEdge.FirstRouter);
            connectedRouters.Add(currentMaximumEdge.SecondRouter);

            configuration.Add(currentMaximumEdge);
        }

        return _buildConfigurationForFile(configuration, routersCount);
    }

    private class _edgeOfTheNetwork
    {
        internal _edgeOfTheNetwork(int firstRouter, int secondRouter, int bandwidth)
        {
            this.FirstRouter = firstRouter;
            this.SecondRouter = secondRouter;
            this.Bandwidth = bandwidth;
        }

        internal int FirstRouter { get; }

        internal int SecondRouter { get; }

        internal int Bandwidth { get; }
    }

    private static _edgeOfTheNetwork _currentMaximumEdge(_edgeOfTheNetwork[] edges, UniqueList connectedRouters)
    {
        var result = new _edgeOfTheNetwork(0, 0, -1);
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

    private static (_edgeOfTheNetwork[], int) _parseNetwork(string network)
    {
        var routers = new UniqueList();
        var edges = new List<_edgeOfTheNetwork>();

        foreach (var routerInfo in network.Split("\n"))
        {
            var dataMainRouter = routerInfo.Split(":");
            var mainRouter = int.Parse(dataMainRouter[0]);

            var bandwidths = new Regex(@"\(\d+\)").Matches(dataMainRouter[1]);
            var connectedRouters = new Regex(@" \d+ ").Matches(dataMainRouter[1]);

            for (int i = 0; i < connectedRouters.Count; ++i)
            {
                var currentConectedRouter = int.Parse(connectedRouters[i].Value);
                var currentBandwidth = int.Parse(bandwidths[i].Value.Trim(new char[] { '(', ')' }));

                edges.Add(new _edgeOfTheNetwork(mainRouter, currentConectedRouter, currentBandwidth));
                routers.Add(currentConectedRouter);
            }
            routers.Add(mainRouter);
        }

        return (edges.ToArray(), routers.Count);
    }

    private static string _buildConfigurationForFile(List<_edgeOfTheNetwork> edges, int routersCount)
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
                configuration.Append($"{i}:").Append(line.Remove(line.Length - 1, 1)).Append("\r\n");
            }
        }
        configuration.Remove(configuration.Length - 2, 2);
        return configuration.ToString();
    }
}