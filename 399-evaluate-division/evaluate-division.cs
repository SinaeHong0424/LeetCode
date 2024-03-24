public class Solution {
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        var graph = new Dictionary<string, Dictionary<string, double>>();

        for (int i = 0; i < equations.Count; i++) {
            var equation = equations[i];
            if (!graph.ContainsKey(equation[0])) {
                graph[equation[0]] = new Dictionary<string, double>();
            }
            if (!graph.ContainsKey(equation[1])) {
                graph[equation[1]] = new Dictionary<string, double>();
            }

            graph[equation[0]][equation[1]] = values[i];
            graph[equation[1]][equation[0]] = 1.0 / values[i];
        }

        double[] results = new double[queries.Count];

        for (int i = 0; i < queries.Count; i++) {
            var query = queries[i];
            results[i] = DFS(query[0], query[1], graph, new HashSet<string>(), 1.0);
        }

        return results;
    }

    private double DFS(string start, string end, IDictionary<string, Dictionary<string, double>> graph, HashSet<string> visited, double value) {
        if (!graph.ContainsKey(start)) return -1.0; 
        if (start == end) return value; 
        visited.Add(start);

        foreach (var neighbor in graph[start]) {
            if (visited.Contains(neighbor.Key)) continue; 
            double result = DFS(neighbor.Key, end, graph, visited, value * neighbor.Value);
            if (result != -1.0) return result; 
        }

        return -1.0; 
    }
}
