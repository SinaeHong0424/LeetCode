public class Solution{
    public int FindCircleNum(int[][] isConnected) {
        int n=isConnected.Length;
        bool[] visited =new bool[n];
        int count=0;

        for (int i =0; i<n; i++){
            if (!visited[i]) {
                Dfs(isConnected, visited, i);
                count++;
            }
        }
        return count;
    }
    private void Dfs(int[][] isConnected, bool[] visited, int i){
        for (int j=0; j<isConnected.Length; j++){
            if (isConnected[i][j] ==1 && !visited[j]){
                visited[j]=true;
                Dfs(isConnected, visited,j);
            }
        }
    }
}