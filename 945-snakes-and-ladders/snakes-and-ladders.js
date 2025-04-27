/**
 * @param {number[][]} board
 * @return {number}
 */
var snakesAndLadders = function(board) {
    const n=board.length;
    const getPosition=(square)=>{
        let row=Math.floor((square-1)/n);
        let col=(square-1)%n;
        if(row %2===1) col=n-1-col;
        row=n-1-row;
        return [row,col];
    };
    let visited=new Set();
    let queue=[[1,0]];
    while(queue.length >0){
        let[curr, moves]=queue.shift();
        if(curr===n*n) return moves;
        for(let dice=1; dice <=6; dice++){
            let next=curr+dice;
            if(next > n* n)break;
            const [r,c]=getPosition(next);
            if(board[r][c]!==-1){next=board[r][c];}
            if(!visited.has(next)){
                visited.add(next);
                queue.push([next,moves+1]);
            }
        }
    }return -1;
};