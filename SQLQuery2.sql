CREATE TABLE empl_registration
(
	[Name] VARCHAR(50) NOT NULL, 
    [PhoneNumber] VARCHAR(50) not null unique, 
    [empUserId] VARCHAR(50) NOT NULL primary key, 
    [empPassword] VARCHAR(50) NOT NULL,

	
	
)

CREATE TABLE tbl_custreg 
(
	[Name] VARCHAR(50) NOT NULL, 
    [PhoneNum] VARCHAR(50) NOT NULL, 
    [AccountNum] VARCHAR(50) NOT NULL unique, 
    [DOB] VARCHAR(50) NOT NULL, 
    [PanNum] VARCHAR(50) NOT NULL, 
    [Gender] VARCHAR(50) NOT NULL, 
    [SelectAcc] VARCHAR(50) NOT NULL, 
    [MPIN] VARCHAR(50) NOT NULL unique, 
    [UserId] VARCHAR(50) NOT NULL primary key, 
    [Password] VARCHAR(50) NOT NULL, 
    [Balance] FLOAT NULL,
)
CREATE TABLE tbl_transaction
(
	[TransactionNum] bigint PRIMARY KEY  identity(102030400,1),
	[AccountNum] VARCHAR(50) NOT NULL,
	foreign key (AccountNum) references tbl_custreg(AccountNum),
    [TranDate] DATETIME NOT NULL, 
	[Transferfrom] varchar(50) NOT NULL,
	[Amount] FLOAT NOT NULL, 
    [TranType] INT NOT NULL, 
	[TranDC] varchar(50) NOT NULL,
	[Transfer_to] VARCHAR(50) NOT NULL
)
CREATE TABLE tbl_loan
(
	[AccountNum] VARCHAR(50) NOT NULL
	foreign key (AccountNum) references tbl_custreg(AccountNum), 
    [LoanAmount] FLOAT NOT NULL
)