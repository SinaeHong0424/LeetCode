/**
 * @param {string[][]} equations
 * @param {number[]} values
 * @param {string[][]} queries
 * @return {number[]}
 */
var calcEquation = function(equations, values, queries) {
    let graph = new Map();

    for (let i = 0; i < equations.length; i++) {
        let [A, B] = equations[i];
        let value = values[i];

        if (!graph.has(A)) graph.set(A, new Map());
        if (!graph.has(B)) graph.set(B, new Map());

        graph.get(A).set(B, value);
        graph.get(B).set(A, 1 / value);
    }

    const dfs = (src, dest, visited) => {
        if (!graph.has(src) || !graph.has(dest)) return -1.0;
        if (src === dest) return 1.0;
        
        visited.add(src);

        for (let [neighbor, val] of graph.get(src)) {
            if (!visited.has(neighbor)) {
                let result = dfs(neighbor, dest, visited);
                if (result !== -1.0) return result * val;
            }
        }

        return -1.0;
    };

    let results = [];
    for (let [C, D] of queries) {
        results.push(dfs(C, D, new Set()));
    }

    return results;
};
