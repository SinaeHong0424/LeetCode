/**
 * @param {number[]} candidates
 * @param {number} target
 * @return {number[][]}
 */
var combinationSum = function(candidates, target) {
    let result=[];
    const backtrack=(remainingTarget, currentCombination, startIndex)=>{
        if(remainingTarget===0){
            result.push([...currentCombination]);
            return;
        }
        for(let i=startIndex; i<candidates.length; i++){
            if(candidates[i]<=remainingTarget){
                currentCombination.push(candidates[i]);
                backtrack(remainingTarget-candidates[i],currentCombination,i);
                currentCombination.pop();
            }
        }
    };
    backtrack(target,[],0);
    return result;
};