public class Solution {
    public int[] SearchRange(int[] nums, int target){
        int[] result=new int[2];
        result[0]=FindFirst(nums,target);
        result[1]=FindLast(nums,target);
        return result;
    }
    private int FindFirst(int[] nums, int target){int left=0; int right=nums.Length-1; int index=-1;
    while (left <=right){int mid=left+(right-left)/2;
    if (nums[mid]==target){
        index=mid;
        right=mid-1;
    }else if(nums[mid]<target){left=mid+1;}else{right=mid-1;}}
    return index;}private int FindLast(int[] nums, int target){
        int left=0; int right=nums.Length-1; int index=-1;
        while (left <=right){
            int mid=left+(right-left)/2;
            if(nums[mid]==target){
                index=mid;
                left=mid+1;
            }else if(nums[mid]<target){left=mid+1;}
            else{right=mid-1;}
        }return index;
    }
}