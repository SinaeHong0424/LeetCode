
public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        List<int>[] graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++) {
            graph[i] = new List<int>();
        }

        foreach (var prereq in prerequisites) {
            int course = prereq[0];
            int prerequisite = prereq[1];
            graph[prerequisite].Add(course);
        }

        Stack<int> stack = new Stack<int>();
        int[] visited = new int[numCourses];

        for (int i = 0; i < numCourses; i++) {
            if (!DFS(i, graph, visited, stack)) {
                return new int[0]; 
            }
        }

        return stack.ToArray();
    }

    private bool DFS(int course, List<int>[] graph, int[] visited, Stack<int> stack) {
        if (visited[course] == 1) {
            return false; 
        }

        if (visited[course] == 2) {
            return true; 
        }

        visited[course] = 1;

        foreach (int nextCourse in graph[course]) {
            if (!DFS(nextCourse, graph, visited, stack)) {
                return false; 
            }
        }

        visited[course] = 2;
        stack.Push(course);

        return true;
    }
}
