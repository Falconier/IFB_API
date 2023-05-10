  INSERT INTO  [IFB].[dbo].[Items]
  (ItemId, Description, Unit_Price, UPC, SKU, On_Hand)
  VALUES
  (1, 'test one', 1.99, 222333, 222333, 100),
  (2, 'test two', 5.50, 444555, 444555, 100)

  INSERT INTO [IFB].[dbo].[Orders]
  (OrderId, CustomerId, Total_Cost)
  VALUES
  (1,1, 0.00),
  (2,1, 0.00),
  (3,2, 0.00)

  INSERT INTO [IFB].[dbo].[OrderItems]
  (Id, ItemId, OrderId, Quantity)
  VALUES
  (1,1,1,4),
  (2,1,2,3), 
  (3,2,1,2)

 