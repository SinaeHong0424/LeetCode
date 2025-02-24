/**
*@param{string}s
*@return {number}
*/
var calculate=function(s){
    let stack=[], num=0, sign=1,result=0;
    for (let i=0; i<s.length; i++){
        let char=s[i];
        if(char >='0'&& char<='9'){num=num*10+parseInt(char);}
        else if(char ==='+'){result +=sign*num;sign=1;num=0;}
        else if(char==='-'){result +=sign*num; sign=-1;num=0;}
        else if(char==='('){stack.push(result);stack.push(sign);result=0; sign=1;}
        else if(char===')'){result +=sign*num; result *=stack.pop();result +=stack.pop();num=0;}
    }result +=sign *num; return result;
};
