/**
 * @param {string} a
 * @param {string} b
 * @return {string}
 */
var addBinary = function(a, b) {
    let i=a.length-1, j=b.length-1, carry=0, result="";
    while (i>= 0 || j>=0||carry){
        let sum=carry;
        if(i>=0){sum +=parseInt(a[i]); i--;}
        if(j>=0){sum +=parseInt(b[j]);j--;}
        result=(sum%2)+result;
        carry=Math.floor(sum/2);
    }return result;
};