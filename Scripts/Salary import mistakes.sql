SELECT *, 
CAST( 
	isnull(basic,0) 
	+ isnull(bonus,0) 
	+ isnull(overtime,0) 
	+ isnull(UnpaidPay,0) 
	+ isnull(WorkingFromHome, 0)
	- isnull(tax,0) 
	- isnull(NationalInsurance,0) 
	- isnull(pension,0) 
	- isnull(studentloan,0) AS NUMERIC(10,2)) - net as difference
FROM [PaySlips]
WHERE CAST( 
	isnull(basic,0) 
	+ isnull(bonus,0) 
	+ isnull(overtime,0) 
	+ isnull(UnpaidPay,0) 
	+ isnull(WorkingFromHome, 0)
	+ isnull(BackPay, 0)
	+ isnull(HolidayPay, 0)
	- isnull(tax,0) 
	- isnull(NationalInsurance,0) 
	- isnull(pension,0) 
	- isnull(studentloan,0) AS NUMERIC(10,2)
) <> isnull(net,0)