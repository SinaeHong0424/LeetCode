/**
 * @param {number[]} nums
 * @return {number}
 */
var maxSubarraySumCircular = function(nums) {
    let maxSum=nums[0],minSum=nums[0], total=nums[0], curMax=nums[0],curMin=nums[0];
    for (let i=1; i<nums.length; i++){
        curMax=Math.max(nums[i], curMax+nums[i]);
        maxSum=Math.max(maxSum, curMax);
        curMin=Math.min(nums[i],curMin+nums[i]);
        minSum=Math.min(minSum,curMin);
        total +=nums[i];
    }
    return maxSum > 0 ? Math.max(maxSum, total-minSum):maxSum;
};