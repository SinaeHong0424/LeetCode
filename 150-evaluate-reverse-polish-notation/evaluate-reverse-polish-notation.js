/**
 * @param {string[]} tokens
 * @return {number}
 */
var evalRPN = function(tokens) {
    let stack=[];
    for(let token of tokens){
        if(!isNaN(token)){stack.push(Number(token));}
        else{
            let b=stack.pop(),a=stack.pop();
            switch(token){
                case '+': stack.push(a+b);break;
                case '-': stack.push(a-b);break;
                case '*': stack.push(a*b);break;
                case '/': stack.push(Math.trunc(a/b));break;
            }
        }
    }return stack[0];
};