/**
 * @param {string} s
 * @return {string[][]}
 */
const isPalindrome=(str)=>{
    let left=0; right=str.length-1;
    while (left<right){
        if(str[left] !==str[right]) return false;
        left++;
        right--;
    }
    return true;
};
var partition=function(s){
    const result=[];
    const backtrack=(start,path)=>{
        if(start===s.length){
            result.push([...path]);
            return;
        }
        for(let end=start+1; end <=s.length; end++){
            const substr=s.slice(start,end);
            if(isPalindrome(substr)){
                path.push(substr);
                backtrack(end,path);
                path.pop();
            }
        }
    };
    backtrack(0,[]);
    return result;
};