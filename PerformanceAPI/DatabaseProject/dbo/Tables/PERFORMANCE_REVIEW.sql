﻿-----------------------------
--"PERFORMANCE_REVIEW"
-----------------------------
CREATE TABLE "PERFORMANCE_REVIEW" (
	"REPORT_ID" NUMERIC(20) PRIMARY KEY,
	"EMPLOYEE_ID" NUMERIC(6) NOT NULL,
	"DATE_OF_REVIEW" DATE NOT NULL,
	"PR_SUPERVISOR" VARCHAR(30) NOT NULL,
	"PR_REVIEW_PERIOD" VARCHAR(40) NOT NULL,
	"P_RATING_ID" VARCHAR(3) NOT NULL,
	"PR_LAST_RATING" VARCHAR(3) NOT NULL,
	"PR_POSITION" VARCHAR(20) NOT NULL,
	"PR_DEPARTMENT" VARCHAR(20) NOT NULL,
	"PR_DATE_OF_NEXT_REVIEW" DATE NOT NULL
	)