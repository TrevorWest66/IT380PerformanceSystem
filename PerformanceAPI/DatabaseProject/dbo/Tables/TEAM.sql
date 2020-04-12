-----------------------------
--"TEAM"
-----------------------------
CREATE TABLE "TEAM" (
	"TEAM_ID" NUMERIC(6) PRIMARY KEY,
	"TEAM_NAME" VARCHAR(20) NOT NULL,
	"SUPERVISOR_ID" NUMERIC(6) NOT NULL,
	"DEPT_ID" NUMERIC(6) NOT NULL
	)