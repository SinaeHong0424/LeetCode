/**
 * @param {string} startGene
 * @param {string} endGene
 * @param {string[]} bank
 * @return {number}
 */
var minMutation=function(startGene, endGene, bank){
    const isValidMutation=(gene1, gene2)=>{
        let count=0; 
        for (let i=0; i<gene1.length; i++){
            if(gene1[i]!==gene2[i]) count++;
            if (count >1) return false;
        }return count===1;
    };
    const queue=[[startGene,0]];
    const visited=new Set();
    while (queue.length >0){
        const [currentGene, mutations]=queue.shift();
        if(currentGene===endGene) return mutations;
        for(const gene of bank){
            if(!visited.has(gene) && isValidMutation(currentGene, gene)){
                visited.add(gene);
                queue.push([gene,mutations+1]);
            }            
        }
    }return -1;
}