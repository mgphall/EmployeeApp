CREATE TABLE "EmployeeProfile" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_EmployeeProfile" PRIMARY KEY AUTOINCREMENT,
    "FirstName" TEXT NULL,
    "LastName" TEXT NULL,
    "Salary" TEXT NOT NULL,
    "HoursPerDay" INTEGER NOT NULL,
    "DaysPerWeek" INTEGER NOT NULL,
    "WeeksPerYear" INTEGER NOT NULL
)