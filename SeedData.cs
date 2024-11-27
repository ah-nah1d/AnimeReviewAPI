using AnimeReviewAPI.Data;

namespace AnimeReviewAPI.Models
{
    public class SeedData
    {
        private readonly DataContext dataContext;

        public SeedData(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Seed()
        {
            if (!dataContext.Countries.Any())
            {
                dataContext.Countries.AddRange(
                    new Country { Id = 1, Name = "Japan" },
                    new Country { Id = 2, Name = "USA" }
                );
            }

            if (!dataContext.Studios.Any())
            {
                dataContext.Studios.AddRange(
                    new Studio { Id = 1, Name = "Studio Ghibli", CountryId = 1 },
                    new Studio { Id = 2, Name = "Madhouse", CountryId = 1 },
                    new Studio { Id = 3, Name = "Pixar", CountryId = 2 }
                );
            }

            if (!dataContext.Categories.Any())
            {
                dataContext.Categories.AddRange(
                    new Category { Id = 1, Name = "Action" },
                    new Category { Id = 2, Name = "Adventure" },
                    new Category { Id = 3, Name = "Fantasy" },
                    new Category { Id = 4, Name = "Drama" }
                );
            }

            if (!dataContext.Animes.Any())
            {
                dataContext.Animes.AddRange(
                    new Anime
                    {
                        Id = 1,
                        Title = "Spirited Away",
                         ReleaseDate = new DateTimeOffset(2001, 7, 20, 0, 0, 0, TimeSpan.Zero),
                        StudioId = 1
                    },
                    new Anime
                    {
                        Id = 2,
                        Title = "One Punch Man",
                         ReleaseDate = new DateTimeOffset(2015, 10, 5, 0, 0, 0, TimeSpan.Zero),
                        StudioId = 2
                    },
                    new Anime
                    {
                        Id = 3,
                        Title = "Toy Story",
                        ReleaseDate = new DateTimeOffset(1995, 11, 22, 0, 0, 0, TimeSpan.Zero),
                        StudioId = 3
                    }
                );
            }

            if (!dataContext.AnimeCategories.Any())
            {
                dataContext.AnimeCategories.AddRange(
                    new AnimeCategory { AnimeId = 1, CategoryId = 3 },
                    new AnimeCategory { AnimeId = 1, CategoryId = 4 },
                    new AnimeCategory { AnimeId = 2, CategoryId = 1 },
                    new AnimeCategory { AnimeId = 2, CategoryId = 2 },
                    new AnimeCategory { AnimeId = 3, CategoryId = 2 }
                );
            }

            if (!dataContext.Reviewers.Any())
            {
                dataContext.Reviewers.AddRange(
                    new Reviewer { Id = 1, FirstName = "John", LastName = "Doe" },
                    new Reviewer { Id = 2, FirstName = "Jane", LastName = "Smith" }
                );
            }

            if (!dataContext.Reviews.Any())
            {
                dataContext.Reviews.AddRange(
                    new Review
                    {
                        Id = 1,
                        Title = "Masterpiece",
                        Content = "One of the best animations ever!",
                        Rating = 5,
                        AnimeId = 1,
                        ReviewerId = 1
                    },
                    new Review
                    {
                        Id = 2,
                        Title = "Overhyped",
                        Content = "Not as great as people say.",
                        Rating = 3,
                        AnimeId = 2,
                        ReviewerId = 2
                    }
                );
            }

            dataContext.SaveChanges();
        }
    }
}
