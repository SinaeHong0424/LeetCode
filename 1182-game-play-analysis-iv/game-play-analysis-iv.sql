# Write your MySQL query statement below
WITH first_logins AS (
  SELECT
    player_id,
    MIN(event_date) AS first_login
  FROM
    Activity
  GROUP BY
    player_id
),
consecutive_logins AS (
  SELECT
    fl.player_id,
    COUNT(DISTINCT a.event_date) AS num_consecutive_days
  FROM
    first_logins fl
    JOIN Activity a ON a.player_id = fl.player_id
      AND a.event_date >= fl.first_login
      AND a.event_date <= DATE_ADD(fl.first_login, INTERVAL 1 DAY)
  GROUP BY
    fl.player_id
)
SELECT
  ROUND(SUM(CASE WHEN num_consecutive_days > 1 THEN 1 ELSE 0 END) / COUNT(*), 2) AS fraction
FROM
  consecutive_logins;