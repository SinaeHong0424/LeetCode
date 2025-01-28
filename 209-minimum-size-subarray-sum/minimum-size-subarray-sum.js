/**
 * @param {number} target
 * @param {number[]} nums
 * @return {number}
 */
var minSubArrayLen = function(target, nums) {
    let n=nums.length, minLength=Infinity, left=0, sum=0;
    for (let right=0; right<n; right++){sum +=nums[right];
    while (sum >= target){
        minLength=Math.min(minLength, right-left+1);
        sum -=nums[left]; left++;
    }}return minLength===Infinity? 0:minLength;
};