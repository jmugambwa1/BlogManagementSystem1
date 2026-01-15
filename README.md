# Blog Management System

 Blog Management System is a desktop-based Blog Management System built using **C# WinForms** and **SQL Server**.  
It allows users to create, manage, and interact with blog posts through a clean and intuitive interface, while providing admins with moderation and overview tools via a live dashboard.

---

## Features

###  Posts
- Create, edit, and publish blog posts
- Assign posts to categories
- View posts in a postcard-style layout
- Track post creation dates and authors

###  Comments
- Add comments to posts
- View comments per post
- Delete comments (admin/user permissions)
- Auto-refresh dashboard comment count after posting

###  Dashboard
- Total posts count
- Total categories count
- Total comments count (auto-updating)
- User-specific post count
- Most recent post preview

###  Categories
- Create and manage categories
- Assign posts to categories
- Category statistics on dashboard

###  Users & Roles
- User login system
- Admin privileges ( username: admin. Password: admin123)
- Author-based post tracking
- Secure database-driven authentication

---

##  Technology Stack

- **C# (.NET Framework)**
- **Windows Forms (WinForms)**
- **SQL Server (LocalDB)**
- **ADO.NET**
- **Event-driven architecture**

---

##  Architecture Highlights

- Modular WinForms structure
- Centralized database connection handling
- Event-based UI updates (no app reloads)
- Clean separation of UI and data logic
- Scalable structure for future features

---

##  Database Overview

Main tables:
- `Users`
- `Posts`
- `Categories`
- `Comments`

Relationships:
- Posts belong to Categories
- Posts and Comments are linked to Users
- Comments are linked to Posts

---

## 🔄 Auto-Refresh Logic

The dashboard uses **event-based communication** between forms to refresh live data (such as comment counts) immediately after user actions, without restarting the application.

---


##  Setup Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/jmugambwa1/BlogManagementSystem1.git
