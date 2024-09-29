public class Solution {
    public int Search(int[] nums, int target){
        int start=0;
        int end=nums.Length-1;
while (start <= end){if(nums[start]==target){return start;}
if(nums[end]==target){return end;}
start++;
end--;}return -1;
    }
}