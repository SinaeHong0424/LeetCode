/**
 * @param {number[][]} matrix
 * @param {number} target
 * @return {boolean}
 */
var searchMatrix = function(matrix, target) {
    let m=matrix.length, n=matrix[0].length, left=0, right=m*n-1;
    while (left <=right){
        let mid=Math.floor((left+right)/2), row=Math.floor(mid/n), col=mid%n, midValue=matrix[row][col];
        if(midValue===target) return true;
        if(midValue <target) left=mid+1;
        else right=mid-1; 
    }
    return false;
};