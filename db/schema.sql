create table [dbo].[EmailAccounts] (
    [Id] [int] not null identity,
    [Name] [nvarchar](250) null,
    [Email] [nvarchar](250) null,
    [DisplayName] [nvarchar](250) null,
    [SmtpHost] [nvarchar](250) null,
    [SmtpPort] [int] not null,
    [PopHost] [nvarchar](250) null,
    [PopPort] [int] not null,
    [UserName] [nvarchar](250) null,
    [Password] [nvarchar](250) null,
    [SmtpSslEnabled] [bit] not null,
    [Pop3SslEnabled] [bit] not null,
    [UseDefaultCredentials] [bit] not null,
    [IsActive] [bit] not null,
    [ActivatedOn] [datetime] null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [Version] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[Groups] (
    [Id] [int] not null identity,
    [IsActive] [bit] not null,
    [ActivatedOn] [datetime] null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [Version] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[Logs] (
    [Id] [int] not null identity,
    [LogLevelId] [int] not null,
    [ShortMessage] [nvarchar](250) null,
    [FullMessage] [nvarchar](250) null,
    [IpAddress] [nvarchar](250) null,
    [CustomerId] [int] null,
    [PageUrl] [nvarchar](250) null,
    [ReferrerUrl] [nvarchar](250) null,
    [CreatedOnUtc] [datetime] not null,
    [LogLevel] [int] not null,
    [User] [nvarchar](250) null,
    [UserId] [int] null,
    [IsActive] [bit] not null,
    [ActivatedOn] [datetime] null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [Version] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[Parameters] (
    [Id] [int] not null identity,
    [Number] [int] not null,
    [Name] [nvarchar](250) null,
    [Description] [nvarchar](250) null,
    [Value] [nvarchar](250) null,
    [ValieValue] [nvarchar](250) null,
    [ResourceId] [int] not null,
    [IsVisible] [bit] not null,
    [GroupId] [int] not null,
    [DisplayOrder] [int] not null,
    [IsActive] [bit] not null,
    [ActivatedOn] [datetime] null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [Version] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[Projects] (
    [Id] [int] not null identity,
    [Name] [nvarchar](250) null,
    [Code] [nvarchar](250) null,
    [Description] [nvarchar](250) null,
    [IsActive] [bit] not null,
    [ActivatedOn] [datetime] null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [Version] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[QueuedEmails] (
    [Id] [int] not null identity,
    [From] [nvarchar](250) null,
    [FromName] [nvarchar](250) null,
    [To] [nvarchar](250) null,
    [ToName] [nvarchar](250) null,
    [Cc] [nvarchar](250) null,
    [CcName] [nvarchar](250) null,
    [Bcc] [nvarchar](250) null,
    [BccName] [nvarchar](250) null,
    [Subject] [nvarchar](250) null,
    [Body] [nvarchar](250) null,
    [Priority] [int] not null,
    [SentTries] [int] not null,
    [SentOn] [datetime] null,
    [IsActive] [bit] not null,
    [ActivatedOn] [datetime] null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [Version] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[Ranges] (
    [Id] [int] not null identity,
    [Name] [nvarchar](250) null,
    [Description] [nvarchar](250) null,
    [Min] [int] not null,
    [Max] [int] not null,
    [Next] [int] not null,
    [IsExhausted] [bit] not null,
    [ProjectId] [int] not null,
    [IsActive] [bit] not null,
    [ActivatedOn] [datetime] null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [Version] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[Resources] (
    [Id] [int] not null identity,
    [Text] [nvarchar](250) null,
    [Description] [nvarchar](250) null,
    [IsActive] [bit] not null,
    [ActivatedOn] [datetime] null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [Version] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[ScheduleTasks] (
    [Id] [int] not null identity,
    [Name] [nvarchar](250) null,
    [Seconds] [int] not null,
    [TaskTypeId] [bigint] not null,
    [Enabled] [bit] not null,
    [StopOnError] [bit] not null,
    [LastStartUtc] [datetime] null,
    [LastEndUtc] [datetime] null,
    [LastSuccessUtc] [datetime] null,
    [IsActive] [bit] not null,
    [ActivatedOn] [datetime] null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [Version] [rowversion] not null,
    [TaskType_Id] [int] null,
    primary key ([Id])
);
create table [dbo].[Settings] (
    [Id] [int] not null identity,
    [Name] [nvarchar](250) null,
    [Value] [nvarchar](250) null,
    [IsActive] [bit] not null,
    [ActivatedOn] [datetime] null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [Version] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[Tabs] (
    [Id] [int] not null identity,
    [IsActive] [bit] not null,
    [ActivatedOn] [datetime] null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [Version] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[TaskTypes] (
    [Id] [int] not null identity,
    [Name] [nvarchar](250) null,
    [AssemblyQualifiedName] [nvarchar](250) null,
    [IsActive] [bit] not null,
    [ActivatedOn] [datetime] null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [Version] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[Terms] (
    [Id] [int] not null identity,
    [IsActive] [bit] not null,
    [ActivatedOn] [datetime] null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [Version] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[Users] (
    [Id] [int] not null identity,
    [UserName] [nvarchar](250) null,
    [Password] [nvarchar](250) null,
    [FirstName] [nvarchar](250) null,
    [LastName] [nvarchar](250) null,
    [AccessKey] [nvarchar](250) null,
    [PublicKey] [nvarchar](250) null,
    [PrivateKey] [nvarchar](250) null,
    [IsLoggedIn] [bit] not null,
    [LastLoginDate] [datetime] null,
    [IsLockedOut] [bit] not null,
    [LastLockedDate] [datetime] null,
    [InvalidLoginAttemptCount] [int] not null,
    [IsActive] [bit] not null,
    [ActivatedOn] [datetime] null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [Version] [rowversion] not null,
    primary key ([Id])
);
alter table [dbo].[Parameters] add constraint [Parameter_Group] foreign key ([GroupId]) references [dbo].[Groups]([Id]) on delete cascade;
alter table [dbo].[Parameters] add constraint [Parameter_Resource] foreign key ([ResourceId]) references [dbo].[Resources]([Id]) on delete cascade;
alter table [dbo].[Ranges] add constraint [Range_Project] foreign key ([ProjectId]) references [dbo].[Projects]([Id]) on delete cascade;
alter table [dbo].[ScheduleTasks] add constraint [ScheduleTask_TaskType] foreign key ([TaskType_Id]) references [dbo].[TaskTypes]([Id]);
