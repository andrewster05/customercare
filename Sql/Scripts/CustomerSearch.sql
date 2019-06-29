CREATE PROCEDURE [dbo].[CustomersSearch]
	@SearchTerm VARCHAR(50),
	@SortColumn VARCHAR(50),
	@SortOrder VARCHAR(50),
	@PageNumber INT,
	@PageSize INT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @StartRow INT
	DECLARE @EndRow INT

	SET @SortColumn = LOWER(ISNULL(@SortColumn, ''))
	SET @SortOrder = LOWER(ISNULL(@SortOrder, ''))
	SET @StartRow = (@PageNumber - 1) * @PageSize
    SET @EndRow = (@PageNumber * @PageSize)+1

	;WITH CTEResult AS (
		SELECT ROW_NUMBER() OVER (ORDER BY
			CASE WHEN (@SortColumn = 'Firstname' AND @SortOrder='asc') THEN Firstname END ASC,
			CASE WHEN (@SortColumn = 'Firstname' AND @SortOrder='desc') THEN Firstname END DESC,

			CASE WHEN (@SortColumn = 'Lastname' AND @SortOrder='asc') THEN Lastname END ASC,
			CASE WHEN (@SortColumn = 'Lastname' AND @SortOrder='desc') THEN Lastname END DESC,

			CASE WHEN (@SortColumn = 'Email' AND @SortOrder='asc') THEN Email END ASC,
			CASE WHEN (@SortColumn = 'Email' AND @SortOrder='desc') THEN Email END DESC
		 ) AS RowNumber
		, COUNT(*) OVER () AS TotalCount
		,[Id]
		,[Firstname]
		,[Lastname]
		,[Email]
		,[DateOfBirth]
		,[ZipCode]
		,[Country]
		,[CreatedDate]
		,[SystemRole]
		FROM [dbo].[Customers]
		 WHERE (
				 (ISNULL(@SearchTerm, '') = '' OR Firstname LIKE '%' + @SearchTerm + '%')
				OR (ISNULL(@SearchTerm, '') = '' OR Lastname LIKE '%' + @SearchTerm + '%')
				OR (ISNULL(@SearchTerm, '') = '' OR Email LIKE '%' + @SearchTerm + '%')
			)
	)

	SELECT 
	[RowNumber]
	,[TotalCount] 
	,[Id]
		,[Firstname]
		,[Lastname]
		,[Email]
		,[DateOfBirth]
		,[ZipCode]
		,[Country]
		,[CreatedDate]
		,[SystemRole]
	FROM CTEResult
	WHERE RowNumber > @StartRow AND RowNumber < @EndRow
	ORDER BY RowNumber

END