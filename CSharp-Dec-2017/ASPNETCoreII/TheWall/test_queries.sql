SELECT * FROM users;
SELECT * FROM messages;
SELECT messages.id, messages.content, messages.created_at, users.first_name, users.last_name FROM messages
	JOIN users ON users.id = messages.user_id;
SELECT * FROM comments;
SELECT message_id, comments.content, comments.created_at FROM comments
	JOIN messages ON messages.id = comments.message_id
	JOIN users ON users.id = comments.user_id;

SELECT id, pw_hash FROM users WHERE email = 'rommel@python.com';

INSERT INTO users (first_name, last_name, email, pw_hash, created_at, updated_at)
	VALUES ('qwer', 'qwer', 'qwer@email.com', '$2b$12$DA9DkAwPbPnRO9Fwt39/UuHGLI/zmsxTisihnOcOpoB82.4D5JJ/m', NOW(), NOW());
SELECT LAST_INSERT_ID() as id;

DELETE FROM comments WHERE comments.user_id = 31;
DELETE FROM messages WHERE messages.user_id = 31;
DELETE FROM users WHERE id = 31;
SELECT * FROM users;

