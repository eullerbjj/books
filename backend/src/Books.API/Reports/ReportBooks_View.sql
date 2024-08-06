CREATE VIEW ReportBooks AS
SELECT 
	b.Id, b.Title, b.PublicationYear, b.Edition, b.Publisher, a.Name, s.Description as Subject, st.Description as SaleType, p.Value
FROM Book b
	JOIN BookAuthor ba ON b.Id = ba.BookId
	JOIN Author a ON ba.AuthorId = a.Id
	JOIN BookSubject bs ON b.Id = bs.BookId
	JOIN Subject s ON bs.SubjectId= s.Id
	JOIN Price p ON b.Id = p.BookId
	JOIN SaleType st ON p.SaleTypeId = st.Id
