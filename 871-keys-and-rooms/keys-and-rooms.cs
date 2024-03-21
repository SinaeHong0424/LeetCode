public class Solution {
    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        HashSet<int> visited = new HashSet<int>();
        VisitRoom(0, rooms, visited);
        return visited.Count == rooms.Count;
    }
    
    private void VisitRoom(int roomIndex, IList<IList<int>> rooms, HashSet<int> visited) {
        visited.Add(roomIndex);
        
        foreach (var key in rooms[roomIndex]) {
            if (!visited.Contains(key)) {
                VisitRoom(key, rooms, visited);
            }
        }
    }
}
