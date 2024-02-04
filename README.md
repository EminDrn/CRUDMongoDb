# CRUDMongoDb

CRUDMongoDb is a simple CRUD (Create, Read, Update, Delete) application using MongoDB as the database. It provides API endpoints for managing products and users.

## Getting Started

To get started with the project, follow these steps:

### Prerequisites

Make sure you have the following tools installed on your machine:

- .NET SDK [Download Here](https://dotnet.microsoft.com/download)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/CRUDMongoDb.git
   cd CRUDMongoDb
2. Update appsettings.json with your MongoDB connection details.

   ```appsettings.json
    {
   "MongoDb": {
     "ConnectionString": "mongodb://localhost:27017",
     "DatabaseName": "YourDatabaseName",
     "UserCollectionName": "User",
     "ProductCollectionName": "Product"
     }
   }
3. Run the application
    ```bash
   dotnet run
