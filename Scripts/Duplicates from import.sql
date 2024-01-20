DELETE FROM [Transactions] WHERE [TransactionId] IN (
	SELECT IIF(t1.[TransactionId] > t2.[TransactionId], t1.[TransactionId], t2.[TransactionId]) 
	FROM [Transactions] t1
	JOIN [Transactions] t2 
		ON t1.[Date] = t2.[Date] 
		AND t1.[Description] = t2.[Description] 
		AND t1.[Value] = t2.[Value]
		AND t1.[Balance] = t2.[Balance] 
		AND t1.[TransactionId] <> t2.[TransactionId]
)