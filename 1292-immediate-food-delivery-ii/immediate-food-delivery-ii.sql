# Write your MySQL query statement below
SELECT ROUND((SUM(is_immediate) / COUNT(*)) * 100, 2) AS immediate_percentage
FROM (
    SELECT 
        CASE 
            WHEN customer_pref_delivery_date = order_date THEN 1
            ELSE 0
        END AS is_immediate
    FROM Delivery
    WHERE (customer_id, order_date) IN (
        SELECT customer_id, MIN(order_date) AS first_order_date
        FROM Delivery
        GROUP BY customer_id
    )
) AS first_orders;
