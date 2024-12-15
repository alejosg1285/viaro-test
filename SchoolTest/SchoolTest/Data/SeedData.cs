using SchoolTest.Models;

namespace SchoolTest.Data;

public static class SeedData
{
    public static async Task Seed(SchoolContext context)
    {
        if (context.Genres.Any())
        {
            return;
        }

        List<Genre> genres = new()
        {
            new Genre { Name = "Female" },
            new Genre { Name = "Male" }
        };

        await context.Genres.AddRangeAsync(genres);
        await context.SaveChangesAsync();
    }
}
