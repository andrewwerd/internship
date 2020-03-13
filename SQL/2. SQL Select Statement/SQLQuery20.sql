/****** Script for SelectTopNRows command from SSMS  ******/

  select [Id]
      ,[ProductName]
      ,[SupplierId]
      ,[UnitPrice]
      ,[Package]
      ,[IsDiscontinued]
FROM [Test].[dbo].[Product]
where Package like '%box%' 