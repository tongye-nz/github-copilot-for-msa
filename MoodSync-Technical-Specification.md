# MoodSync Technical Specification 📋

## Project Overview

**Application Name**: MoodSync - Emotional Weather for Friend Groups  
**Version**: 1.0 MVP  
**Target Platform**: Web Application (Progressive Web App)  
**Primary Technology**: ASP.NET Core 8.0 + Blazor Server  

## Executive Summary

MoodSync is a social application that helps friends understand when to provide support versus when to give space. Users share daily mood check-ins visualized as weather icons, creating an "emotional weather map" for their friend groups. The app prioritizes privacy, simplicity, and genuine emotional connection.

## Functional Requirements

### 1. User Management & Authentication

#### User Registration
- **REQ-1.1**: Users must be able to register with email and password
- **REQ-1.2**: Email verification required before account activation
- **REQ-1.3**: Password must meet security requirements (8+ chars, mixed case, numbers)
- **REQ-1.4**: User profiles include: display name, avatar (optional), timezone

#### Authentication & Authorization
- **REQ-1.5**: JWT-based authentication with refresh tokens
- **REQ-1.6**: Session management with automatic logout after 30 days inactivity
- **REQ-1.7**: Password reset functionality via email
- **REQ-1.8**: Account deletion with data retention policy compliance

### 2. Mood Check-In System

#### Daily Mood Entry
- **REQ-2.1**: Users can record one mood per day using 5 emoji categories:
  - 😊 Happy/Great
  - 😐 Neutral/Okay
  - 😔 Sad/Down
  - 😠 Frustrated/Angry
  - 😴 Tired/Exhausted
- **REQ-2.2**: Optional text note (max 280 characters) with mood entry
- **REQ-2.3**: Mood entries are timestamped with user's timezone
- **REQ-2.4**: Users can edit today's mood entry until midnight
- **REQ-2.5**: Mood data is encrypted at rest and in transit

#### Mood History
- **REQ-2.6**: Users can view their personal mood history in calendar format
- **REQ-2.7**: Basic analytics: mood trends over 7/30/90 days
- **REQ-2.8**: Export mood data in JSON format
- **REQ-2.9**: Mood history is private by default

### 3. Friend Management System

#### Friend Connections
- **REQ-3.1**: Users can send friend requests by email or username
- **REQ-3.2**: Friend requests require mutual acceptance
- **REQ-3.3**: Users can unfriend others with confirmation dialog
- **REQ-3.4**: Friend lists are private and not visible to other users
- **REQ-3.5**: Maximum 100 friends per user (scalability limit)

#### Friend Groups
- **REQ-3.6**: Users can create custom friend groups (e.g., "Family", "Work", "Close Friends")
- **REQ-3.7**: Friend groups are used for privacy control
- **REQ-3.8**: Maximum 10 custom groups per user

### 4. Friend Mood Dashboard

#### Mood Visualization
- **REQ-4.1**: Dashboard displays friends' current moods as weather-style cards
- **REQ-4.2**: Mood cards show: friend name, mood emoji, time of last update
- **REQ-4.3**: Optional mood note visible on card tap/hover
- **REQ-4.4**: Cards are sorted by: recent activity, then alphabetical
- **REQ-4.5**: Friends who haven't checked in today show as "No update"

#### Real-time Updates
- **REQ-4.6**: Dashboard updates in real-time when friends post new moods
- **REQ-4.7**: Visual notification indicator for new mood updates
- **REQ-4.8**: Graceful degradation when real-time connection fails

### 5. Privacy Controls

#### Mood Visibility Settings
- **REQ-5.1**: Users can set mood visibility to:
  - All friends
  - Specific friend groups
  - Selected individual friends
  - Nobody (private mode)
- **REQ-5.2**: Users can set mood visibility duration:
  - 24 hours (default)
  - 3 days
  - 7 days
  - Always visible
- **REQ-5.3**: Emergency contacts always see mood regardless of settings
- **REQ-5.4**: Privacy settings are granular per mood entry

