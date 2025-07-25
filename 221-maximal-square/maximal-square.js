/**
 * @param {character[][]} matrix
 * @return {number}
 */
var maximalSquare = function(matrix) {
    if(!matrix.length) return 0;
    let m=matrix.length,n=matrix[0].length;
    let dp=Array(m).fill(null).map(()=>Array(n).fill(0));
    let maxSide=0;
    for(let i=0; i<m; i++){
        for (let j=0; j<n; j++){
            if(matrix[i][j]==='1'){
                if(i===0 || j===0){dp[i][j]=1;}
                else{dp[i][j]=Math.min(dp[i-1][j],dp[i][j-1],dp[i-1][j-1])+1;}
                maxSide=Math.max(maxSide,dp[i][j]);
            }
        }

    }
    return maxSide*maxSide;
};