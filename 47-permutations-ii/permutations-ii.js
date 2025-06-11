/**
 * @param {number[]} nums
 * @return {number[][]}
 */
var permuteUnique=function(nums){
    const res=[];
    nums.sort((a,b)=>a-b);
    backtrack(nums,[],Array(nums.length).fill(false),res);
    return res;
};
function backtrack(nums, tempList,used,res){
    if(tempList.length===nums.length){
        res.push([...tempList]);
        return;
    }
    for(let i=0; i<nums.length; i++){
        if(used[i]) continue;
        if(i>0 && nums[i]===nums[i-1] && !used[i-1]) continue;
        used[i]=true;
        tempList.push(nums[i]);
        backtrack(nums,tempList,used,res);
        used[i]=false;
        tempList.pop();
    }
}