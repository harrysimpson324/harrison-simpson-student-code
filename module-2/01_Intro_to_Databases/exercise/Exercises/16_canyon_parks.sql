-- 16. The name, date established, and area of parks that contain the string "Canyon" anywhere in the name.
-- Order the results by date established, oldest first.
-- (5 rows)
SELECT park_name, date_established, area
FROM park
WHERE park_name like '%Canyon%'
ORDER BY date_established;
