WITH DailyTotals AS (
    SELECT
        visited_on,
        SUM(amount) AS daily_total
    FROM Customer
    GROUP BY visited_on
),
Aggregated AS (
    SELECT 
        visited_on,
        SUM(daily_total) OVER (ORDER BY visited_on ROWS BETWEEN 6 PRECEDING AND CURRENT ROW) AS rolling_total,
        COUNT(daily_total) OVER (ORDER BY visited_on ROWS BETWEEN 6 PRECEDING AND CURRENT ROW) AS total_days
    FROM DailyTotals
)
SELECT 
    visited_on,
    rolling_total AS amount,
    ROUND(rolling_total * 1.0 / total_days, 2) AS average_amount
FROM Aggregated
WHERE total_days = 7
ORDER BY visited_on;

