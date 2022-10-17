INSERT INTO [dbo].[empl_registration] ([Name], [PhoneNumber], [empUserId], [empPassword]) VALUES (N'A K Gokulraj', N'8792894523', N'gok123', N'gokulraj')
INSERT INTO [dbo].[tbl_custreg] ([Name], [PhoneNum], [AccountNum], [DOB], [PanNum], [Gender], [SelectAcc], [MPIN], [UserId], [Password], [Balance]) VALUES (N'riya', N'87925689452', N'4562', N'27-02-1997', N'nfvjshija5', N'female', N'Saving Account', N'4562', N'riya123', N'riya45', NULL)
INSERT INTO [dbo].[tbl_loan] ([AccountNum], [LoanAmount]) VALUES (N'4562', 1000)
SET IDENTITY_INSERT [dbo].[tbl_transaction] ON
INSERT INTO [dbo].[tbl_transaction] ([TransactionNum], [AccountNum], [TranDate], [Amount], [TranType], [Transfer_to]) VALUES (102030400, N'4562', N'2022-09-14 17:47:37', 1000, 1, N'0')
INSERT INTO [dbo].[tbl_transaction] ([TransactionNum], [AccountNum], [TranDate], [Amount], [TranType], [Transfer_to]) VALUES (102030401, N'4562', N'2022-09-14 17:48:05', 25000, 1, N'0')
INSERT INTO [dbo].[tbl_transaction] ([TransactionNum], [AccountNum], [TranDate], [Amount], [TranType], [Transfer_to]) VALUES (102030402, N'4562', N'2022-09-14 17:48:09', 25000, 2, N'0')
INSERT INTO [dbo].[tbl_transaction] ([TransactionNum], [AccountNum], [TranDate], [Amount], [TranType], [Transfer_to]) VALUES (102030403, N'4562', N'2022-09-14 17:48:12', 25000, 2, N'0')
SET IDENTITY_INSERT [dbo].[tbl_transaction] OFF
