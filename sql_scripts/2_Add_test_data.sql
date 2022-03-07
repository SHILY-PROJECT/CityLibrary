USE CityLibraryDb

SET IDENTITY_INSERT author ON
INSERT author ([id], [first_name], [last_name])
VALUES  (1, 'Eliezer', 'Yudkowsky'),
        (2, 'Carl', 'Sagan'),
        (3, 'Norman', 'Doidge'),
        (4, 'Stephen', 'King'),
        (5, 'John', 'Tolkien')
SET IDENTITY_INSERT author OFF

SET IDENTITY_INSERT genre ON
INSERT genre ([id], [genre_name])
VALUES  (1, 'Fantasy'),
        (2, 'Scientific literature'),
        (3, 'Self-development literature'),
        (4, 'Science fiction')
SET IDENTITY_INSERT genre OFF 

SET IDENTITY_INSERT book ON
INSERT book ([id], [name], [author_id])
VALUES  (1, 'Harry Potter and the Methods of Rationality', 1),
        (2, 'The Demon-Haunted World: Science as a Candle in the Dark', 2),
        (3, 'The Brains Way of Healing: Remarkable Discoveries and Recoveries from the Frontiers of Neuroplasticity', 3),
        (4, 'Contact', 2),
        (5, 'The Lord of the Rings', 5),
        (6, 'The Hobbit, or There and Back Again', 5)
SET IDENTITY_INSERT book OFF 

SET IDENTITY_INSERT person ON
INSERT person ([id], [birth_date], [first_name], [last_name], [middle_name])
VALUES  (1, '1983-03-12', 'Alexander', 'Statskov', 'Dmitrievich'),
        (2, '1978-11-27', 'Igor', 'Izmailov', 'Innokentievich'),
        (3, '1979-09-11', 'Eliezer', 'Yudkowsky', 'Shlomo'),
        (4, '1992-05-06', 'Yana', 'Sharkelova', 'Egorovna'),
        (5, '1978-11-27', 'Igor', 'Premin', 'Olegovych')
SET IDENTITY_INSERT person OFF

INSERT library_card ([book_id], [person_id])
VALUES  (2, 1),
        (3, 1),
        (4, 1),
        (1, 2),
        (4, 2)

INSERT book_genre ([book_id], [genre_id])
VALUES  (1, 1),
        (2, 2),
        (3, 3),
        (4, 4),
        (5, 1),
        (6, 1)
