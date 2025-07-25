/**
 * @param {number[]} nums
 * @return {number[][]}
 */
var subsetsWithDup = function(nums) {
    nums.sort((a,b)=>a-b);
    const res=[];
    const backtrack=(start,path)=>{
        res.push([...path]);
        for (let i=start; i<nums.length; i++){
            if(i>start && nums[i]===nums[i-1]) continue;
            path.push(nums[i]);
            backtrack(i+1,path);
            path.pop();
        }
    };
    backtrack(0,[]);
    return res;
};