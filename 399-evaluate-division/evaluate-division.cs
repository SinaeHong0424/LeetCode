using System;
using System.Collections.Generic;

public class Solution {
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        Dictionary<string, Dictionary<string, double>> graph = new Dictionary<string, Dictionary<string, double>>();
        
        for (int i = 0; i < equations.Count; i++) {
            string A = equations[i][0];
            string B = equations[i][1];
            double value = values[i];
            
            if (!graph.ContainsKey(A)) {
                graph[A] = new Dictionary<string, double>();
            }
            if (!graph.ContainsKey(B)) {
                graph[B] = new Dictionary<string, double>();
            }
            
            graph[A][B] = value;
            graph[B][A] = 1.0 / value;
        }
        
        double[] results = new double[queries.Count];
        for (int i = 0; i < queries.Count; i++) {
            string C = queries[i][0];
            string D = queries[i][1];
            
            if (!graph.ContainsKey(C) || !graph.ContainsKey(D)) {
                results[i] = -1.0;
            } else if (C == D) {
                results[i] = 1.0;
            } else {
                HashSet<string> visited = new HashSet<string>();
                results[i] = DFS(graph, C, D, 1.0, visited);
            }
        }
        
        return results;
    }

    private double DFS(Dictionary<string, Dictionary<string, double>> graph, string start, string end, double product, HashSet<string> visited) {
        visited.Add(start);
        
        if (graph[start].ContainsKey(end)) {
            return product * graph[start][end];
        }
        
        foreach (var neighbor in graph[start]) {
            if (!visited.Contains(neighbor.Key)) {
                double result = DFS(graph, neighbor.Key, end, product * neighbor.Value, visited);
                if (result != -1.0) {
                    return result;
                }
            }
        }
        
        return -1.0;
    }
}
