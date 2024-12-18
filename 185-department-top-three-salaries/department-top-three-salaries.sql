WITH UniqueSalaries AS (
    SELECT 
        e.id,
        e.name,
        e.salary,
        e.departmentId,
        DENSE_RANK() OVER (PARTITION BY e.departmentId ORDER BY e.salary DESC) AS salary_rank
    FROM 
        Employee e
),
TopSalaries AS (
    SELECT 
        u.id,
        u.name,
        u.salary,
        d.name AS department
    FROM 
        UniqueSalaries u
    JOIN 
        Department d
    ON 
        u.departmentId = d.id
    WHERE 
        u.salary_rank <= 3
)
SELECT 
    department AS Department,
    name AS Employee,
    salary AS Salary
FROM 
    TopSalaries
ORDER BY 
    department, 
    salary DESC;
