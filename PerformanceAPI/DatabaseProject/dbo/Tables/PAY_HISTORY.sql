﻿-----------------------------
--"PAY_HISTORY"
-----------------------------
CREATE TABLE "PAY_HISTORY" (
	"EMPLOYEE_ID" NUMERIC(6) NOT NULL,
	"PAY_START_DATE" DATE NOT NULL,
	"SALARY_FLAG" BIT NOT NULL,
	"PAY_AMOUNT" NUMERIC(10,2) NOT NULL,
	PRIMARY KEY("EMPLOYEE_ID", "PAY_START_DATE")
	)