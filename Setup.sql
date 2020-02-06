USE legos;


-- CREATE TABLE legos (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- );



INSERT INTO legos (name, description) VALUES ("4-Block-B", "4-Block-Black Lego with 4 regular tops");


-- INSERT INTO classroomstudents (studentId, classroomId) VALUES (1, 1);
-- INSERT INTO classroomstudents (studentId, classroomId) VALUES (1, 3);
-- INSERT INTO classroomstudents (studentId, classroomId) VALUES (2, 1);
-- INSERT INTO classroomstudents (studentId, classroomId) VALUES (2, 2);
-- INSERT INTO classroomstudents (studentId, classroomId) VALUES (2, 3);
-- INSERT INTO classroomstudents (studentId, classroomId) VALUES (3, 2);
-- INSERT INTO classroomstudents (studentId, classroomId) VALUES (3, 3);



-- JOIN TABLE QUERY (Classroom Id => students)
-- SELECT * FROM classroomstudents cs
-- INNER JOIN students s ON s.id = cs.studentId
-- WHERE classroomId = 3;


-- JOIN TABLE QUERY (student Id => classes)
-- SELECT * FROM classroomstudents cs
-- JOIN classrooms c ON c.id = cs.classroomId
-- WHERE studentId = 1;
