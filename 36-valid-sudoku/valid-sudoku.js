/**
 * @param {character[][]} board
 * @return {boolean}
 */
var isValidSudoku = function(board) {
    let rows=new Array(9).fill().map(()=>new Set());
    let cols=new Array(9).fill().map(()=> new Set());
    let boxes =new Array(9).fill().map(()=>new Set());

    for (let r=0; r<9; r++){
        for (let c =0; c<9; c++){
            let val=board[r][c];
            if( val==='.') continue;

            let boxIndex=Math.floor(r/3)*3+Math.floor(c/3);

            if(rows[r].has(val) || cols[c].has(val) || boxes[boxIndex].has(val)){
                return false;
            }
            rows[r].add(val);
            cols[c].add(val);
            boxes[boxIndex].add(val);
        }
    }return true;
};