/**
 * @param {string} s
 * @return {string[]}
 */
var restoreIpAddresses = function(s) {
    const res=[];
    function backtrack(start, path){
        if (path.length===4){
            if(start===s.length){
                res.push(path.join('.'));
            }
            return;
        }
        for (let len=1; len <=3; len++){
            if(start+len >s.length)break;
            const segment=s.substring(start, start+len);
            if((segment.length >1 && segment[0]==='0')||Number(segment)>255) continue;
            path.push(segment);
            backtrack(start+len,path);
            path.pop();
        }
    }
    backtrack(0,[]);return res;
};