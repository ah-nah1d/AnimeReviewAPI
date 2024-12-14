AnimeReviewAPI 🌟
=================

Welcome to **AnimeReviewAPI**, a robust Web API for managing and exploring anime reviews, studios, categories, and more. This API is designed for anime enthusiasts and developers looking to build applications related to anime content, reviews, and studios.

* * * * *

🚀 Features
-----------

-   Manage **anime**, **categories**, **reviews**, **reviewers**, **countries**, and **studios**.
-   CRUD operations for all entities.
-   Specialized endpoints for relationships like reviews for an anime or anime by a studio.
-   Built with **ASP.NET Core** and designed for scalability and performance.

* * * * *

📖 API Endpoints
----------------

Below is a categorized list of available endpoints:

### **Anime** 🎥

-   `GET /api/Anime` - Retrieve all anime.
-   `GET /api/Anime/{id}` - Retrieve a specific anime by ID.
-   `DELETE /api/Anime/{id}` - Delete an anime by ID.
-   `GET /api/Anime/{id}/rating` - Get the rating for a specific anime.

### **Category** 🗂️

-   `GET /api/Category` - Retrieve all categories.
-   `POST /api/Category` - Create a new category.
-   `GET /api/Category/{categoryId}` - Retrieve a category by ID.
-   `PUT /api/Category/{categoryId}` - Update a category by ID.
-   `DELETE /api/Category/{categoryId}` - Delete a category by ID.
-   `GET /api/Category/anime/{categoryId}` - Get all anime under a specific category.

### **Country** 🌍

-   `GET /api/Country` - Retrieve all countries.
-   `POST /api/Country` - Add a new country.
-   `GET /api/Country/{countryId}` - Retrieve a country by ID.
-   `PUT /api/Country/{countryId}` - Update a country by ID.
-   `DELETE /api/Country/{countryId}` - Delete a country by ID.
-   `GET /country/{studioId}` - Get the country of a specific studio.

### **Review** 📝

-   `GET /api/Review` - Retrieve all reviews.
-   `POST /api/Review` - Add a new review.
-   `GET /api/Review/{reviewId}` - Retrieve a review by ID.
-   `PUT /api/Review/{reviewId}` - Update a review by ID.
-   `DELETE /api/Review/{reviewId}` - Delete a review by ID.
-   `GET /api/Review/anime/{animeId}` - Retrieve all reviews for a specific anime.
-   `DELETE /DeleteReviewsByReviewer/{reviewerId}` - Delete all reviews by a specific reviewer.

### **Reviewer** 🧑‍💻

-   `GET /api/Reviewer` - Retrieve all reviewers.
-   `POST /api/Reviewer` - Add a new reviewer.
-   `GET /api/Reviewer/{reviewerId}` - Retrieve a reviewer by ID.
-   `PUT /api/Reviewer/{reviewerId}` - Update a reviewer by ID.
-   `DELETE /api/Reviewer/{reviewerId}` - Delete a reviewer by ID.
-   `GET /api/Reviewer/{reviewerId}/reviews` - Retrieve all reviews written by a specific reviewer.

### **Studio** 🏢

-   `GET /api/Studio` - Retrieve all studios.
-   `POST /api/Studio` - Add a new studio.
-   `GET /api/Studio/{studioId}` - Retrieve a studio by ID.
-   `PUT /api/Studio/{studioId}` - Update a studio by ID.
-   `DELETE /api/Studio/{studioId}` - Delete a studio by ID.
-   `GET /api/Studio/{studioId}/anime` - Retrieve all anime created by a specific studio.

* * * * *

🛠️ Getting Started
-------------------

### Prerequisites

-   .NET SDK (version 6.0 or higher)
-   A PostgreSQL database for persistence

### Setup

1.  Clone the repository:

    `git clone https://github.com/your-repo/AnimeReviewAPI.git
    cd AnimeReviewAPI`

2.  Update the `appsettings.json` with your PostgreSQL connection string:

    `{
        "ConnectionStrings": {
            "DefaultConnection": "Host=localhost;Database=AnimeReview;Username=your_user;Password=your_password"
        }
    }`

3.  Run database migrations:

    `dotnet ef database update`

4.  Start the application:


    `dotnet run`

5.  Open Swagger UI for testing:\
    Navigate to `http://localhost:5000/swagger` in your browser.

* * * * *

🧩 Tech Stack
-------------

-   **Backend:** ASP.NET Core Web API
-   **Database:** PostgreSQL
-   **ORM:** Entity Framework Core
-   **Documentation:** Swagger UI

* * * * *

🔮 Future Enhancements
----------------------

-   Add support for user authentication and authorization.
-   Implement advanced search and filtering capabilities.
-   Integrate with external anime databases for automatic data population.

* * * * *

📄 License
----------

This project is licensed under the MIT License.

* * * * *

Happy coding! 💻
