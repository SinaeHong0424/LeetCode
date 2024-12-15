# Write your MySQL query statement below
WITH friends_count AS (
    SELECT person_id, COUNT(*) AS num_friends
    FROM (
        SELECT requester_id AS person_id, accepter_id AS friend_id
        FROM RequestAccepted
        UNION
        SELECT accepter_id AS person_id, requester_id AS friend_id
        FROM RequestAccepted
    ) friends
    GROUP BY person_id
)
SELECT person_id AS id, num_friends AS num
FROM friends_count
ORDER BY num DESC
LIMIT 1;

