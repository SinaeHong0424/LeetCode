/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var findKthLargest = function(nums, k) {
    let heap = [];
    
    for (let num of nums) {
        if (heap.length < k) {
            heap.push(num);
            if (heap.length === k) {
                heap.sort((a, b) => a - b); 
            }
        } else {
            if (num > heap[0]) {
                heap[0] = num; 
                let i = 0;
                while (true) {
                    let left = 2 * i + 1;
                    let right = 2 * i + 2;
                    let smallest = i;
                    
                    if (left < heap.length && heap[left] < heap[smallest]) {
                        smallest = left;
                    }
                    if (right < heap.length && heap[right] < heap[smallest]) {
                        smallest = right;
                    }
                    if (smallest === i) break;
                    
                    [heap[i], heap[smallest]] = [heap[smallest], heap[i]];
                    i = smallest;
                }
            }
        }
    }
    
    return heap[0]; 
};