/**
 * @param {number[]} nums
 * @return {string[]}
 */
var summaryRanges = function(nums) {
    const ranges = [];
    if (nums.length === 0) return ranges;
    
    let start = nums[0];
    
    for (let i = 1; i <= nums.length; i++) {
        if (i === nums.length || nums[i] !== nums[i - 1] + 1) {
            if (start === nums[i - 1]) {ranges.push(`${start}`);} 
            else {ranges.push(`${start}->${nums[i - 1]}`);}
            start = nums[i];
        }
    }
    
    return ranges;
};
