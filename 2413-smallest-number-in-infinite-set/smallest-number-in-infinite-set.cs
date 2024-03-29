

public class SmallestInfiniteSet {
    private int nextSmallest = 1; 
    private SortedSet<int> addedBack; 
    public SmallestInfiniteSet() {
        addedBack = new SortedSet<int>();
    }
    
    public int PopSmallest() {
        int smallest;
        if (addedBack.Count > 0 && addedBack.Min < nextSmallest) {
           
            smallest = addedBack.Min;
            addedBack.Remove(smallest);
        } else {
            smallest = nextSmallest;
            nextSmallest++; 
        }
        return smallest;
    }
    
    public void AddBack(int num) {
        if (num < nextSmallest) {

            addedBack.Add(num);
        }
    }
}

/**
 * Your SmallestInfiniteSet object will be instantiated and called as such:
 * SmallestInfiniteSet obj = new SmallestInfiniteSet();
 * int param_1 = obj.PopSmallest();
 * obj.AddBack(num);
 */
