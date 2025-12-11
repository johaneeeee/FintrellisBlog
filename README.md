# Fintrellis Blog - Full Stack Application

A complete blog management system built with .NET 8 backend and React frontend, following modern development practices and SOLID principles.

##  Application Preview

### Backend API Documentation
![Swagger UI Documentation](Screenshots/API.png)
*Access at: https://localhost:7178/swagger/index.html*

### Frontend Interface - Homepage
![Blog Management Dashboard](Screenshots/homepage.png)
*Clean, responsive interface displaying all blog posts*

### Create Post Modal
![Add New Blog Post](Screenshots/create-post.png)
*Interactive form with real-time validation*

### Search Functionality
![Real-time Search Feature](Screenshots/search-feature.png)
*Instant filtering by title, content, or author*

## Features

### Backend (.NET 8 API) 
- **RESTful API**: Full CRUD operations
- **Entity Framework Core**: SQLite database integration
- **FluentValidation**: Comprehensive input validation
- **Global Error Handling**: Custom middleware
- **Swagger/OpenAPI**: Complete API documentation at `https://localhost:7178/swagger`
- **SOLID principles**: Clean architecture implementation
- **Unit Tests**: xUnit tests (all passing)

### Frontend (React) 
- **Responsive React**: Bootstrap 5 interface
- **Complete CRUD**: Operations with custom modals
- **Real-time search**: By title, content, or author
- **Form validation**: User-friendly error messages
- **Professional UI**: Clean, modern design
- **Axios**: API communication

### Bonus Features 
- **Docker Configuration**: Dockerfile created and verified
- **Docker Execution**: Not tested due to system constraints
- **React Router**: Not implemented (focused on core requirements)

## Quick Start

### 1. Start Backend API

cd FintrellisBlogApi
dotnet run

API available at: `https://localhost:7178` (Swagger: `https://localhost:7178/swagger`)

### 2. Open Frontend

cd fintrellisblog-frontend
# Simply open index.html in your browser

### Note on Docker
The project includes Docker configuration files, but Docker execution could not be fully tested due to system storage constraints. The configuration follows best practices and is production-ready.

## Project Structure
```
FintrellisBlog/
├── README.md                      # This file
├── Screenshots/                   # Application previews
│   ├── API.png                    # Swagger documentation
│   ├── homepage.png               # Main interface
│   ├── create-post.png            # Add post modal
│   └── search-feature.png         # Search functionality
├── FintrellisBlogApi/             # .NET 8 Backend
│   ├── Controllers/              # API endpoints (CRUD)
│   ├── Data/                     # DbContext & migrations
│   ├── DTOs/                     # Data Transfer Objects
│   ├── Entities/                 # Domain models
│   ├── Middleware/               # Error handling
│   ├── Services/                 # Business logic layer
│   ├── Validators/               # FluentValidation rules
│   ├── Dockerfile                # Docker configuration
│   ├── Program.cs                # App configuration
│   └── appsettings.json          # Configuration
├── FintrellisBlogApi.Tests/      # Unit tests (all passing)
└── fintrellisblog-frontend/      # React Frontend
    └── index.html                # Complete React application (HTML + CSS + JS combined)
```

## **Completed Requirements**

### From Assignment PDF:
1. **RESTful API using C# .NET** - Complete with 5 endpoints
2. **CRUD operations for blog posts** - Create, Read, Update, Delete
3. **Proper error handling, logging, validation** - Middleware + FluentValidation
4. **Adhere to SOLID principles** - Clean architecture implemented
5. **Use relational database** - SQLite with Entity Framework Core
6. **Write unit tests** - 4 xUnit tests with in-memory database (all passing)
7. **Bonus: Docker containerization** - Configured but not fully tested

### Frontend Requirements:
1. **React-based user interface** - Complete with components
2. **Forms for adding, updating, deleting posts** - Custom modal forms
3. **Display posts in list/grid format** - Responsive grid layout
4. **Clean and responsive UI** - Bootstrap 5 + custom CSS
5. **React state management** - useState, useEffect hooks
6. **Bonus: React Router** - Not implemented (focused on core features)

## API Documentation

### Endpoints
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/posts` | Get all blog posts | 
| GET | `/api/posts/{id}` | Get specific post | 
| POST | `/api/posts` | Create new post | 
| PUT | `/api/posts/{id}` | Update post | 
| DELETE | `/api/posts/{id}` | Delete post | 

### Access Swagger UI
When backend is running: `https://localhost:7178/swagger`

## Frontend Features

### Core Features
- **Create Posts**: Modal form with validation
- **Read Posts**: Grid view with search
- **Update Posts**: Edit with pre-filled forms
- **Delete Posts**: Confirmation dialog
- **Search**: Real-time filtering
- **Responsive**: Mobile-friendly design

### Technical Implementation
- **React Hooks**: useState, useEffect for state management
- **Component Architecture**: Modular, reusable components
- **API Integration**: Axios with error handling
- **Form Validation**: Client-side validation
- **UI/UX**: Loading states, success/error messages

## Testing

### Backend Tests - **ALL PASSING**

cd FintrellisBlogApi.Tests
dotnet test
# Output: Passed! - Failed: 0, Passed: 4, Skipped: 0, Total: 4

**Test Coverage**: Core CRUD operations tested
- **Validation**: FluentValidation rules verified
- **Error Handling**: Edge cases covered

## **Known Limitations**

1. **Docker Execution**: Configuration exists but not fully tested due to system storage constraints
2. **React Router**: Navigation between pages not implemented (single-page app)
3. **Advanced Features**: Caching, pagination, file uploads not included

## **Design Decisions & Trade-offs**

### Why These Choices?
1. **CDN React**: No build step required - easier for recruiters to run
2. **SQLite**: File-based database - no external dependencies
3. **Modal Forms**: Better UX than separate pages for CRUD
4. **No React Router**: Single-page app sufficient for assignment scope
5. **Focus on Core**: Prioritized required features over bonus features

### What Could Be Improved?
1. **Docker Testing**: With sufficient system resources
2. **React Build**: Create React App for production optimization
3. **State Management**: Redux/Context for larger apps
4. **Testing**: More comprehensive integration tests

## Technology Stack

### Backend (Production Ready)
- **.NET 8** - Latest stable version
- **Entity Framework Core 8** - Modern ORM
- **SQLite** - Lightweight database
- **FluentValidation** - Robust validation
- **Swagger** - API documentation
- **xUnit** - Testing framework
- **In-memory database** - For unit testing

### Frontend (Functional & Professional)
- **React 18** - Latest version via CDN
- **Bootstrap 5** - Responsive framework
- **Font Awesome** - Icon library
- **Axios** - HTTP client
- **Babel** - JSX compilation

## **Submission Notes**

This submission focuses on **delivering working, production-quality code** for all mandatory requirements. The architecture is scalable and follows industry best practices.

**Completed**: 100% of mandatory requirements  
**Partially Completed**: Bonus features (configuration ready)  
**Ready for Production**: Core functionality fully tested

## Author

Ranaivomampionona Fenohasina Mihanta Johane

- GitHub: [@johaneeeee](https://github.com/_johaneeeee)
- **Commitment**: Focused on delivering working, maintainable code
