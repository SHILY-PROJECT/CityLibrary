USE SimbirSoftDB

--[3.1 Получение списока всех взятых пользователем книг]----------
DECLARE @USER_ID_FOR_SEARCH INT = 2; -- ID пользователя          |
------------------------------------------------------------------
SELECT CONCAT(b.name, ', ', a.first_name, ' ', a.last_name, ', ', g.genre_name) as 'Название книги - Автор - Жанр' FROM library_card lc
INNER JOIN book b ON  b.id = lc.book_id
INNER JOIN author a ON a.id = b.author_id
INNER JOIN book_genre bg ON bg.book_id = b.id
INNER JOIN genre g ON g.id = bg.genre_id
WHERE lc.person_id = @USER_ID_FOR_SEARCH

--[3.2 Получение списока книг автора]-----------------------------
DECLARE @AUTHOR_ID_FOR_SEARCH INT = 2; -- ID автора              |
------------------------------------------------------------------
SELECT CONCAT(a.first_name, ' ', a.last_name, ', ', b.name, ', ', g.genre_name) as 'Автор - Название книги - Жанр' FROM author a
INNER JOIN book b ON b.author_id = a.id
INNER JOIN book_genre bg ON bg.book_id = b.id
INNER JOIN genre g ON g.id = bg.genre_id
WHERE a.id = @AUTHOR_ID_FOR_SEARCH

--[3.3 Получение статистики (жанр - количество книг)]-------------
SELECT g.genre_name as 'Жанр', COUNT(g.genre_name) as 'Кол-во книг в жанре' FROM book b
INNER JOIN book_genre bg ON bg.book_id = b.id
INNER JOIN genre g ON g.id = bg.genre_id
GROUP BY g.genre_name

--[3.4 Получение статистики (автор - количество книг по жанрам)]--
SELECT CONCAT(a.first_name, ' ', a.last_name) as 'Автор', genre_name as 'Жанр', COUNT(g.genre_name) as 'Кол-во книг в жанре у автора' FROM author a
INNER JOIN book b ON b.author_id = a.id
INNER JOIN book_genre bg ON bg.book_id = b.id
INNER JOIN genre g ON  g.id = bg.genre_id
GROUP BY a.first_name, a.last_name, g.genre_name