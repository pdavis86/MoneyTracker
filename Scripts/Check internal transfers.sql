SELECT A.[Date], A.AccountId, A.TransactionId, A.[Description], A.[Value]
, CASE WHEN COALESCE(B.[Date],C.[Date],D.[Date],E.[Date]) IS NOT NULL THEN 1 ELSE 0 END HasMatch
, CASE WHEN DATEPART(m, A.[Date]) = DATEPART(m,COALESCE(B.[Date],C.[Date],D.[Date],E.[Date])) THEN 1 ELSE 0 END SameMonth
, B.[Date], B.AccountId, B.TransactionId, B.[Description], B.[Value]
, C.[Date], C.AccountId, C.TransactionId, C.[Description], C.[Value]
, D.[Date], D.AccountId, D.TransactionId, D.[Description], D.[Value]
, E.[Date], E.AccountId, E.TransactionId, E.[Description], E.[Value]
FROM Transactions A
LEFT JOIN Transactions B ON B.[Date] = A.[Date] AND B.CategoryId = 12 AND B.[Value] = A.[Value] * -1
LEFT JOIN Transactions C ON C.[Date] = DATEADD(d, 1, A.[Date]) AND C.CategoryId = 12 AND C.[Value] = A.[Value] * -1
LEFT JOIN Transactions D ON D.[Date] = DATEADD(d, -1, A.[Date]) AND D.CategoryId = 12 AND D.[Value] = A.[Value] * -1
LEFT JOIN Transactions E ON E.[Date] = DATEADD(d, -2, A.[Date]) AND E.CategoryId = 12 AND E.[Value] = A.[Value] * -1
WHERE A.CategoryId = 12
AND A.[Value] < 0
AND A.[Date] > '2024-12-31'
ORDER BY A.[Date] DESC

--select * from Transactions where Value = 13.43
--select * from Transactions where CategoryId = 12 and Date between '2025-08-01' and '2025-08-31'

--update Transactions set CategoryId = 1 where TransactionId in (15380,15392)

--update Transactions set CategoryId = 1 where CategoryId = 12 and Description like 'LARABEE C M%'