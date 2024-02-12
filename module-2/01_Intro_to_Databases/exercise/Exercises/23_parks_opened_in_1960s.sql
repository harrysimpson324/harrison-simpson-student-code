-- 23. The name and date established of parks opened in the 1960s.
-- Order the results by date established, oldest first.
-- (6 rows)
SELECT park_name, date_established
FROM park
WHERE date_established BETWEEN '1960-01-01' AND '1969-12-31'
ORDER BY date_established ASC;
