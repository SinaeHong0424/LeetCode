/**
 * // Definition for a QuadTree node.
 * function _Node(val,isLeaf,topLeft,topRight,bottomLeft,bottomRight) {
 *    this.val = val;
 *    this.isLeaf = isLeaf;
 *    this.topLeft = topLeft;
 *    this.topRight = topRight;
 *    this.bottomLeft = bottomLeft;
 *    this.bottomRight = bottomRight;
 * };
 */

/**
 * @param {number[][]} grid
 * @return {_Node}
 */
var construct = function(grid) {
    const isUniform=(rowStart, rowEnd, colStart, colEnd)=>{
        const value=grid[rowStart][colStart];
        for(let i=rowStart; i<rowEnd; i++){
            for(let j=colStart; j<colEnd; j++){
                if(grid[i][j] !==value) return false;
            }
        }
        return true;
    };
    const buildTree=(rowStart, rowEnd, colStart,colEnd)=>{
        if(isUniform(rowStart,rowEnd, colStart,colEnd)){
            return new Node(grid[rowStart][colStart]===1,true,null,null,null,null);
        }
        const rowMid=Math.floor((rowStart+rowEnd)/2);
        const colMid=Math.floor((colStart +colEnd)/2);
        return new Node(
            true,false,
            buildTree(rowStart,rowMid,colStart,colMid),
            buildTree(rowStart,rowMid,colMid,colEnd),
            buildTree(rowMid,rowEnd,colStart,colMid),
            buildTree(rowMid, rowEnd,colMid,colEnd)
        );        
    };
    return buildTree(0,grid.length,0,grid.length);
};