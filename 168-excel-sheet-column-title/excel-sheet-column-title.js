/**
 * @param {number} columnNumber
 * @return {string}
 */
var convertToTitle = function(columnNumber) {
    let result='';
    while (columnNumber >0){
        columnNumber--;
        let charCode=columnNumber%26;
        let char=String.fromCharCode(charCode+65);
        result=char+result;
        columnNumber=Math.floor(columnNumber/26);
    }
    return result;
};