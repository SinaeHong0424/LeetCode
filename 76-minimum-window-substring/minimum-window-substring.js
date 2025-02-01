/**
 * @param {string} s
 * @param {string} t
 * @return {string}
 */
var minWindow = function(s, t) {
    if(t.length > s.length) return "";
    const tFreq={};
    for (const char of t){
        tFreq[char]=(tFreq[char] || 0)+1;
    }
    let required=Object.keys(tFreq).length, left=0, right=0, formed=0;
    const windowCounts={};
    let ans=[-1,0,0];
    while (right <s.length){
        const char=s[right];
        windowCounts[char]=(windowCounts[char] ||0)+1;
        if(tFreq[char] && windowCounts[char]===tFreq[char]){formed++;}
        while (left <=right && formed===required){
            let char = s[left];
            if(ans[0]===-1 || right-left+1 <ans[0]){
                ans[0]=right-left+1;
                ans[1]=left;
                ans[2]=right;
            }
            windowCounts[char]--;
            if(tFreq[char] && windowCounts[char]<tFreq[char]){formed--;}
            left++;
        }right++;
    }return ans[0]===-1? "":s.slice(ans[1],ans[2]+1);
};