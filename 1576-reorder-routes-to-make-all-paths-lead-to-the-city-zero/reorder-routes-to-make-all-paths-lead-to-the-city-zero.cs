public class Solution {
    public int MinReorder(int n, int[][] connections) {
        var graph = new Dictionary<int, List<int[]>>();
        

        for (int i = 0; i < n; i++) {
            graph[i] = new List<int[]>();
        }
        
            foreach (var connection in connections) {
            graph[connection[0]].Add(new int[] { connection[1], 1 }); // from a to b, needs reorientation
            graph[connection[1]].Add(new int[] { connection[0], 0 }); // from b to a, does not need reorientation
        }
        
        return Dfs(graph, 0, new HashSet<int>());
    }

    private int Dfs(Dictionary<int, List<int[]>> graph, int node, HashSet<int> visited) {
        int changes = 0;
        visited.Add(node);
        
        foreach (var neighbor in graph[node]) {
            if (!visited.Contains(neighbor[0])) {
                changes += neighbor[1];
                changes += Dfs(graph, neighbor[0], visited);
            }
        }
        
        return changes;
    }
}
