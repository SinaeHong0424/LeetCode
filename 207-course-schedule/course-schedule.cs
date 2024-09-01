public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        List<int>[] graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++) {
            graph[i] = new List<int>();
        }

        foreach (var prereq in prerequisites) {
            int course = prereq[0];
            int prerequisite = prereq[1];
            graph[course].Add(prerequisite);
        }

        int[] visited = new int[numCourses];

        for (int i = 0; i < numCourses; i++) {
            if (!DFS(i, graph, visited)) {
                return false; 
            }
        }

        return true; 
    }

    private bool DFS(int course, List<int>[] graph, int[] visited) {
        if (visited[course] == 1) {
            return false;
        }

        if (visited[course] == 2) {
            return true; 
        }

        visited[course] = 1;

        foreach (int prereq in graph[course]) {
            if (!DFS(prereq, graph, visited)) {
                return false; 
            }
        }

        visited[course] = 2;

        return true;
    }
}