#### Data Control
- **REQ-5.5**: Users can delete individual mood entries
- **REQ-5.6**: Users can bulk delete mood history
- **REQ-5.7**: Deleted data is permanently removed (not soft-deleted)
- **REQ-5.8**: Privacy settings audit log for security

### 6. Notification System

#### Push Notifications
- **REQ-6.1**: Daily mood reminder at user-configurable time
- **REQ-6.2**: Friend mood change notifications (opt-in)
- **REQ-6.3**: Friend request notifications
- **REQ-6.4**: Notification preferences per notification type
- **REQ-6.5**: Quiet hours configuration (no notifications during sleep)

#### In-App Notifications
- **REQ-6.6**: Notification center for all app notifications
- **REQ-6.7**: Mark notifications as read/unread
- **REQ-6.8**: Notification history for 30 days

## Technical Architecture

### System Architecture
```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   Blazor Server │    │  ASP.NET Core   │    │   PostgreSQL    │
│   Frontend      │◄──►│   Web API       │◄──►│   Database      │
│                 │    │                 │    │                 │
└─────────────────┘    └─────────────────┘    └─────────────────┘
         │                       │                       │
         │                       │                       │
         ▼                       ▼                       ▼
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│    SignalR      │    │     Redis       │    │  Azure Services │
│   Real-time     │    │   Cache/Session │    │   (Notifications,│
│   Updates       │    │                 │    │   Key Vault)    │
└─────────────────┘    └─────────────────┘    └─────────────────┘
```

### Database Schema

#### Users Table
```sql
CREATE TABLE Users (
    Id SERIAL PRIMARY KEY,
    Email VARCHAR(320) UNIQUE NOT NULL,
    HashedPassword VARCHAR(255) NOT NULL,
    DisplayName VARCHAR(100) NOT NULL,
    Avatar VARCHAR(500),
    Timezone VARCHAR(50) DEFAULT 'UTC',
    IsEmailVerified BOOLEAN DEFAULT FALSE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    LastLoginAt TIMESTAMP
);
```

#### MoodEntries Table
```sql
CREATE TABLE MoodEntries (
    Id SERIAL PRIMARY KEY,
    UserId INTEGER REFERENCES Users(Id) ON DELETE CASCADE,
    MoodValue INTEGER NOT NULL CHECK (MoodValue BETWEEN 1 AND 5),
    EncryptedNote BYTEA,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    VisibilityDuration INTEGER DEFAULT 24, -- hours
    IsPrivate BOOLEAN DEFAULT FALSE
);

-- Partition by date for performance
CREATE TABLE MoodEntries_2025_01 PARTITION OF MoodEntries
FOR VALUES FROM ('2025-01-01') TO ('2025-02-01');
```

#### Friends Table
```sql
CREATE TABLE Friends (
    Id SERIAL PRIMARY KEY,
    RequesterId INTEGER REFERENCES Users(Id) ON DELETE CASCADE,
    AddresseeId INTEGER REFERENCES Users(Id) ON DELETE CASCADE,
    Status VARCHAR(20) DEFAULT 'pending' CHECK (Status IN ('pending', 'accepted', 'blocked')),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UNIQUE(RequesterId, AddresseeId)
);
```

#### FriendGroups Table
```sql
CREATE TABLE FriendGroups (
    Id SERIAL PRIMARY KEY,
    UserId INTEGER REFERENCES Users(Id) ON DELETE CASCADE,
    GroupName VARCHAR(100) NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE FriendGroupMembers (
    Id SERIAL PRIMARY KEY,
    GroupId INTEGER REFERENCES FriendGroups(Id) ON DELETE CASCADE,
    FriendId INTEGER REFERENCES Users(Id) ON DELETE CASCADE,
    AddedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UNIQUE(GroupId, FriendId)
);
```

#### PrivacySettings Table
```sql
CREATE TABLE PrivacySettings (
    Id SERIAL PRIMARY KEY,
    UserId INTEGER REFERENCES Users(Id) ON DELETE CASCADE,
    MoodEntryId INTEGER REFERENCES MoodEntries(Id) ON DELETE CASCADE,
    VisibilityType VARCHAR(20) DEFAULT 'all_friends' 
        CHECK (VisibilityType IN ('all_friends', 'friend_groups', 'specific_friends', 'private')),
    AllowedGroupIds INTEGER[],
    AllowedFriendIds INTEGER[],
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
```

