/**
 * @param {number} numCourses
 * @param {number[][]} prerequisites
 * @return {number[]}
 */
var findOrder = function(numCourses, prerequisites) {
    const inDegree=new Array(numCourses).fill(0);
    const graph=Array.from({length: numCourses},()=>[]);
    for (const [course, prerequisite] of prerequisites){
        inDegree[course]++;
        graph[prerequisite].push(course);
    }
    const queue=[];
    for (let i=0; i<numCourses; i++){
        if(inDegree[i]===0){queue.push(i);}
    }
    const order=[];
    while(queue.length >0){
        const current=queue.shift();
        order.push(current);
        for(const neighbor of graph[current]){
            inDegree[neighbor]--;
            if(inDegree[neighbor]===0){queue.push(neighbor);}
        }
    }
    if (order.length===numCourses){
        return order;
    }
    return [];
};