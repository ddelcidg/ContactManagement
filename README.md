1.Open the ContactManagement.sln solution
2.Create ContactManagement and ContactsDb database
3.Configure the solution so that the project starts with both projects
4.AuthenticationService validates users in the system
5.Execute the script
USE [ContactManagement]
GO
INSERT [dbo].[Users] ([Id], [Username], [PasswordHash], [Email]) VALUES (N'8a234a0f-e51a-4a1a-a230-69ca113931fa', N'test2', N'O3+kibh3E+/d87KHKionQrkVnE9t/eJ/ZeQQdliKiWxg/l28FwJK3sngnukQYdxR', N'test2@example.com')
INSERT [dbo].[Users] ([Id], [Username], [PasswordHash], [Email]) VALUES (N'477a1e81-9fdd-4c86-97ee-dce8f10e38a7', N'test1', N'qQFOwDBnX+DHddrytDm0Nu4XLEkhsk6aCzfIwZtpr4gbY39PqCrEUgUtA0PyV0El', N'test1@example.com')
GO

6. Go to swagger in ContactsService API
  Try creating, getting, updating or deleting new contacts
