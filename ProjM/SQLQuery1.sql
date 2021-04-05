select * from SaveItem_2021

CREATE TABLE [SaveItem_2021] (
        [id] smallint IDENTITY (1, 1) NOT NULL ,
        [storyNum] INT NOT NULL ,
        [title] nvarchar (50) ,        
        [description] nvarchar (1000) ,
        
   
	Primary key (storyNum)
)
drop TABLE SaveItem_2021