/**
 * @param {string} s1
 * @param {string} s2
 * @param {string} s3
 * @return {boolean}
 */
var isInterleave=function(s1,s2,s3){
    const m=s1.length, n=s2.length, k=s3.length;
    if(m+n !==k) return false;
    const dp=Array(n+1).fill(false);
    for (let i=0; i<=m; i++){
        let prev=Array(n+1).fill(false);
        for(let j=0; j<=n; j++){
            if(i===0 &&j===0){prev[j]=true;}
            else if(i===0){prev[j]=prev[j-1]&&s2[j-1]===s3[j-1];}
            else if(j===0){prev[j]=dp[j] && s1[i-1]===s3[i-1];}
            else{prev[j]=(prev[j-1] && s2[j-1]===s3[i+j-1]) || (dp[j]&&s1[i-1]===s3[i+j-1]);}
        }
        dp.splice(0,dp.length,...prev);
    }
    return dp[n];
};