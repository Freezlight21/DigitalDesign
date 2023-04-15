--- 1.	Сотрудника с максимальной заработной платой.
SELECT NAME
FROM EMPLOYEE
WHERE (NAME, SALARY) 
IN 
 (SELECT NAME, MAX(SALARY) FROM EMPLOYEE);
 
--- 2.	Отдел, с самой высокой заработной платой между сотрудниками. 
SELECT DEPARTMENT.NAME
FROM DEPARTMENT
JOIN EMPLOYEE 
ON DEPARTMENT.Id == EMPLOYEE.DEPARTMENT_Id
WHERE EMPLOYEE.SALARY  
IN 
 (SELECT MAX(EMPLOYEE.SALARY) FROM EMPLOYEE);

--- 3.	Отдел, с максимальной суммарной зарплатой сотрудников.
WITH dep_salary AS 
	(SELECT DEPARTMENT_Id, sum(SALARY) AS SALARY
    FROM EMPLOYEE 
	GROUP BY DEPARTMENT_Id)
SELECT DEPARTMENT_Id
FROM dep_salary
WHERE dep_salary.salary = (SELECT max(salary) FROM dep_salary);

--- 4.	Сотрудника, чье имя начинается на «Р» и заканчивается на «н».
SELECT NAME
FROM EMPLOYEE
WHERE NAME LIKE 'Р%н';
