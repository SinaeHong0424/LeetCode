public class Solution{
    public int Jump(int[] nums){
        int n=nums.Length;
        if (n<=1) return 0;

        int jumps=0, currentEnd=0, farthest=0;
        for (int i=0; i<n-1; i++){
            farthest=Math.Max(farthest, i+nums[i]);
            if(i==currentEnd){
                jumps++;
                currentEnd=farthest;
            }if(currentEnd>=n-1)break;
        }return jumps;
    }
}