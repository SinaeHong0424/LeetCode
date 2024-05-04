public class Solution {
    public long MaxScore(int[] nums1, int[] nums2, int k) {
        int n = nums1.Length;
        PriorityQueue<(int val, int idx), int> nums2Max = new PriorityQueue<(int val, int idx), int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));

        // Push all elements of nums2 along with their indices into the priority queue to get the largest elements of nums2
        for (int i = 0; i < n; i++) {
            nums2Max.Enqueue((nums2[i], i), nums2[i]);
        }

        long currSum = 0, mini = int.MaxValue, ans = 0;
        PriorityQueue<int, int> temp = new PriorityQueue<int, int>();

        // 'temp' priority queue stores the elements of nums1 that are contributing to currSum
        // Let's get the top k elements from nums2, and the minimum of those elements will be stored in 'mini'
        // Also, the sum of the corresponding elements in nums1 will be stored in 'currSum'
        while (k-- > 0) {
            var top = nums2Max.Dequeue();
            mini = top.val;
            currSum += nums1[top.idx];
            temp.Enqueue(nums1[top.idx], nums1[top.idx]);
        }

        ans = currSum * mini;

        // Setting the currSum * mini as the answer considering the top k indices of nums2
        // Now we will remove the element/index that contributes the least to the sum
        // and add an element corresponding to the next (k+1 for the first iteration) element
        while (nums2Max.Count > 0) {
            currSum -= temp.Dequeue();
            var top = nums2Max.Dequeue();
            mini = top.val;
            currSum += nums1[top.idx];
            ans = Math.Max(ans, currSum * mini);
            temp.Enqueue(nums1[top.idx], nums1[top.idx]);
        }

        return ans;
    }
}