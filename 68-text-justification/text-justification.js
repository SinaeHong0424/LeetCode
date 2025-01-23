/**
 * @param {string[]} words
 * @param {number} maxWidth
 * @return {string[]}
 */
var fullJustify = function(words, maxWidth) {
    const result=[];
    let line=[],lineLength=0;
    for (let word of words){
        if (lineLength + line.length +word.length > maxWidth){
            for (let i=0; i<maxWidth -lineLength; i++){
                line[i % (line.length-1 || 1)] += ' ';
            }result.push(line.join(''));
            line=[];
            lineLength=0;
        }line.push(word);
        lineLength +=word.length;
    }result.push(line.join(' ')+' '.repeat(maxWidth-lineLength-line.length+1));
    return result;
};