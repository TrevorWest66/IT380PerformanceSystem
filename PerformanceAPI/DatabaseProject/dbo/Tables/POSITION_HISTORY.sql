﻿-----------------------------
--"POSITION_HISTORY"
-----------------------------
CREATE TABLE "POSITION_HISTORY" (
	"EMPLOYEE_ID" NUMERIC(6) NOT NULL,
	"POSITION_START_DATE" DATE NOT NULL,
	"POSITION_ID" NUMERIC(6) NOT NULL,
	PRIMARY KEY ("EMPLOYEE_ID", "POSITION_START_DATE")
	)