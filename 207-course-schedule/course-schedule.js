/**
 * @param {number} numCourses
 * @param {number[][]} prerequisites
 * @return {boolean}
 */
var canFinish = function(numCourses, prerequisites) {
    let graph=new Map();
    let inDegree=new Array(numCourses).fill(0);
    for (let  [course, pre] of prerequisites){
        if (!graph.has(pre)) graph.set(pre,[]);
        graph.get(pre).push(course);
        inDegree[course]++;
    }
    let queue=[];
    for (let i=0; i<numCourses; i++){if (inDegree[i]===0)queue.push(i);}
    let takenCourses=0;
    while (queue.length >0){
        let course=queue.shift();
        takenCourses++;
        if(graph.has(course)){
            for (let nextCourse of graph.get(course)){inDegree[nextCourse]--;
            if(inDegree[nextCourse]===0)queue.push(nextCourse);}
        }
    }
    return takenCourses===numCourses;
};