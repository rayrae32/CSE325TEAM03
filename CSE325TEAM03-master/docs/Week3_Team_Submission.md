Week3: Team Submission
Team 4
1/21/2026

## 1. Meeting Summary

In this meeting, we discussed our final project. We decided to create a Volunteer Service site where volunteers can search for opportunities to serve and sign up for those opportunities. We discussed the needs, users, scope, features and technical requirements for the project, and made a document with all the necessary requirements.  
**Participants:**

- Kendahl Chae Bingham
- Shayla Foley
- Iyen Samuel Evbosaru
- ANGE JUNIOR GOHOURI
- Gabriel Enrique Torrejon Aguilera
- Boitumelo Hebert Meletse
- Adetokunbo Olutola Osibo
- Judy Hanson
- Maxwell Balla Nvani
- Brenden Taylor Lyon

Project Proposal: Volunteer Service Portal
Team 4
Project Title
ServeHub: Volunteer Service Portal

Project Overview
Our project is a web-based Volunteer Service Portal designed to help users find, participate in, and track volunteer service opportunities within their campus or local community. The application provides a centralized place where service opportunities can be posted and discovered, reducing the friction between people who want to serve and organizations or individuals who need help.
Many students and community members want to volunteer but struggle to find opportunities that match their availability, interests, or location. Our application addresses this problem by allowing users to browse and search available service opportunities, sign up for events, and record completed service in one easy-to-use platform.
This project is valuable because it encourages community involvement while providing users with a simple way to record service opportunities. For students, the portal can help document service for classes, clubs, scholarships, or personal goals. For organizations or individuals posting opportunities, it provides visibility and a streamlined way to manage volunteers.

Problem Statement / Need
Many volunteer opportunities are scattered across emails, flyers, social media posts, or word of mouth, making them difficult to discover and track. There is also often no easy way for volunteers to keep a personal record of the service they have completed. Our application solves this by providing a centralized, organized, and searchable platform for volunteer service.

Target Users
College students looking for service opportunities
Campus clubs or student organizations
Community members seeking local volunteer work
Individuals or groups who need volunteers for service projects

What Makes This Project Interesting or Valuable
Encourages community engagement and service
Solves a real, common problem for students and organizations
Provides practical experience with full-stack development
Uses real-world features like authentication, databases, and CRUD operations
Scalable idea that could be expanded beyond the semester project

Project Scope
What’s IN
User registration and login
Viewing a list of available service opportunities
Searching and filtering service opportunities
Posting new service opportunities
Signing up for service events
Viewing a personal service history dashboard
What’s OUT
Not a mobile app
Messaging or chat between users
Payment or donation processing
Volunteer background checks
Admin approval workflows
Push notifications or emails
Public-facing organization profiles

App Features (User Actions)
Users can:
User account to login
Create an account and log in securely
View and search volunteer service opportunities
Filter opportunities by category, date, or location
Post new service opportunities
Sign up to participate in service events
Connect to a database
Mark a service opportunity as completed
View a history of completed service

Sample User Stories
As a student, I want to browse service opportunities so I can find ways to help my community.
As a user, I want to sign up for a service event so I can participate.
As a volunteer, I want to track completed service activities so I can keep a personal record.
As an organizer, I want to post a service opportunity so others can volunteer.
As a user, I want to search opportunities by keyword so I can quickly find relevant service.

GitHub Board (in place of Trello Board) Requirements
Create a public GitHub board with lists such as:
Backlog
To Do
In Progress
Testing
Done
Each feature could be a card:
User Registration & Login
Service Opportunity CRUD
Sign-Up for Events
Service History Tracking
Each card should include:
Brief description
User story
Notes on technical requirements

Technical Considerations
Data Storage
The application will store:
User accounts (ID, name, email, password hash)
Service opportunities (title, description, date, location, creator)
Sign-ups for service events
Completed service activity (date, user, service event)
User Accounts
Users must register and log in
Authentication will restrict actions like posting or signing up
Logged-in users can view their personal service history
External Services
None required for the initial version
Device Compatibility
Web-based application
Responsive design for desktop, tablet, and mobile browsers
Basic Security
Password hashing
Authentication and authorization checks
Users can only modify their own data
Secure database access through Entity Framework Core

Technologies Used
Framework: .NET 8
Frontend: Blazor
Backend: ASP.NET Core
ORM: Entity Framework Core
Database: SQL Server
Version Control: GitHub

Project Links
GitHub Repository:

https://github.com/kendychae/CSE325-Team4-GroupProject

GitHub Team Project Board:
https://github.com/users/kendychae/projects/2/views/1
