# Write your MySQL query statement below
select employee_id from Employees e1 
where salary < 30000 and manager_id is not null and not exists (select 1 from Employees e2 
where e1.manager_id=e2.employee_id) 
order by employee_id;