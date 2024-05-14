# Write your MySQL query statement below
WITH FirstYear AS (
    SELECT 
        product_id,
        MIN(year) AS first_year
    FROM 
        Sales
    GROUP BY 
        product_id
),
FirstYearSales AS (
    SELECT 
        s.product_id,
        s.year AS first_year,
        s.quantity,
        s.price
    FROM 
        Sales s
    INNER JOIN 
        FirstYear f
    ON 
        s.product_id = f.product_id 
        AND s.year = f.first_year
)
SELECT 
    product_id,
    first_year,
    quantity,
    price
FROM 
    FirstYearSales;
