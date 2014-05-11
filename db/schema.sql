create table [dbo].[Builds] (
    [Id] [int] not null identity,
    [Name] [nvarchar](50) null,
    [ChangeSet] [nvarchar](250) null,
    [Release] [nvarchar](250) null,
    [ProjectId] [int] not null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [DeletedBy] [nvarchar](250) null,
    [RowVersion] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[EmailAccounts] (
    [Id] [int] not null identity,
    [Name] [nvarchar](50) null,
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
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [DeletedBy] [nvarchar](250) null,
    [RowVersion] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[Files] (
    [Id] [int] not null identity,
    [Name] [nvarchar](50) null,
    [Extension] [nvarchar](250) null,
    [RelativePath] [nvarchar](250) null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [DeletedBy] [nvarchar](250) null,
    [RowVersion] [rowversion] not null,
    [Package_Id] [int] null,
    [Build_Id] [int] null,
    primary key ([Id])
);
create table [dbo].[Groups] (
    [Id] [int] not null identity,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [DeletedBy] [nvarchar](250) null,
    [RowVersion] [rowversion] not null,
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
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [DeletedBy] [nvarchar](250) null,
    [RowVersion] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[Packages] (
    [Id] [int] not null identity,
    [Name] [nvarchar](50) null,
    [Path] [nvarchar](250) null,
    [Size] [real] not null,
    [Description] [nvarchar](2000) null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [DeletedBy] [nvarchar](250) null,
    [RowVersion] [rowversion] not null,
    [Build_Id] [int] null,
    primary key ([Id])
);
create table [dbo].[Parameters] (
    [Id] [int] not null identity,
    [Number] [int] not null,
    [Name] [nvarchar](50) null,
    [Description] [nvarchar](2000) null,
    [Value] [nvarchar](250) null,
    [ValieValue] [nvarchar](250) null,
    [ResourceId] [int] not null,
    [IsVisible] [bit] not null,
    [GroupId] [int] not null,
    [DisplayOrder] [int] not null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [DeletedBy] [nvarchar](250) null,
    [RowVersion] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[Projects] (
    [Id] [int] not null identity,
    [Name] [nvarchar](50) null,
    [Code] [nvarchar](10) null,
    [Description] [nvarchar](2000) null,
    [HasRange] [bit] not null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [DeletedBy] [nvarchar](250) null,
    [RowVersion] [rowversion] not null,
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
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [DeletedBy] [nvarchar](250) null,
    [RowVersion] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[Ranges] (
    [Id] [int] not null identity,
    [Name] [nvarchar](50) null,
    [Description] [nvarchar](2000) null,
    [Min] [int] not null,
    [Max] [int] not null,
    [Next] [int] not null,
    [IsExhausted] [bit] not null,
    [ProjectId] [int] not null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [DeletedBy] [nvarchar](250) null,
    [RowVersion] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[Resources] (
    [Id] [int] not null identity,
    [Key] [int] not null,
    [Text] [nvarchar](250) null,
    [DisplayText] [nvarchar](250) null,
    [Description] [nvarchar](2000) null,
    [ProjectId] [int] not null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [DeletedBy] [nvarchar](250) null,
    [RowVersion] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[ScheduleTasks] (
    [Id] [int] not null identity,
    [Name] [nvarchar](50) null,
    [Seconds] [int] not null,
    [TaskTypeId] [bigint] not null,
    [Enabled] [bit] not null,
    [StopOnError] [bit] not null,
    [LastStartUtc] [datetime] null,
    [LastEndUtc] [datetime] null,
    [LastSuccessUtc] [datetime] null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [DeletedBy] [nvarchar](250) null,
    [RowVersion] [rowversion] not null,
    [TaskType_Id] [int] null,
    primary key ([Id])
);
create table [dbo].[Settings] (
    [Id] [int] not null identity,
    [Name] [nvarchar](50) null,
    [Value] [nvarchar](250) null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [DeletedBy] [nvarchar](250) null,
    [RowVersion] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[Tabs] (
    [Id] [int] not null identity,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [DeletedBy] [nvarchar](250) null,
    [RowVersion] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[TaskTypes] (
    [Id] [int] not null identity,
    [Name] [nvarchar](50) null,
    [AssemblyQualifiedName] [nvarchar](250) null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [DeletedBy] [nvarchar](250) null,
    [RowVersion] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[Terms] (
    [Id] [int] not null identity,
    [Key] [int] not null,
    [Text] [nvarchar](250) null,
    [Description] [nvarchar](2000) null,
    [ProjectId] [int] not null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [DeletedBy] [nvarchar](250) null,
    [RowVersion] [rowversion] not null,
    primary key ([Id])
);
create table [dbo].[Users] (
    [Id] [int] not null identity,
    [Domain] [nvarchar](250) null,
    [UserName] [nvarchar](250) null,
    [FirstName] [nvarchar](50) null,
    [LastName] [nvarchar](50) null,
    [IsAdmin] [bit] not null,
    [IsLoggedIn] [bit] not null,
    [LastLoginDate] [datetime] null,
    [ProjectId] [int] not null,
    [IsDeleted] [bit] not null,
    [DeletedOn] [datetime] null,
    [DeletedBy] [nvarchar](250) null,
    [RowVersion] [rowversion] not null,
    primary key ([Id])
);
alter table [dbo].[Packages] add constraint [Build_Packages] foreign key ([Build_Id]) references [dbo].[Builds]([Id]);
alter table [dbo].[Builds] add constraint [Build_Project] foreign key ([ProjectId]) references [dbo].[Projects]([Id]) on delete cascade;
alter table [dbo].[Files] add constraint [Build_Scripts] foreign key ([Build_Id]) references [dbo].[Builds]([Id]);
alter table [dbo].[Files] add constraint [Package_Files] foreign key ([Package_Id]) references [dbo].[Packages]([Id]);
alter table [dbo].[Parameters] add constraint [Parameter_Group] foreign key ([GroupId]) references [dbo].[Groups]([Id]) on delete cascade;
alter table [dbo].[Parameters] add constraint [Parameter_Resource] foreign key ([ResourceId]) references [dbo].[Resources]([Id]) on delete cascade;
alter table [dbo].[Ranges] add constraint [Range_Project] foreign key ([ProjectId]) references [dbo].[Projects]([Id]) on delete cascade;
alter table [dbo].[Resources] add constraint [Resource_Project] foreign key ([ProjectId]) references [dbo].[Projects]([Id]) on delete cascade;
alter table [dbo].[ScheduleTasks] add constraint [ScheduleTask_TaskType] foreign key ([TaskType_Id]) references [dbo].[TaskTypes]([Id]);
alter table [dbo].[Terms] add constraint [Term_Project] foreign key ([ProjectId]) references [dbo].[Projects]([Id]) on delete cascade;
