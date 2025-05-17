/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number[]}
 */
var searchRange = function(nums, target) {
    let left=findBound(nums, target, true);
    if(left===-1) return [-1,-1];
    let right=findBound(nums,target,false);
    return [left,right];
};
function findBound(nums, target,isLeft){
    let left=0, right=nums.length-1, bound=-1;
    while(left <=right){
        let mid=Math.floor((left+right)/2);
        if(nums[mid]===target){
            bound=mid;
            if(isLeft) right=mid-1;
            else left=mid+1;
        }else if(nums[mid] <target){left=mid+1;}
        else{right=mid-1;}
    }return bound;
};