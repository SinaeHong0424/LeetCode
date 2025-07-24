/**
 * @param {number} numerator
 * @param {number} denominator
 * @return {string}
 */
var fractionToDecimal = function(numerator, denominator) {
    if(numerator ===0) return "0";
    let result="";
    if((numerator <0) ^ (denominator <0)){result +="-";}
    let num=Math.abs(numerator);
    let den=Math.abs(denominator);
    result +=Math.floor(num/den);
    num %=den;
    if(num===0)return result;
    result +=".";
    let map=new Map();
    while (num !==0){
        if(map.has(num)){
            result =result.slice(0,map.get(num))+"("+result.slice(map.get(num))+")";
            break;
        }
        map.set(num,result.length);
        num *=10;
        result +=Math.floor(num/den);
        num %=den;
    }
    return result;
};