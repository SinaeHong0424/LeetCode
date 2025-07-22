/**
 * @param {number[]} nums
 * @return {number}
 */
var maximumGap = function(nums) {
    const n = nums.length;
    if (n < 2) return 0;
    let minVal = Math.min(...nums);
    let maxVal = Math.max(...nums);
    let bucketSize = Math.max(1, Math.floor((maxVal - minVal) / (n - 1)));
    let bucketCount = Math.floor((maxVal - minVal) / bucketSize) + 1;
    const buckets = new Array(bucketCount).fill(null).map(() => ({
        min: Infinity,
        max: -Infinity,
        used: false
    }));
    for (let num of nums) {
        const idx = Math.floor((num - minVal) / bucketSize);
        buckets[idx].min = Math.min(buckets[idx].min, num);
        buckets[idx].max = Math.max(buckets[idx].max, num);
        buckets[idx].used = true;
    }
    let maxGap = 0;
    let prevMax = minVal;
    for (let bucket of buckets) {
        if (!bucket.used) continue;
        maxGap = Math.max(maxGap, bucket.min - prevMax);
        prevMax = bucket.max;
    }
    return maxGap;
};
