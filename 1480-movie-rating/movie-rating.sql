# Write your MySQL query statement below
with UserRatings as(select u.name, count(r.movie_id) as rating_count
from users u join MovieRating r on u.user_id=r.user_id
group by u.name order by rating_count desc, u.name asc limit 1), 
MovieAvgRatings as (select m.title, avg(r.rating) as avg_rating from Movies m
join MovieRating r on m.movie_id=r.movie_id 
where DATE_FORMAT(r.created_at, '%Y-%m')='2020-02'
group by m.title order by avg_rating desc, m.title asc limit 1)
select ur.name as results from UserRatings ur union all 
select mar.title as results
from MovieAvgRatings mar;