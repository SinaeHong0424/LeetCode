/**
 * @param {number[]} coins
 * @param {number} amount
 * @return {number}
 */
var coinChange = function(coins, amount) {
    // Create an array to store the minimum number of coins needed for each amount
    let dp = new Array(amount + 1).fill(Infinity);
    dp[0] = 0; // Base case: 0 amount requires 0 coins

    for (let coin of coins) {
        for (let i = coin; i <= amount; i++) {
            dp[i] = Math.min(dp[i], dp[i - coin] + 1);
        }
    }

    return dp[amount] === Infinity ? -1 : dp[amount];
};