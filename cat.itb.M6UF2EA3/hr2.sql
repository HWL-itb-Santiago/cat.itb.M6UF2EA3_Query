CREATE TABLE departamentos (
 id SERIAL NOT NULL PRIMARY KEY,
 dnombre  VARCHAR(15), 
 loc      VARCHAR(15)
);

INSERT INTO departamentos (dnombre, loc) VALUES ('CONTABILIDAD','SEVILLA');
INSERT INTO departamentos (dnombre, loc) VALUES ('INVESTIGACIÓN','MADRID');
INSERT INTO departamentos (dnombre, loc) VALUES ('VENTAS','BARCELONA');
INSERT INTO departamentos (dnombre, loc) VALUES ('PRODUCCIÓN','BILBAO');
COMMIT;

CREATE TABLE empleados (
 id SERIAL NOT NULL PRIMARY KEY,
 empno    INTEGER  NOT NULL,
 apellido  VARCHAR(10),
 oficio    VARCHAR(10),
 dir       INTEGER,
 fechaalt  TIMESTAMPTZ,
 salario   DECIMAL(6,2),
 comision  DECIMAL(6,2),
 deptno   INTEGER NOT NULL,
 CONSTRAINT FK_DEP FOREIGN KEY (deptno ) REFERENCES departamentos(id)

);

INSERT INTO empleados (empno, apellido,oficio,dir,fechaalt,salario,comision,deptno) VALUES (7369,'SÁNCHEZ','EMPLEADO',7902,'2017-01-01 00:00:00',
                        1040,NULL,2);				
INSERT INTO empleados (empno, apellido,oficio,dir,fechaalt,salario,comision,deptno) VALUES (7499,'ARROYO','VENDEDOR',7698,'2017-01-01 00:00:00',
                        1500,390,3);
INSERT INTO empleados (empno, apellido,oficio,dir,fechaalt,salario,comision,deptno) VALUES (7521,'SALA','VENDEDOR',7698,'2017-01-01 00:00:00',
                        1625,650,3);
INSERT INTO empleados (empno, apellido,oficio,dir,fechaalt,salario,comision,deptno) VALUES (7566,'JIMÉNEZ','DIRECTOR',7839,'2017-01-01 00:00:00',
                        2900,NULL,2);
INSERT INTO empleados (empno, apellido,oficio,dir,fechaalt,salario,comision,deptno) VALUES (7654,'MARTÍN','VENDEDOR',7698,'2017-01-01 00:00:00',
                        1600,1020,3);
INSERT INTO empleados (empno, apellido,oficio,dir,fechaalt,salario,comision,deptno) VALUES (7698,'NEGRO','DIRECTOR',7839,'2017-01-01 00:00:00',
                        3005,NULL,3);
INSERT INTO empleados (empno, apellido,oficio,dir,fechaalt,salario,comision,deptno) VALUES (7782,'CEREZO','DIRECTOR',7839,'2017-01-01 00:00:00',
                        2885,NULL,1);
INSERT INTO empleados (empno, apellido,oficio,dir,fechaalt,salario,comision,deptno) VALUES (7788,'GIL','ANALISTA',7566,'2017-01-01 00:00:00',
                        3000,NULL,2);
INSERT INTO empleados (empno, apellido,oficio,dir,fechaalt,salario,comision,deptno) VALUES (7839,'REY','PRESIDENTE',NULL,'2017-01-01 00:00:00',
                        4100,NULL,1);
INSERT INTO empleados (empno, apellido,oficio,dir,fechaalt,salario,comision,deptno) VALUES (7844,'TOVAR','VENDEDOR',7698,'2017-01-01 00:00:00',
                        1350,0,3);
INSERT INTO empleados (empno, apellido,oficio,dir,fechaalt,salario,comision,deptno) VALUES (7876,'ALONSO','EMPLEADO',7788,'2017-01-01 00:00:00',
                        1430,NULL,2);
INSERT INTO empleados (empno, apellido,oficio,dir,fechaalt,salario,comision,deptno) VALUES (7900,'JIMENO','EMPLEADO',7698,'2017-01-01 00:00:00',
                        1335,NULL,3);
INSERT INTO empleados (empno, apellido,oficio,dir,fechaalt,salario,comision,deptno) VALUES (7902,'FERNÁNDEZ','ANALISTA',7566,'2017-01-01 00:00:00',
                        3000,NULL,2);
INSERT INTO empleados (empno, apellido,oficio,dir,fechaalt,salario,comision,deptno) VALUES (7934,'MUÑOZ','EMPLEADO',7782,'2017-01-01 00:00:00',
                        1690,NULL,1);
COMMIT;
