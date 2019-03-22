USE [narilearsi]
GO

/****** Object:  Table [dbo].[Persons]    Script Date: 19/03/2019 09:07:07 p. m. ******/
DROP TABLE [dbo].[Persons]
GO

/****** Object:  Table [dbo].[Persons]    Script Date: 19/03/2019 09:07:07 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Persons](
	[PersonID] [int] NOT NULL,
	[type] [int] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[LastName] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Address1] [varchar](255) NOT NULL,
	[Adress2] [varchar](255),
PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
    [EventID] [int] NOT NULL,
    [eventType] [int] NOT NULL,
    [eventName] [varchar](50) NOT NULL,
    [eventDescription] [varchar](50) NULL,
    [eventDate] [datetime] NULL,
    [eventStatus] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
    [EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_EventType] FOREIGN KEY([eventType])
REFERENCES [dbo].[EventType] ([EventTypeID])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_EventType]
GO




SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventType](
    [EventTypeID] [int] NOT NULL,
    [etName] [varchar](50) NOT NULL,
    [etDescription] [nchar](50) NOT NULL,
 CONSTRAINT [PK_EventType] PRIMARY KEY CLUSTERED 
(
    [EventTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
