CREATE DATABASE SimbirSoftDB
USE SimbirSoftDB

CREATE TABLE author(
    id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    first_name NVARCHAR(50) NOT NULL,
    last_name NVARCHAR(50) NOT NULL,
    middle_name NVARCHAR(50)
)

CREATE TABLE person(
    id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    birth_date DATETIME,
    first_name NVARCHAR(50) NOT NULL,
    last_name NVARCHAR(50) NOT NULL,
    middle_name NVARCHAR(50)
)

CREATE TABLE genre(
   id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
   genre_name NVARCHAR(200) NOT NULL
)

CREATE TABLE book(
    id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    name NVARCHAR(500) NOT NULL,
    author_id INT NOT NULL,
    CONSTRAINT [FK_book_author] FOREIGN KEY (author_id) REFERENCES author(id)
)

CREATE TABLE book_genre(
    book_id INT NOT NULL,
    genre_id INT NOT NULL,
    CONSTRAINT [PK_book_id_genre_id] PRIMARY KEY (book_id, genre_id),
    CONSTRAINT [FK_book_genre_book] FOREIGN KEY (book_id) REFERENCES book(id),
    CONSTRAINT [FK_book_genre_genre] FOREIGN KEY (genre_id) REFERENCES genre(id)
)

CREATE TABLE library_card(
    book_id INT NOT NULL,
    person_id INT NOT NULL,
    CONSTRAINT [PK_book_id_person_id] PRIMARY KEY (book_id, person_id),
    CONSTRAINT [FK_library_card_book] FOREIGN KEY (book_id) REFERENCES book(id),
    CONSTRAINT [FK_library_card_person] FOREIGN KEY (person_id) REFERENCES person(id)
)