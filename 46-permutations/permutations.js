/**
 * @param {number[]} nums
 * @return {number[][]}
 */
var permute = function(nums) {
    let result=[];
    function backtrack(path,options){
        if(options.length===0){
            result.push([...path]);
            return;
        }
        for(let i=0;i<options.length;i++){
            path.push(options[i]);
            backtrack(path,options.filter((_,index)=>index !==i));
            path.pop();
        }
    }
    backtrack([],nums);
    return result;
};