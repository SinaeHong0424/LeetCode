# Write your MySQL query statement below
SELECT e1.name
FROM Employee e1
JOIN (
    SELECT managerId, COUNT(*) AS report_count
    FROM Employee
    GROUP BY managerId
) AS e2
ON e1.id = e2.managerId
WHERE e2.report_count >= 5;
