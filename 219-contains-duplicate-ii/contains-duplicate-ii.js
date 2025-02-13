/**
 * @param {number[]} nums
 * @param {number} k
 * @return {boolean}
 */
var containsNearbyDuplicate = function(nums, k) {
    let numIndices=new Map();
    for (let i=0; i<nums.length; i++){
        if(numIndices.has(nums[i])&& (i-numIndices.get(nums[i])<=k)){return true;}
        numIndices.set(nums[i],i);
    }return false;
};