### API Endpoints

#### Authentication Endpoints
```
POST /api/auth/register
POST /api/auth/login  
POST /api/auth/refresh
POST /api/auth/logout
POST /api/auth/forgot-password
POST /api/auth/reset-password
```

#### Mood Management Endpoints
```
GET /api/moods/my-history?days=30
POST /api/moods/checkin
PUT /api/moods/{id}
DELETE /api/moods/{id}
GET /api/moods/analytics?period=30d
```

#### Friend Management Endpoints
```
GET /api/friends
POST /api/friends/request
PUT /api/friends/{id}/accept
DELETE /api/friends/{id}
GET /api/friends/requests
GET /api/friends/moods
```

#### Friend Groups Endpoints
```
GET /api/friend-groups
POST /api/friend-groups
PUT /api/friend-groups/{id}
DELETE /api/friend-groups/{id}
POST /api/friend-groups/{id}/members
DELETE /api/friend-groups/{groupId}/members/{friendId}
```

#### Privacy Settings Endpoints
```
GET /api/privacy/settings
PUT /api/privacy/settings
GET /api/privacy/settings/{moodEntryId}
PUT /api/privacy/settings/{moodEntryId}
```

## Non-Functional Requirements

### Performance Requirements
- **NFR-1**: Page load time under 2 seconds on 3G connection
- **NFR-2**: API response time under 500ms for 95% of requests
- **NFR-3**: Real-time updates delivered within 1 second
- **NFR-4**: Support 1000 concurrent users initially

### Security Requirements
- **NFR-5**: All data encrypted in transit (TLS 1.3)
- **NFR-6**: Mood data encrypted at rest (AES-256)
- **NFR-7**: Password hashing with bcrypt (cost factor 12)
- **NFR-8**: JWT tokens expire after 1 hour, refresh tokens after 30 days
- **NFR-9**: Rate limiting: 100 requests per minute per user
- **NFR-10**: SQL injection prevention via parameterized queries

### Scalability Requirements
- **NFR-11**: Database partitioning for mood entries by date
- **NFR-12**: Redis caching for frequently accessed data
- **NFR-13**: Horizontal scaling capability for web servers
- **NFR-14**: Database connection pooling (max 100 connections)

### Reliability Requirements
- **NFR-15**: 99.9% uptime SLA
- **NFR-16**: Automated health checks every 30 seconds
- **NFR-17**: Graceful degradation when real-time features fail
- **NFR-18**: Database backup every 24 hours, retained for 30 days

### Usability Requirements
- **NFR-19**: Mobile-responsive design (works on 360px width)
- **NFR-20**: Progressive Web App capabilities
- **NFR-21**: Accessibility compliance (WCAG 2.1 AA)
- **NFR-22**: Support for major browsers (Chrome, Firefox, Safari, Edge)

## User Stories

### Epic 1: User Onboarding
- **US-1**: As a new user, I want to register with my email so I can create an account
- **US-2**: As a new user, I want to verify my email so my account is secure
- **US-3**: As a new user, I want to set up my profile so others can recognize me
- **US-4**: As a new user, I want a tutorial so I understand how to use the app

### Epic 2: Daily Mood Tracking
- **US-5**: As a user, I want to check in my daily mood so I can track my emotional state
- **US-6**: As a user, I want to add a note to my mood so I can provide context
- **US-7**: As a user, I want to edit today's mood so I can correct mistakes
- **US-8**: As a user, I want to view my mood history so I can see patterns

### Epic 3: Friend Connections
- **US-9**: As a user, I want to send friend requests so I can connect with people
- **US-10**: As a user, I want to accept friend requests so I can build my network
- **US-11**: As a user, I want to organize friends into groups so I can manage privacy
- **US-12**: As a user, I want to unfriend people so I can remove unwanted connections

