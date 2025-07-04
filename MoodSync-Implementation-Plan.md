# MoodSync Implementation Plan 🚀

## Project Overview
**Application**: MoodSync - Emotional Weather for Friend Groups  
**Timeline**: 8 weeks (56 days)  
**Technology Stack**: ASP.NET Core 8.0 + Blazor Server + PostgreSQL + Azure  
**Team Size**: 1 developer (solo project)  

## Phase 1: Foundation (Weeks 1-2) 🏗️

### Week 1: Project Setup & Infrastructure

#### Day 1: Development Environment Setup
**Goal**: Get your development environment ready for MoodSync development

**Morning (2-3 hours):**
- [ ] **Install Core Development Tools**
  - [ ] Download and install Visual Studio 2022 Community (or VS Code with C# extension)
  - [ ] Install .NET 8.0 SDK from https://dotnet.microsoft.com/download
  - [ ] Verify installation: `dotnet --version` (should show 8.0.x)
  - [ ] Install Git for Windows if not already installed
  - [ ] Install GitHub CLI: `winget install GitHub.cli`

**Afternoon (2-3 hours):**
- [ ] **Install Database and Container Tools**
  - [ ] Download and install Docker Desktop for Windows
  - [ ] Start Docker Desktop and verify it's running
  - [ ] Test Docker: `docker run hello-world`
  - [ ] Install pgAdmin 4 for PostgreSQL management
  - [ ] Install Azure CLI: `winget install Microsoft.AzureCLI`

**Evening (1-2 hours):**
- [ ] **Setup Development Workspace**
  - [ ] Create development folder: `mkdir C:\Dev\MoodSync`
  - [ ] Configure Git: `git config --global user.name "Your Name"`
  - [ ] Configure Git: `git config --global user.email "your.email@example.com"`
  - [ ] Login to GitHub: `gh auth login`
  - [ ] Test Azure CLI: `az --version`

#### Day 2: Azure Resources Setup
**Goal**: Provision all Azure resources needed for development

**Morning (2-3 hours):**
- [ ] **Azure Account Setup**
  - [ ] Login to Azure: `az login`
  - [ ] Set default subscription: `az account set --subscription "Your Subscription"`
  - [ ] Create resource group:
    ```bash
    az group create --name rg-moodsync-dev --location "East US"
    ```
  - [ ] Verify resource group: `az group show --name rg-moodsync-dev`

**Afternoon (2-3 hours):**
- [ ] **Create App Service Resources**
  - [ ] Create App Service Plan:
    ```bash
    az appservice plan create --name asp-moodsync-dev --resource-group rg-moodsync-dev --sku B1 --is-linux
    ```
  - [ ] Create Web App:
    ```bash
    az webapp create --resource-group rg-moodsync-dev --plan asp-moodsync-dev --name moodsync-dev-app-[your-initials] --runtime "DOTNET|8.0"
    ```
  - [ ] Test Web App URL in browser (should show default page)

**Evening (1-2 hours):**
- [ ] **Create Database Resources**
  - [ ] Create PostgreSQL server:
    ```bash
    az postgres flexible-server create --resource-group rg-moodsync-dev --name moodsync-dev-db-[your-initials] --admin-user moodadmin --admin-password [create-secure-password] --sku-name Standard_B1ms --public-access 0.0.0.0
    ```
  - [ ] Note down connection string for later use
  - [ ] Create Redis Cache:
    ```bash
    az redis create --resource-group rg-moodsync-dev --name moodsync-dev-redis-[your-initials] --location "East US" --sku Basic --vm-size c0
    ```

#### Day 3: Local Development Setup
**Goal**: Create the solution structure and basic project setup

**Morning (2-3 hours):**
- [ ] **Create Solution Structure**
  - [ ] Navigate to development folder: `cd C:\Dev\MoodSync`
  - [ ] Create new solution: `dotnet new sln -n MoodSync`
  - [ ] Create directory structure:
    ```bash
    mkdir src
    mkdir tests
    mkdir docs
    mkdir scripts
    ```

**Afternoon (2-3 hours):**
- [ ] **Create Core Projects**
  - [ ] Create API project:
    ```bash
    cd src
    dotnet new webapi -n MoodSync.Api
    ```
  - [ ] Create Blazor project:
    ```bash
    dotnet new blazorserver -n MoodSync.Web
    ```
  - [ ] Create Core library:
    ```bash
    dotnet new classlib -n MoodSync.Core
    ```
  - [ ] Create Infrastructure library:
    ```bash
    dotnet new classlib -n MoodSync.Infrastructure
    ```

**Evening (1-2 hours):**
- [ ] **Create Supporting Projects**
  - [ ] Create Shared library:
    ```bash
    dotnet new classlib -n MoodSync.Shared
    ```
  - [ ] Create test project:
    ```bash
    cd ..\tests
    dotnet new xunit -n MoodSync.Tests
    ```
  - [ ] Add all projects to solution:
    ```bash
    cd ..
    dotnet sln add src/MoodSync.Api/MoodSync.Api.csproj
    dotnet sln add src/MoodSync.Web/MoodSync.Web.csproj
    dotnet sln add src/MoodSync.Core/MoodSync.Core.csproj
    dotnet sln add src/MoodSync.Infrastructure/MoodSync.Infrastructure.csproj
    dotnet sln add src/MoodSync.Shared/MoodSync.Shared.csproj
    dotnet sln add tests/MoodSync.Tests/MoodSync.Tests.csproj
    ```

#### Day 4: Project References and Initial Setup
**Goal**: Wire up project dependencies and create initial folder structure

**Morning (2-3 hours):**
- [ ] **Setup Project References**
  - [ ] Add references for Infrastructure project:
    ```bash
    dotnet add src/MoodSync.Infrastructure/MoodSync.Infrastructure.csproj reference src/MoodSync.Core/MoodSync.Core.csproj
    ```
  - [ ] Add references for API project:
    ```bash
    dotnet add src/MoodSync.Api/MoodSync.Api.csproj reference src/MoodSync.Core/MoodSync.Core.csproj
    dotnet add src/MoodSync.Api/MoodSync.Api.csproj reference src/MoodSync.Infrastructure/MoodSync.Infrastructure.csproj
    dotnet add src/MoodSync.Api/MoodSync.Api.csproj reference src/MoodSync.Shared/MoodSync.Shared.csproj
    ```

**Afternoon (2-3 hours):**
- [ ] **Setup More References**
  - [ ] Add references for Web project:
    ```bash
    dotnet add src/MoodSync.Web/MoodSync.Web.csproj reference src/MoodSync.Shared/MoodSync.Shared.csproj
    ```
  - [ ] Add references for Test project:
    ```bash
    dotnet add tests/MoodSync.Tests/MoodSync.Tests.csproj reference src/MoodSync.Core/MoodSync.Core.csproj
    dotnet add tests/MoodSync.Tests/MoodSync.Tests.csproj reference src/MoodSync.Infrastructure/MoodSync.Infrastructure.csproj
    ```

**Evening (1-2 hours):**
- [ ] **Create Initial Folder Structure**
  - [ ] Create folders in MoodSync.Core:
    ```bash
    cd src/MoodSync.Core
    mkdir Entities
    mkdir Services
    mkdir Interfaces
    mkdir Models
    mkdir Enums
    ```
  - [ ] Create folders in MoodSync.Infrastructure:
    ```bash
    cd ../MoodSync.Infrastructure
    mkdir Data
    mkdir Repositories
    mkdir Services
    mkdir Configuration
    ```
  - [ ] Test build: `dotnet build` (should succeed)

#### Day 5: Core Dependencies Installation
**Goal**: Install all required NuGet packages

**Morning (2-3 hours):**
- [ ] **Install Entity Framework Packages**
  - [ ] Add EF Core to Infrastructure:
    ```bash
    dotnet add src/MoodSync.Infrastructure package Microsoft.EntityFrameworkCore.Design
    dotnet add src/MoodSync.Infrastructure package Npgsql.EntityFrameworkCore.PostgreSQL
    dotnet add src/MoodSync.Infrastructure package Microsoft.EntityFrameworkCore.Tools
    ```
  - [ ] Add EF Core to API:
    ```bash
    dotnet add src/MoodSync.Api package Microsoft.EntityFrameworkCore.Design
    ```

**Afternoon (2-3 hours):**
- [ ] **Install Authentication Packages**
  - [ ] Add Identity packages:
    ```bash
    dotnet add src/MoodSync.Api package Microsoft.AspNetCore.Identity.EntityFrameworkCore
    dotnet add src/MoodSync.Api package Microsoft.AspNetCore.Authentication.JwtBearer
    dotnet add src/MoodSync.Api package System.IdentityModel.Tokens.Jwt
    ```
  - [ ] Add password hashing:
    ```bash
    dotnet add src/MoodSync.Infrastructure package BCrypt.Net-Next
    ```

**Evening (1-2 hours):**
- [ ] **Install SignalR Packages**
  - [ ] Add SignalR to API:
    ```bash
    dotnet add src/MoodSync.Api package Microsoft.AspNetCore.SignalR
    ```
  - [ ] Add SignalR client to Web:
    ```bash
    dotnet add src/MoodSync.Web package Microsoft.AspNetCore.SignalR.Client
    ```
  - [ ] Test build: `dotnet build`

#### Day 6: Additional Dependencies
**Goal**: Install remaining packages and setup Redis

**Morning (2-3 hours):**
- [ ] **Install Redis Packages**
  - [ ] Add Redis to Infrastructure:
    ```bash
    dotnet add src/MoodSync.Infrastructure package StackExchange.Redis
    dotnet add src/MoodSync.Infrastructure package Microsoft.Extensions.Caching.StackExchangeRedis
    ```
  - [ ] Add Redis to API:
    ```bash
    dotnet add src/MoodSync.Api package Microsoft.Extensions.Caching.StackExchangeRedis
    ```

**Afternoon (2-3 hours):**
- [ ] **Install Azure and Configuration Packages**
  - [ ] Add Azure packages:
    ```bash
    dotnet add src/MoodSync.Api package Azure.Extensions.AspNetCore.Configuration.Secrets
    dotnet add src/MoodSync.Api package Azure.Identity
    dotnet add src/MoodSync.Api package Azure.Security.KeyVault.Secrets
    ```
  - [ ] Add configuration packages:
    ```bash
    dotnet add src/MoodSync.Api package Microsoft.Extensions.Configuration.Json
    ```

**Evening (1-2 hours):**
- [ ] **Install Monitoring and Testing Packages**
  - [ ] Add monitoring:
    ```bash
    dotnet add src/MoodSync.Api package Microsoft.ApplicationInsights.AspNetCore
    ```
  - [ ] Add testing packages:
    ```bash
    dotnet add tests/MoodSync.Tests package Microsoft.AspNetCore.Mvc.Testing
    dotnet add tests/MoodSync.Tests package Microsoft.EntityFrameworkCore.InMemory
    dotnet add tests/MoodSync.Tests package Moq
    ```
  - [ ] Final build test: `dotnet build`

#### Day 7: Configuration and Local Database Setup
**Goal**: Configure appsettings and setup local development database

**Morning (2-3 hours):**
- [ ] **Setup Local Database with Docker**
  - [ ] Create docker-compose.yml in project root:
    ```yaml
    version: '3.8'
    services:
      postgres:
        image: postgres:15
        environment:
          POSTGRES_DB: moodsync_dev
          POSTGRES_USER: moodadmin
          POSTGRES_PASSWORD: localdev123
        ports:
          - "5432:5432"
        volumes:
          - postgres_data:/var/lib/postgresql/data
      redis:
        image: redis:7-alpine
        ports:
          - "6379:6379"
    volumes:
      postgres_data:
    ```
  - [ ] Start local databases: `docker-compose up -d`
  - [ ] Verify databases are running: `docker-compose ps`

**Afternoon (2-3 hours):**
- [ ] **Configure appsettings.json**
  - [ ] Update src/MoodSync.Api/appsettings.json:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Database=moodsync_dev;Username=moodadmin;Password=localdev123",
        "Redis": "localhost:6379"
      },
      "Jwt": {
        "Key": "your-super-secret-key-here-make-it-long-and-complex",
        "Issuer": "MoodSync",
        "Audience": "MoodSync-Users",
        "ExpiryInMinutes": 60
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*"
    }
    ```
  - [ ] Create appsettings.Development.json with local overrides

**Evening (1-2 hours):**
- [ ] **Setup CORS and Initial Configuration**
  - [ ] Update src/MoodSync.Api/Program.cs to add basic CORS:
    ```csharp
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowBlazorClient",
            policy =>
            {
                policy.WithOrigins("https://localhost:7001")
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials();
            });
    });
    ```
  - [ ] Test that both API and Web projects can run:
    ```bash
    dotnet run --project src/MoodSync.Api
    # In another terminal:
    dotnet run --project src/MoodSync.Web
    ```
  - [ ] Create initial Git repository:
    ```bash
    git init
    git add .
    git commit -m "Initial project setup"
    ```

### Week 2: Database & Authentication Foundation

#### Day 8: Entity Models Creation
**Goal**: Create the core entity models for the application

**Morning (2-3 hours):**
- [ ] **Create User Entity**
  - [ ] Create src/MoodSync.Core/Entities/User.cs:
    ```csharp
    using Microsoft.AspNetCore.Identity;
    
    public class User : IdentityUser<int>
    {
        public string DisplayName { get; set; } = string.Empty;
        public string? Avatar { get; set; }
        public string Timezone { get; set; } = "UTC";
        public bool IsEmailVerified { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }
        
        // Navigation properties
        public ICollection<MoodEntry> MoodEntries { get; set; } = new List<MoodEntry>();
        public ICollection<Friend> RequestedFriends { get; set; } = new List<Friend>();
        public ICollection<Friend> AddressedFriends { get; set; } = new List<Friend>();
        public ICollection<FriendGroup> FriendGroups { get; set; } = new List<FriendGroup>();
        public ICollection<NotificationPreference> NotificationPreferences { get; set; } = new List<NotificationPreference>();
    }
    ```

**Afternoon (2-3 hours):**
- [ ] **Create MoodEntry Entity**
  - [ ] Create src/MoodSync.Core/Entities/MoodEntry.cs:
    ```csharp
    public class MoodEntry
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public MoodType MoodValue { get; set; }
        public byte[]? EncryptedNote { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int VisibilityDuration { get; set; } = 24; // hours
        public bool IsPrivate { get; set; }
        
        // Navigation properties
        public User User { get; set; } = null!;
        public PrivacySetting? PrivacySetting { get; set; }
    }
    ```

**Evening (1-2 hours):**
- [ ] **Create Mood Type Enum**
  - [ ] Create src/MoodSync.Core/Enums/MoodType.cs:
    ```csharp
    public enum MoodType
    {
        Happy = 1,      // 😊
        Neutral = 2,    // 😐
        Sad = 3,        // 😔
        Angry = 4,      // 😠
        Tired = 5       // 😴
    }
    ```
  - [ ] Create src/MoodSync.Core/Enums/FriendStatus.cs:
    ```csharp
    public enum FriendStatus
    {
        Pending = 1,
        Accepted = 2,
        Blocked = 3
    }
    ```

#### Day 9: More Entity Models
**Goal**: Create remaining entity models

**Morning (2-3 hours):**
- [ ] **Create Friend Entity**
  - [ ] Create src/MoodSync.Core/Entities/Friend.cs:
    ```csharp
    public class Friend
    {
        public int Id { get; set; }
        public int RequesterId { get; set; }
        public int AddresseeId { get; set; }
        public FriendStatus Status { get; set; } = FriendStatus.Pending;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        // Navigation properties
        public User Requester { get; set; } = null!;
        public User Addressee { get; set; } = null!;
    }
    ```

**Afternoon (2-3 hours):**
- [ ] **Create Privacy and Notification Entities**
  - [ ] Create src/MoodSync.Core/Entities/PrivacySetting.cs:
    ```csharp
    public class PrivacySetting
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? MoodEntryId { get; set; }
        public VisibilityType VisibilityType { get; set; } = VisibilityType.AllFriends;
        public int[]? AllowedGroupIds { get; set; }
        public int[]? AllowedFriendIds { get; set; }
        public DateTime CreatedAt { get; set; }
        
        // Navigation properties
        public User User { get; set; } = null!;
        public MoodEntry? MoodEntry { get; set; }
    }
    ```
  - [ ] Create src/MoodSync.Core/Enums/VisibilityType.cs:
    ```csharp
    public enum VisibilityType
    {
        AllFriends = 1,
        FriendGroups = 2,
        SpecificFriends = 3,
        Private = 4
    }
    ```

**Evening (1-2 hours):**
- [ ] **Create FriendGroup and NotificationPreference Entities**
  - [ ] Create src/MoodSync.Core/Entities/FriendGroup.cs:
    ```csharp
    public class FriendGroup
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        
        // Navigation properties
        public User User { get; set; } = null!;
        public ICollection<FriendGroupMember> Members { get; set; } = new List<FriendGroupMember>();
    }
    
    public class FriendGroupMember
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int FriendId { get; set; }
        public DateTime AddedAt { get; set; }
        
        // Navigation properties
        public FriendGroup Group { get; set; } = null!;
        public User Friend { get; set; } = null!;
    }
    ```

#### Day 10: DbContext Implementation
**Goal**: Create the database context and configure entity relationships

**Morning (2-3 hours):**
- [ ] **Create DbContext**
  - [ ] Create src/MoodSync.Infrastructure/Data/MoodSyncDbContext.cs:
    ```csharp
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MoodSync.Core.Entities;
    
    public class MoodSyncDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public MoodSyncDbContext(DbContextOptions<MoodSyncDbContext> options) : base(options)
        {
        }
        
        public DbSet<MoodEntry> MoodEntries { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<FriendGroup> FriendGroups { get; set; }
        public DbSet<FriendGroupMember> FriendGroupMembers { get; set; }
        public DbSet<PrivacySetting> PrivacySettings { get; set; }
        public DbSet<NotificationPreference> NotificationPreferences { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Configure entity relationships and constraints
            ConfigureUserRelationships(builder);
            ConfigureMoodEntryRelationships(builder);
            ConfigureFriendRelationships(builder);
            ConfigurePrivacySettings(builder);
            ConfigureIndexes(builder);
        }
        
        private void ConfigureUserRelationships(ModelBuilder builder)
        {
            // User configuration
            builder.Entity<User>(entity =>
            {
                entity.Property(e => e.DisplayName)
                    .HasMaxLength(100)
                    .IsRequired();
                
                entity.Property(e => e.Avatar)
                    .HasMaxLength(500);
                
                entity.Property(e => e.Timezone)
                    .HasMaxLength(50)
                    .HasDefaultValue("UTC");
                
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }
        
        private void ConfigureMoodEntryRelationships(ModelBuilder builder)
        {
            // MoodEntry configuration
            builder.Entity<MoodEntry>(entity =>
            {
                entity.HasOne(e => e.User)
                    .WithMany(u => u.MoodEntries)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
                
                entity.Property(e => e.MoodValue)
                    .HasConversion<int>();
                
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                
                entity.Property(e => e.VisibilityDuration)
                    .HasDefaultValue(24);
            });
        }
        
        private void ConfigureFriendRelationships(ModelBuilder builder)
        {
            // Friend configuration
            builder.Entity<Friend>(entity =>
            {
                entity.HasOne(f => f.Requester)
                    .WithMany(u => u.RequestedFriends)
                    .HasForeignKey(f => f.RequesterId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                entity.HasOne(f => f.Addressee)
                    .WithMany(u => u.AddressedFriends)
                    .HasForeignKey(f => f.AddresseeId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                entity.Property(f => f.Status)
                    .HasConversion<int>();
                
                entity.Property(f => f.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                
                entity.Property(f => f.UpdatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                
                // Prevent duplicate friend requests
                entity.HasIndex(f => new { f.RequesterId, f.AddresseeId })
                    .IsUnique();
            });
        }
        
        private void ConfigurePrivacySettings(ModelBuilder builder)
        {
            // PrivacySetting configuration
            builder.Entity<PrivacySetting>(entity =>
            {
                entity.HasOne(ps => ps.User)
                    .WithMany()
                    .HasForeignKey(ps => ps.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
                
                entity.HasOne(ps => ps.MoodEntry)
                    .WithOne(me => me.PrivacySetting)
                    .HasForeignKey<PrivacySetting>(ps => ps.MoodEntryId)
                    .OnDelete(DeleteBehavior.Cascade);
                
                entity.Property(ps => ps.VisibilityType)
                    .HasConversion<int>();
                
                entity.Property(ps => ps.AllowedGroupIds)
                    .HasColumnType("integer[]");
                
                entity.Property(ps => ps.AllowedFriendIds)
                    .HasColumnType("integer[]");
                
                entity.Property(ps => ps.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }
        
        private void ConfigureIndexes(ModelBuilder builder)
        {
            // Performance indexes
            builder.Entity<MoodEntry>()
                .HasIndex(me => new { me.UserId, me.CreatedAt })
                .HasDatabaseName("IX_MoodEntries_UserId_CreatedAt");
            
            builder.Entity<Friend>()
                .HasIndex(f => new { f.RequesterId, f.Status })
                .HasDatabaseName("IX_Friends_RequesterId_Status");
            
            builder.Entity<Friend>()
                .HasIndex(f => new { f.AddresseeId, f.Status })
                .HasDatabaseName("IX_Friends_AddresseeId_Status");
        }
    }
    ```

**Afternoon (2-3 hours):**
- [ ] **Complete Missing Entity Models**
  - [ ] Create src/MoodSync.Core/Entities/NotificationPreference.cs:
    ```csharp
    public class NotificationPreference
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public NotificationType Type { get; set; }
        public bool IsEnabled { get; set; } = true;
        public TimeSpan? QuietHoursStart { get; set; }
        public TimeSpan? QuietHoursEnd { get; set; }
        public DateTime CreatedAt { get; set; }
        
        // Navigation properties
        public User User { get; set; } = null!;
    }
    ```
  - [ ] Create src/MoodSync.Core/Enums/NotificationType.cs:
    ```csharp
    public enum NotificationType
    {
        DailyMoodReminder = 1,
        FriendMoodUpdate = 2,
        FriendRequest = 3,
        SystemNotification = 4
    }
    ```

**Evening (1-2 hours):**
- [ ] **Configure DbContext in API**
  - [ ] Update src/MoodSync.Api/Program.cs to register DbContext:
    ```csharp
    using MoodSync.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    
    var builder = WebApplication.CreateBuilder(args);
    
    // Add services to the container
    builder.Services.AddDbContext<MoodSyncDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    
    builder.Services.AddDefaultIdentity<User>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<MoodSyncDbContext>();
    
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    
    var app = builder.Build();
    
    // Configure the HTTP request pipeline
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    
    app.Run();
    ```

#### Day 11: Database Migration and Testing
**Goal**: Create and test the initial database migration

**Morning (2-3 hours):**
- [ ] **Create Initial Migration**
  - [ ] Create initial migration:
    ```bash
    dotnet ef migrations add InitialCreate --project src/MoodSync.Infrastructure --startup-project src/MoodSync.Api
    ```
  - [ ] Review the generated migration file in src/MoodSync.Infrastructure/Migrations/
  - [ ] Verify migration looks correct (tables, relationships, indexes)

**Afternoon (2-3 hours):**
- [ ] **Apply Migration to Database**
  - [ ] Ensure Docker containers are running: `docker-compose ps`
  - [ ] Apply migration:
    ```bash
    dotnet ef database update --project src/MoodSync.Infrastructure --startup-project src/MoodSync.Api
    ```
  - [ ] Connect to database using pgAdmin and verify tables were created:
    - Users (from Identity)
    - MoodEntries
    - Friends
    - FriendGroups
    - FriendGroupMembers
    - PrivacySettings
    - NotificationPreferences

**Evening (1-2 hours):**
- [ ] **Test Database Connection**
  - [ ] Create simple test controller to verify database connection
  - [ ] Add health check endpoint
  - [ ] Test API startup: `dotnet run --project src/MoodSync.Api`
  - [ ] Verify Swagger UI loads at https://localhost:7001/swagger

#### Day 12: Authentication Services Setup
**Goal**: Implement JWT authentication service

**Morning (2-3 hours):**
- [ ] **Create Authentication Models**
  - [ ] Create src/MoodSync.Core/Models/AuthModels.cs:
    ```csharp
    public class RegisterRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Timezone { get; set; } = "UTC";
    }
    
    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    
    public class AuthResult
    {
        public bool Success { get; set; }
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public string[] Errors { get; set; } = Array.Empty<string>();
        public UserDto? User { get; set; }
    }
    
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string? Avatar { get; set; }
        public string Timezone { get; set; } = string.Empty;
        public bool IsEmailVerified { get; set; }
    }
    ```

**Afternoon (2-3 hours):**
- [ ] **Create Authentication Service Interface**
  - [ ] Create src/MoodSync.Core/Interfaces/IAuthService.cs:
    ```csharp
    public interface IAuthService
    {
        Task<AuthResult> RegisterAsync(RegisterRequest request);
        Task<AuthResult> LoginAsync(LoginRequest request);
        Task<AuthResult> RefreshTokenAsync(string refreshToken);
        Task<bool> VerifyEmailAsync(string userId, string token);
        Task<bool> ForgotPasswordAsync(string email);
        Task<bool> ResetPasswordAsync(string userId, string token, string newPassword);
        Task<UserDto?> GetUserByIdAsync(int userId);
    }
    ```

**Evening (1-2 hours):**
- [ ] **Create JWT Token Service**
  - [ ] Create src/MoodSync.Core/Interfaces/IJwtTokenService.cs:
    ```csharp
    public interface IJwtTokenService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        bool IsTokenValid(string token);
    }
    ```

#### Day 13: Authentication Service Implementation
**Goal**: Implement the authentication service

**Morning (2-3 hours):**
- [ ] **Implement JWT Token Service**
  - [ ] Create src/MoodSync.Infrastructure/Services/JwtTokenService.cs:
    ```csharp
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;
    
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;
        
        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        }
        
        public string GenerateAccessToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Name, user.DisplayName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, 
                    new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(), 
                    ClaimValueTypes.Integer64)
            };
            
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiryInMinutes"]));
            
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _key,
                ValidateLifetime = false
            };
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
            
            if (securityToken is not JwtSecurityToken jwtSecurityToken || 
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            
            return principal;
        }
        
        public bool IsTokenValid(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],
                    IssuerSigningKey = _key
                };
                
                tokenHandler.ValidateToken(token, validationParameters, out _);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    ```

**Afternoon (2-3 hours):**
- [ ] **Implement Authentication Service**
  - [ ] Create src/MoodSync.Infrastructure/Services/AuthService.cs:
    ```csharp
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using MoodSync.Core.Entities;
    using MoodSync.Core.Interfaces;
    using MoodSync.Core.Models;
    using MoodSync.Infrastructure.Data;
    
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly MoodSyncDbContext _context;
        
        public AuthService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IJwtTokenService jwtTokenService,
            MoodSyncDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
            _context = context;
        }
        
        public async Task<AuthResult> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return new AuthResult
                {
                    Success = false,
                    Errors = new[] { "User with this email already exists" }
                };
            }
            
            var user = new User
            {
                UserName = request.Email,
                Email = request.Email,
                DisplayName = request.DisplayName,
                Timezone = request.Timezone,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            
            var result = await _userManager.CreateAsync(user, request.Password);
            
            if (!result.Succeeded)
            {
                return new AuthResult
                {
                    Success = false,
                    Errors = result.Errors.Select(e => e.Description).ToArray()
                };
            }
            
            var token = _jwtTokenService.GenerateAccessToken(user);
            var refreshToken = _jwtTokenService.GenerateRefreshToken();
            
            return new AuthResult
            {
                Success = true,
                Token = token,
                RefreshToken = refreshToken,
                ExpiresAt = DateTime.UtcNow.AddHours(1),
                User = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    DisplayName = user.DisplayName,
                    Avatar = user.Avatar,
                    Timezone = user.Timezone,
                    IsEmailVerified = user.IsEmailVerified
                }
            };
        }
        
        public async Task<AuthResult> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new AuthResult
                {
                    Success = false,
                    Errors = new[] { "Invalid email or password" }
                };
            }
            
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            
            if (!result.Succeeded)
            {
                return new AuthResult
                {
                    Success = false,
                    Errors = new[] { "Invalid email or password" }
                };
            }
            
            // Update last login
            user.LastLoginAt = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);
            
            var token = _jwtTokenService.GenerateAccessToken(user);
            var refreshToken = _jwtTokenService.GenerateRefreshToken();
            
            return new AuthResult
            {
                Success = true,
                Token = token,
                RefreshToken = refreshToken,
                ExpiresAt = DateTime.UtcNow.AddHours(1),
                User = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    DisplayName = user.DisplayName,
                    Avatar = user.Avatar,
                    Timezone = user.Timezone,
                    IsEmailVerified = user.IsEmailVerified
                }
            };
        }
        
        public async Task<AuthResult> RefreshTokenAsync(string refreshToken)
        {
            // Implementation for refresh token logic
            // This would typically involve storing refresh tokens in database
            // For now, return a basic implementation
            throw new NotImplementedException("Refresh token functionality to be implemented");
        }
        
        public async Task<bool> VerifyEmailAsync(string userId, string token)
        {
            // Email verification logic
            throw new NotImplementedException("Email verification to be implemented");
        }
        
        public async Task<bool> ForgotPasswordAsync(string email)
        {
            // Password reset logic
            throw new NotImplementedException("Password reset to be implemented");
        }
        
        public async Task<bool> ResetPasswordAsync(string userId, string token, string newPassword)
        {
            // Password reset logic
            throw new NotImplementedException("Password reset to be implemented");
        }
        
        public async Task<UserDto?> GetUserByIdAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return null;
            
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                DisplayName = user.DisplayName,
                Avatar = user.Avatar,
                Timezone = user.Timezone,
                IsEmailVerified = user.IsEmailVerified
            };
        }
    }
    ```

**Evening (1-2 hours):**
- [ ] **Register Services in DI Container**
  - [ ] Update src/MoodSync.Api/Program.cs to register services:
    ```csharp
    // Add after DbContext registration
    builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
    builder.Services.AddScoped<IAuthService, AuthService>();
    
    // Configure JWT authentication
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
            };
        });
    ```

#### Day 14: Authentication Controller and Testing
**Goal**: Create authentication controller and test the auth system

**Morning (2-3 hours):**
- [ ] **Create Authentication Controller**
  - [ ] Create src/MoodSync.Api/Controllers/AuthController.cs:
    ```csharp
    using Microsoft.AspNetCore.Mvc;
    using MoodSync.Core.Interfaces;
    using MoodSync.Core.Models;
    
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var result = await _authService.RegisterAsync(request);
            
            if (!result.Success)
            {
                return BadRequest(new { errors = result.Errors });
            }
            
            return Ok(result);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var result = await _authService.LoginAsync(request);
            
            if (!result.Success)
            {
                return BadRequest(new { errors = result.Errors });
            }
            
            return Ok(result);
        }
        
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
        {
            try
            {
                var result = await _authService.RefreshTokenAsync(refreshToken);
                return Ok(result);
            }
            catch (NotImplementedException)
            {
                return BadRequest(new { error = "Refresh token functionality not yet implemented" });
            }
        }
        
        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
            {
                return Unauthorized();
            }
            
            var user = await _authService.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            
            return Ok(user);
        }
    }
    ```

**Afternoon (2-3 hours):**
- [ ] **Test Authentication System**
  - [ ] Start the API: `dotnet run --project src/MoodSync.Api`
  - [ ] Open Swagger UI: https://localhost:7001/swagger
  - [ ] Test user registration:
    ```json
    {
      "email": "test@example.com",
      "password": "TestPass123!",
      "displayName": "Test User",
      "timezone": "UTC"
    }
    ```
  - [ ] Test user login with registered credentials
  - [ ] Test /auth/me endpoint with Bearer token
  - [ ] Verify database has user record

**Evening (1-2 hours):**
- [ ] **Add Input Validation**
  - [ ] Add validation attributes to RegisterRequest and LoginRequest
  - [ ] Test validation by sending invalid data
  - [ ] Create basic unit tests for AuthService
  - [ ] Commit all changes to Git:
    ```bash
    git add .
    git commit -m "Phase 1 complete: Authentication system implemented"
    git push origin main
    ```

**End of Week 2 Summary:**
- ✅ Complete entity model structure
- ✅ Database context with proper relationships
- ✅ Initial database migration
- ✅ JWT token service implementation
- ✅ Authentication service with register/login
- ✅ Authentication controller with endpoints
- ✅ Basic testing of authentication flow

## Phase 2: Core Social Features (Weeks 3-4) 🤝

### Week 3: Mood System & Friend Management

#### Day 15-17: Mood Check-In System
- [ ] **Create Mood Models & Services**
  ```csharp
  // MoodSync.Core/Entities/MoodEntry.cs
  public class MoodEntry
  {
      public int Id { get; set; }
      public int UserId { get; set; }
      public MoodType MoodValue { get; set; }
      public byte[]? EncryptedNote { get; set; }
      public DateTime CreatedAt { get; set; }
      public DateTime UpdatedAt { get; set; }
      public int VisibilityDuration { get; set; } = 24;
      public bool IsPrivate { get; set; }
      
      public User User { get; set; } = null!;
      public PrivacySetting? PrivacySetting { get; set; }
  }
  
  public enum MoodType
  {
      Happy = 1,      // 😊
      Neutral = 2,    // 😐
      Sad = 3,        // 😔
      Angry = 4,      // 😠
      Tired = 5       // 😴
  }
  ```

- [ ] **Implement Mood Service**
  ```csharp
  // MoodSync.Core/Services/IMoodService.cs
  public interface IMoodService
  {
      Task<MoodEntry> CreateMoodEntryAsync(int userId, CreateMoodRequest request);
      Task<MoodEntry?> UpdateMoodEntryAsync(int userId, int moodId, UpdateMoodRequest request);
      Task<bool> DeleteMoodEntryAsync(int userId, int moodId);
      Task<IEnumerable<MoodEntry>> GetUserMoodHistoryAsync(int userId, int days = 30);
      Task<MoodAnalytics> GetMoodAnalyticsAsync(int userId, int days = 30);
  }
  ```

- [ ] **Create Mood API Controllers**
  - POST /api/moods/checkin
  - GET /api/moods/my-history
  - PUT /api/moods/{id}
  - DELETE /api/moods/{id}
  - GET /api/moods/analytics

#### Day 18-21: Friend Management System
- [ ] **Create Friend Models & Services**
  ```csharp
  // MoodSync.Core/Entities/Friend.cs
  public class Friend
  {
      public int Id { get; set; }
      public int RequesterId { get; set; }
      public int AddresseeId { get; set; }
      public FriendStatus Status { get; set; } = FriendStatus.Pending;
      public DateTime CreatedAt { get; set; }
      public DateTime UpdatedAt { get; set; }
      
      public User Requester { get; set; } = null!;
      public User Addressee { get; set; } = null!;
  }
  
  public enum FriendStatus
  {
      Pending,
      Accepted,
      Blocked
  }
  ```

- [ ] **Implement Friend Service**
  ```csharp
  // MoodSync.Core/Services/IFriendService.cs
  public interface IFriendService
  {
      Task<Friend> SendFriendRequestAsync(int requesterId, string addresseeEmail);
      Task<Friend> AcceptFriendRequestAsync(int userId, int friendRequestId);
      Task<bool> RejectFriendRequestAsync(int userId, int friendRequestId);
      Task<bool> RemoveFriendAsync(int userId, int friendId);
      Task<IEnumerable<Friend>> GetFriendsAsync(int userId);
      Task<IEnumerable<Friend>> GetPendingRequestsAsync(int userId);
  }
  ```

- [ ] **Create Friend API Controllers**
  - POST /api/friends/request
  - PUT /api/friends/{id}/accept
  - DELETE /api/friends/{id}/reject
  - GET /api/friends
  - GET /api/friends/requests

### Week 4: Privacy Controls & Real-time Features

#### Day 22-24: Privacy Control System
- [ ] **Create Privacy Models**
  ```csharp
  // MoodSync.Core/Entities/PrivacySetting.cs
  public class PrivacySetting
  {
      public int Id { get; set; }
      public int UserId { get; set; }
      public int? MoodEntryId { get; set; }
      public VisibilityType VisibilityType { get; set; } = VisibilityType.AllFriends;
      public int[]? AllowedGroupIds { get; set; }
      public int[]? AllowedFriendIds { get; set; }
      public DateTime CreatedAt { get; set; }
      
      public User User { get; set; } = null!;
      public MoodEntry? MoodEntry { get; set; }
  }
  
  public enum VisibilityType
  {
      AllFriends,
      FriendGroups,
      SpecificFriends,
      Private
  }
  ```

- [ ] **Implement Privacy Service**
  ```csharp
  // MoodSync.Core/Services/IPrivacyService.cs
  public interface IPrivacyService
  {
      Task<PrivacySetting> UpdatePrivacySettingAsync(int userId, UpdatePrivacyRequest request);
      Task<bool> CanUserViewMoodAsync(int viewerId, int moodEntryId);
      Task<IEnumerable<MoodEntry>> GetVisibleMoodsAsync(int userId, int viewerId);
      Task<PrivacySetting> GetPrivacySettingAsync(int userId, int? moodEntryId = null);
  }
  ```

#### Day 25-28: Real-time Features with SignalR
- [ ] **Create SignalR Hub**
  ```csharp
  // MoodSync.Api/Hubs/MoodHub.cs
  [Authorize]
  public class MoodHub : Hub
  {
      public async Task JoinUserGroup(string userId)
      {
          await Groups.AddToGroupAsync(Context.ConnectionId, $"user_{userId}");
      }
      
      public async Task LeaveUserGroup(string userId)
      {
          await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"user_{userId}");
      }
      
      public override async Task OnConnectedAsync()
      {
          var userId = Context.UserIdentifier;
          if (userId != null)
          {
              await Groups.AddToGroupAsync(Context.ConnectionId, $"user_{userId}");
          }
          await base.OnConnectedAsync();
      }
  }
  ```

- [ ] **Implement Real-time Mood Updates**
  ```csharp
  // MoodSync.Core/Services/IMoodNotificationService.cs
  public interface IMoodNotificationService
  {
      Task NotifyFriendsOfMoodUpdateAsync(int userId, MoodEntry moodEntry);
      Task NotifyUserOfFriendMoodUpdateAsync(int userId, int friendId, MoodEntry moodEntry);
  }
  ```

- [ ] **Setup Redis Backplane**
  ```csharp
  // Configure SignalR with Redis backplane
  services.AddSignalR().AddStackExchangeRedis(configuration.GetConnectionString("Redis"));
  ```

## Phase 3: Engagement Features (Weeks 5-6) 🔔

### Week 5: Notification System

#### Day 29-31: Push Notification Infrastructure
- [ ] **Setup Azure Notification Hubs**
  ```bash
  # Create Notification Hub
  az notification-hub namespace create --resource-group rg-moodsync-dev --name moodsync-dev-hub-ns --location "East US"
  az notification-hub create --resource-group rg-moodsync-dev --namespace-name moodsync-dev-hub-ns --name moodsync-dev-hub
  ```

- [ ] **Create Notification Models**
  ```csharp
  // MoodSync.Core/Entities/NotificationPreference.cs
  public class NotificationPreference
  {
      public int Id { get; set; }
      public int UserId { get; set; }
      public NotificationType Type { get; set; }
      public bool IsEnabled { get; set; } = true;
      public TimeSpan? QuietHoursStart { get; set; }
      public TimeSpan? QuietHoursEnd { get; set; }
      public DateTime CreatedAt { get; set; }
      
      public User User { get; set; } = null!;
  }
  
  public enum NotificationType
  {
      DailyMoodReminder,
      FriendMoodUpdate,
      FriendRequest,
      SystemNotification
  }
  ```

- [ ] **Implement Notification Service**
  ```csharp
  // MoodSync.Core/Services/INotificationService.cs
  public interface INotificationService
  {
      Task SendDailyMoodReminderAsync(int userId);
      Task SendFriendMoodUpdateAsync(int userId, string friendName, MoodType mood);
      Task SendFriendRequestAsync(int userId, string requesterName);
      Task UpdateNotificationPreferencesAsync(int userId, UpdateNotificationPreferencesRequest request);
  }
  ```

#### Day 32-35: Background Services
- [ ] **Create Background Services**
  ```csharp
  // MoodSync.Api/Services/DailyMoodReminderService.cs
  public class DailyMoodReminderService : BackgroundService
  {
      protected override async Task ExecuteAsync(CancellationToken stoppingToken)
      {
          while (!stoppingToken.IsCancellationRequested)
          {
              await ProcessDailyMoodRemindersAsync();
              await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
          }
      }
      
      private async Task ProcessDailyMoodRemindersAsync()
      {
          // Logic to send daily mood reminders based on user preferences
      }
  }
  ```

- [ ] **Setup Scheduled Tasks**
  - Daily mood reminder scheduler
  - Data cleanup tasks
  - Analytics aggregation jobs

### Week 6: Mood History & Analytics

#### Day 36-38: Mood History Features
- [ ] **Create Analytics Models**
  ```csharp
  // MoodSync.Core/Models/MoodAnalytics.cs
  public class MoodAnalytics
  {
      public int UserId { get; set; }
      public int TotalEntries { get; set; }
      public MoodType DominantMood { get; set; }
      public Dictionary<MoodType, int> MoodDistribution { get; set; } = new();
      public List<MoodTrend> Trends { get; set; } = new();
      public DateTime PeriodStart { get; set; }
      public DateTime PeriodEnd { get; set; }
  }
  
  public class MoodTrend
  {
      public DateTime Date { get; set; }
      public MoodType Mood { get; set; }
      public string? Note { get; set; }
  }
  ```

- [ ] **Implement Analytics Service**
  ```csharp
  // MoodSync.Core/Services/IMoodAnalyticsService.cs
  public interface IMoodAnalyticsService
  {
      Task<MoodAnalytics> GetMoodAnalyticsAsync(int userId, int days = 30);
      Task<IEnumerable<MoodTrend>> GetMoodTrendsAsync(int userId, int days = 30);
      Task<Dictionary<MoodType, int>> GetMoodDistributionAsync(int userId, int days = 30);
      Task<byte[]> ExportMoodDataAsync(int userId, ExportFormat format);
  }
  ```

#### Day 39-42: Performance Optimization
- [ ] **Database Optimization**
  ```sql
  -- Create indexes for performance
  CREATE INDEX idx_mood_entries_user_created ON mood_entries(user_id, created_at DESC);
  CREATE INDEX idx_friends_requester_status ON friends(requester_id, status);
  CREATE INDEX idx_friends_addressee_status ON friends(addressee_id, status);
  ```

- [ ] **Implement Caching Strategy**
  ```csharp
  // MoodSync.Infrastructure/Services/CachedMoodService.cs
  public class CachedMoodService : IMoodService
  {
      private readonly IMoodService _moodService;
      private readonly IMemoryCache _cache;
      
      public async Task<IEnumerable<MoodEntry>> GetUserMoodHistoryAsync(int userId, int days = 30)
      {
          var cacheKey = $"mood_history_{userId}_{days}";
          
          if (_cache.TryGetValue(cacheKey, out IEnumerable<MoodEntry>? cachedMoods))
          {
              return cachedMoods!;
          }
          
          var moods = await _moodService.GetUserMoodHistoryAsync(userId, days);
          _cache.Set(cacheKey, moods, TimeSpan.FromMinutes(15));
          
          return moods;
      }
  }
  ```

## Phase 4: Polish & Launch (Weeks 7-8) ✨

### Week 7: UI/UX & Testing

#### Day 43-45: Blazor Frontend Development
- [ ] **Create Blazor Components**
  ```razor
  @* MoodSync.Web/Components/MoodCheckIn.razor *@
  <div class="mood-checkin-container">
      <h3>How are you feeling today?</h3>
      <div class="mood-options">
          @foreach (var mood in Enum.GetValues<MoodType>())
          {
              <button class="mood-button @(SelectedMood == mood ? "selected" : "")"
                      @onclick="() => SelectMood(mood)">
                  @GetMoodEmoji(mood)
                  <span>@mood.ToString()</span>
              </button>
          }
      </div>
      
      <div class="mood-note">
          <textarea @bind="MoodNote" placeholder="Add a note (optional)..."
                    maxlength="280"></textarea>
      </div>
      
      <button class="submit-button" @onclick="SubmitMood" disabled="@(SelectedMood == null)">
          Submit Mood
      </button>
  </div>
  ```

- [ ] **Implement Friend Dashboard**
  ```razor
  @* MoodSync.Web/Components/FriendDashboard.razor *@
  <div class="friend-dashboard">
      <h2>Friend's Moods</h2>
      <div class="friend-cards">
          @foreach (var friend in Friends)
          {
              <div class="friend-card @GetMoodClass(friend.LatestMood)">
                  <div class="friend-avatar">
                      <img src="@friend.Avatar" alt="@friend.DisplayName" />
                  </div>
                  <div class="friend-info">
                      <h4>@friend.DisplayName</h4>
                      <div class="mood-display">
                          <span class="mood-emoji">@GetMoodEmoji(friend.LatestMood)</span>
                          <span class="mood-time">@friend.LastUpdateTime.ToString("HH:mm")</span>
                      </div>
                  </div>
              </div>
          }
      </div>
  </div>
  ```

#### Day 46-49: Comprehensive Testing
- [ ] **Unit Tests**
  ```csharp
  // MoodSync.Tests/Services/MoodServiceTests.cs
  [Fact]
  public async Task CreateMoodEntryAsync_ValidRequest_ReturnsCreatedMood()
  {
      // Arrange
      var mockRepository = new Mock<IMoodRepository>();
      var mockEncryption = new Mock<IEncryptionService>();
      var service = new MoodService(mockRepository.Object, mockEncryption.Object);
      
      var request = new CreateMoodRequest
      {
          MoodValue = MoodType.Happy,
          Note = "Feeling great today!"
      };
      
      // Act
      var result = await service.CreateMoodEntryAsync(1, request);
      
      // Assert
      Assert.NotNull(result);
      Assert.Equal(MoodType.Happy, result.MoodValue);
      mockRepository.Verify(r => r.AddAsync(It.IsAny<MoodEntry>()), Times.Once);
  }
  ```

- [ ] **Integration Tests**
  ```csharp
  // MoodSync.Tests/Controllers/MoodControllerTests.cs
  public class MoodControllerTests : IClassFixture<WebApplicationFactory<Program>>
  {
      [Fact]
      public async Task PostMoodCheckIn_ValidRequest_ReturnsCreatedResponse()
      {
          // Test full API endpoint with authentication
      }
  }
  ```

- [ ] **End-to-End Tests**
  ```csharp
  // MoodSync.Tests/E2E/MoodWorkflowTests.cs
  [Fact]
  public async Task CompleteUserJourney_RegisterLoginCheckInViewFriends_Success()
  {
      // Test complete user workflow using Playwright
  }
  ```

### Week 8: Security & Deployment

#### Day 50-52: Security Audit
- [ ] **Security Checklist**
  - [ ] Input validation on all endpoints
  - [ ] SQL injection prevention
  - [ ] XSS protection
  - [ ] CSRF protection
  - [ ] Rate limiting implementation
  - [ ] Authentication token security
  - [ ] Data encryption verification
  - [ ] Privacy controls testing

- [ ] **Penetration Testing**
  - [ ] Automated security scanning
  - [ ] Manual vulnerability assessment
  - [ ] Social engineering test scenarios
  - [ ] Data breach simulation

#### Day 53-56: Production Deployment
- [ ] **Setup Production Environment**
  ```bash
  # Create production resources
  az group create --name rg-moodsync-prod --location "East US"
  # ... repeat resource creation for production
  ```

- [ ] **Configure CI/CD Pipeline**
  ```yaml
  # .github/workflows/deploy.yml
  name: Deploy to Production
  
  on:
    push:
      branches: [main]
  
  jobs:
    deploy:
      runs-on: ubuntu-latest
      steps:
        - uses: actions/checkout@v4
        - name: Setup .NET
          uses: actions/setup-dotnet@v4
          with:
            dotnet-version: 8.0.x
        - name: Build
          run: dotnet build --configuration Release
        - name: Test
          run: dotnet test --configuration Release --no-build
        - name: Deploy to Azure
          uses: azure/webapps-deploy@v2
          with:
            app-name: moodsync-prod-app
            publish-profile: ${{ secrets.AZURE_WEBAPP_PUBLISH_PROFILE }}
  ```

- [ ] **Production Monitoring Setup**
  ```csharp
  // Configure Application Insights
  services.AddApplicationInsightsTelemetry();
  
  // Custom telemetry
  services.AddSingleton<ITelemetryInitializer, UserTelemetryInitializer>();
  
  // Health checks
  services.AddHealthChecks()
      .AddNpgSql(connectionString)
      .AddRedis(redisConnectionString)
      .AddCheck<MoodServiceHealthCheck>("mood-service");
  ```

## Success Criteria & Metrics 📊

### Technical Metrics
- [ ] **Performance**: Page load time < 2 seconds
- [ ] **Availability**: 99.9% uptime
- [ ] **Security**: Zero critical vulnerabilities
- [ ] **Test Coverage**: > 80% code coverage
- [ ] **API Response Time**: < 500ms for 95% of requests

### User Metrics
- [ ] **Engagement**: Users check in moods 5+ days per week
- [ ] **Retention**: 60% of users return after 7 days
- [ ] **Growth**: 10% monthly user growth
- [ ] **Satisfaction**: 4.5+ star rating

### Business Metrics
- [ ] **User Acquisition**: 100 active users within first month
- [ ] **Feature Adoption**: 80% of users use friend dashboard
- [ ] **Privacy Compliance**: 100% GDPR compliance
- [ ] **Cost Efficiency**: Monthly Azure costs under $200

## Risk Mitigation 🛡️

### Technical Risks
- **Database Performance**: Implement caching and query optimization
- **Real-time Scalability**: Use Redis backplane for SignalR
- **Security Vulnerabilities**: Regular security audits and updates
- **Data Loss**: Automated backups and disaster recovery

### Product Risks
- **Low User Adoption**: Implement user feedback loops early
- **Privacy Concerns**: Transparency in data handling
- **Feature Creep**: Strict adherence to MVP scope
- **Competition**: Focus on unique value proposition

### Operational Risks
- **Deployment Issues**: Comprehensive testing and staging environment
- **Monitoring Gaps**: Full observability with Azure Monitor
- **Team Burnout**: Realistic timeline and scope management
- **Cost Overruns**: Regular Azure cost monitoring

## Tools & Resources 🛠️

### Development Tools
- **IDE**: Visual Studio 2022 / VS Code
- **Database**: PostgreSQL with pgAdmin
- **API Testing**: Postman / Swagger UI
- **Version Control**: Git with GitHub
- **Project Management**: GitHub Projects

### Testing Tools
- **Unit Testing**: xUnit with Moq
- **Integration Testing**: ASP.NET Core Test Host
- **E2E Testing**: Playwright
- **Load Testing**: Azure Load Testing
- **Security Testing**: OWASP ZAP

### Deployment Tools
- **CI/CD**: GitHub Actions
- **Infrastructure**: Azure Resource Manager
- **Monitoring**: Azure Application Insights
- **Logging**: Azure Log Analytics
- **Secrets Management**: Azure Key Vault

## Next Steps 🚀

1. **Start with Phase 1, Day 1**: Setup development environment
2. **Daily Standups**: Track progress against this plan
3. **Weekly Reviews**: Adjust timeline based on actual progress
4. **User Testing**: Get feedback from friends and family early
5. **Continuous Deployment**: Deploy to staging environment regularly

This implementation plan provides a comprehensive roadmap for building MoodSync from concept to production. Each phase builds upon the previous one, ensuring a solid foundation while maintaining momentum toward the final goal.

Remember: This timeline is aggressive but achievable for a focused solo developer. Adjust as needed based on your availability and other commitments.

**Ready to start building? Let's make MoodSync a reality!** 🎉
