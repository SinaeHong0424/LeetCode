class Node{
    constructor(key, value){
        this.key=key;
        this.value=value;
        this.prev=null;
        this.next=null;
    }
}
/**
 * @param {number} capacity
 */
var LRUCache = function(capacity) {
    this.capacity=capacity;
    this.cache=new Map();
    this.head=new Node(null,null);
    this.tail=new Node(null, null);
    this.head.next=this.tail;
    this.tail.prev=this.head;
};

/** 
 * @param {number} key
 * @return {number}
 */
 LRUCache.prototype._remove=function(node){
    node.prev.next=node.next;
    node.next.prev=node.prev;
 };
 LRUCache.prototype._insert=function(node){
    node.next=this.head.next;
    node.prev=this.head;
    this.head.next.prev=node;
    this.head.next=node;
 };
LRUCache.prototype.get = function(key) {
    if(!this.cache.has(key)) return -1;
    const node=this.cache.get(key);
    this._remove(node);
    this._insert(node);
    return node.value;
};

/** 
 * @param {number} key 
 * @param {number} value
 * @return {void}
 */
LRUCache.prototype.put = function(key, value) {
    if(this.cache.has(key)){
        this._remove(this.cache.get(key));
    }
    const newNode=new Node(key,value);
    this._insert(newNode);
    this.cache.set(key,newNode);
    if(this.cache.size>this.capacity){
        const lru=this.tail.prev;
        this._remove(lru);
        this.cache.delete(lru.key);
    }
};

/** 
 * Your LRUCache object will be instantiated and called as such:
 * var obj = new LRUCache(capacity)
 * var param_1 = obj.get(key)
 * obj.put(key,value)
 */