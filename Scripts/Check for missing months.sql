SELECT DISTINCT CONCAT(YEAR([Date]), '-', (CASE WHEN MONTH([Date]) < 10 THEN '0' END), MONTH([Date])) as yearmonth 
FROM [Transactions]
WHERE [Date] >= '2020-01-01' 
ORDER BY yearmonth DESC