# Installation and Usage Guide

### 1. Open the Solution

Open the `ContactManagement.sln` solution.

### 2. Create Databases

Create the `ContactManagement` and `ContactsDb` databases.

### 3. Project Configuration

Configure the solution so that the project starts with both projects.

### 4. Authentication Service

`AuthenticationService` validates users in the system.

### 5. Execute the SQL Script

Execute the following script in the `ContactManagement` database:

```sql
USE [ContactManagement]
GO

INSERT [dbo].[Users] ([Id], [Username], [PasswordHash], [Email]) 
VALUES 
(N'8a234a0f-e51a-4a1a-a230-69ca113931fa', N'test2', N'O3+kibh3E+/d87KHKionQrkVnE9t/eJ/ZeQQdliKiWxg/l28FwJK3sngnukQYdxR', N'test2@example.com'),
(N'477a1e81-9fdd-4c86-97ee-dce8f10e38a7', N'test1', N'qQFOwDBnX+DHddrytDm0Nu4XLEkhsk6aCzfIwZtpr4gbY39PqCrEUgUtA0PyV0El', N'test1@example.com');

GO


6. Test the API with Swagger
Go to Swagger in the ContactsService API and try the following operations:

Create new contacts.
Get existing contacts.
Update contacts.
Delete contacts.