### Epic 4: Friend Mood Awareness
- **US-13**: As a user, I want to see my friends' moods so I know how they're doing
- **US-14**: As a user, I want real-time updates so I get timely information
- **US-15**: As a user, I want to see mood notes so I understand context
- **US-16**: As a user, I want to know when friends haven't checked in

### Epic 5: Privacy Control
- **US-17**: As a user, I want to control who sees my mood so I maintain privacy
- **US-18**: As a user, I want to set how long my mood is visible so I control exposure
- **US-19**: As a user, I want to have emergency contacts so important people always know
- **US-20**: As a user, I want to delete my mood history so I can remove old data

### Epic 6: Notifications
- **US-21**: As a user, I want daily reminders so I don't forget to check in
- **US-22**: As a user, I want friend mood notifications so I stay informed
- **US-23**: As a user, I want to customize notification settings so I control frequency
- **US-24**: As a user, I want quiet hours so I'm not disturbed during sleep

## Implementation Timeline

### Phase 1: Foundation (Weeks 1-2)
- Project setup and Azure resource provisioning
- User authentication system
- Basic mood check-in functionality
- Database schema implementation

### Phase 2: Core Social Features (Weeks 3-4)
- Friend management system
- Friend mood dashboard
- Privacy controls implementation
- Real-time updates with SignalR

### Phase 3: Engagement Features (Weeks 5-6)
- Push notification system
- Mood history and analytics
- Performance optimization
- Comprehensive testing

### Phase 4: Polish & Launch (Weeks 7-8)
- UI/UX refinement
- Security audit and penetration testing
- Performance testing and optimization
- Production deployment and monitoring

## Testing Strategy

### Unit Testing
- Service layer business logic
- Data access layer methods
- Authentication and authorization
- Privacy control logic
- Target: 80% code coverage

### Integration Testing
- API endpoint testing
- Database integration tests
- SignalR hub testing
- Authentication flow testing

### End-to-End Testing
- User registration and login flows
- Mood check-in and viewing workflows
- Friend management workflows
- Privacy settings workflows
- Notification delivery testing

### Performance Testing
- Load testing with 1000 concurrent users
- Database performance under load
- Real-time update performance
- Memory usage and leak detection

## Deployment Strategy

### Development Environment
- Local development with Docker containers
- PostgreSQL and Redis in containers
- Azure Storage Emulator for blob storage
- Local SSL certificates for HTTPS

### Staging Environment
- Azure App Service staging slots
- Shared Azure Database for PostgreSQL
- Azure Notification Hubs test environment
- Automated deployment via GitHub Actions

### Production Environment
- Azure App Service with auto-scaling
- Azure Database for PostgreSQL (General Purpose)
- Azure Redis Cache (Standard tier)
- Azure Application Insights monitoring
- Azure Key Vault for secrets management

## Monitoring & Observability

### Application Monitoring
- Application Insights for performance metrics
- Custom telemetry for mood check-in rates
- User engagement metrics
- Error tracking and alerting

### Infrastructure Monitoring
- Azure Monitor for resource utilization
- Database performance metrics
- Redis cache hit rates
- Network latency monitoring

### Business Metrics
- Daily/Monthly Active Users
- Mood check-in completion rates
- Friend engagement rates
- User retention rates
- Feature adoption rates

## Security Considerations

### Data Protection
- End-to-end encryption for sensitive data
- Regular security audits
- Compliance with privacy regulations
- Data retention and deletion policies

### Authentication & Authorization
- Multi-factor authentication (future)
- Role-based access control
- Session management
- Brute force attack prevention

### Infrastructure Security
- Network security groups
- Web Application Firewall
- DDoS protection
- Regular security updates

## Conclusion

This technical specification provides a comprehensive blueprint for building the MoodSync MVP. The focus on privacy, simplicity, and emotional connection, combined with robust technical architecture, positions the application for success in the social wellness space.

The phased development approach allows for iterative feedback and continuous improvement, ensuring the final product meets user needs while maintaining technical excellence.

---

**Document Version**: 1.0  
**Last Updated**: July 4, 2025  
**Next Review**: Start of Phase 2 Development
