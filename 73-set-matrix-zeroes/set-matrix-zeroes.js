/**
 * @param {number[][]} matrix
 * @return {void} Do not return anything, modify matrix in-place instead.
 */
var setZeroes = function(matrix) {
    let m=matrix.length, n=matrix[0].length, rows=new Set(), cols=new Set();
    for (let i=0; i<m; i++){
        for (let j=0; j<n; j++){
            if(matrix[i][j]===0){rows.add(i); cols.add(j);}
        }
    }
    for (let i=0; i<m; i++){
        for (let j=0; j<n; j++){
            if (rows.has(i) || cols.has(j)){matrix[i][j]=0;}
        }
    }
};