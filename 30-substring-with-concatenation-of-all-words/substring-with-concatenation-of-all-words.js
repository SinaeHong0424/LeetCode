/**
 * @param {string} s
 * @param {string[]} words
 * @return {number[]}
 */
var findSubstring=function(s,words){
    let wordLength=words[0].length, wordCount=words.length, 
    totalLength=wordLength*wordCount, wordMap={}, result=[];

    for (let word of words){
        if(wordMap[word]){wordMap[word]++;}
        else{wordMap[word]=1;}
    }
    for (let i=0; i<=s.length-totalLength; i++){
        let seenWords={}, j=0;

        while (j<wordCount){
            let word=s.substr(i+j*wordLength, wordLength);
            if (wordMap[word]){
                if (seenWords[word]){seenWords[word]++;}
                else{seenWords[word]=1;}
                if(seenWords[word] > wordMap[word]){break;}
            }else{break;}
            j++;
        }
        if(j===wordCount){result.push(i);}
    }return result;
}