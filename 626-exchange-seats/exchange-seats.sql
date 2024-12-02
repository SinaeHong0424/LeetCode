# Write your MySQL query statement below
select case when Mod(id, 2) =0 then id-1 else case when id=(select max(id) from Seat)
and mod(id,2)=1 then id else id+1 end end as id, student from Seat order by id;