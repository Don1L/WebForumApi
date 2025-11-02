using WebForumApiApp.Models;
using Microsoft.EntityFrameworkCore;
using Bogus;
using Thread = WebForumApiApp.Models.Thread;

namespace WebForumApiApp.Data;

public static class SeedData
{
    public static async Task SeedDatabaseAsync(ApplicationDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (context.Users.Any())
        {
            Console.WriteLine("Test data already created");
            return;
        }
        
        Console.WriteLine("Star creating test data");
        
        var faker = new Faker();

        // Topics
        var topics = new List<Topic>();
        for (int i = 0; i < 10; i++)
        {
            topics.Add(new Topic
            {
                Name = faker.Commerce.Department(),
                Description = faker.Lorem.Sentence(),
            });
        }
        context.Topics.AddRange(topics);
        
        // Tags
        var tagName = new[]
        {
            "новичок", "ошибка", "совет", "вопрос", "решение", "обсуждение", "дебаг", "архитектура",
            "безопасность", "производительность", "тестирование", "документация", "рефакторинг",
            "алгоритмы", "базы-данных", "api", "frontend", "backend", "fullstack", "devops"
        };
        var tags = new List<Tag>();
        foreach (var name in tagName)
        {
            tags.Add(new Tag { Name = name });
        }
        context.Tags.AddRange(tags);
        
        
        // Users
        var users = new List<User>();
        for (int i = 0; i < 50; i++)
        {
            users.Add(new User
            {
                Username = faker.Internet.UserName(),
                Email = faker.Internet.Email(),
                PasswordHash = "temp_hash",
                PhotoPath = null
            });
        }
        context.Users.AddRange(users);
        
        await context.SaveChangesAsync();
        
        // Theads
        var threads = new List<Thread>();
        for (int i = 0; i < 100; i++)
        {
            var threadDate = faker.Date.Recent(90);
            threadDate = DateTime.SpecifyKind(threadDate, DateTimeKind.Utc);
            threads.Add( new Thread
            {
                Title = faker.Lorem.Sentence(),
                Text = faker.Lorem.Paragraphs(faker.Random.Int(1, 3)),
                AuthorId = users[faker.Random.Int(0, users.Count - 1)].Id,
                TopicId = topics[faker.Random.Int(0, topics.Count - 1)].Id,
                CreatedAt = threadDate,
                IsHidden = false,
                IsDeleted = false,
            });
        }
        context.Threads.AddRange(threads);
        
        await context.SaveChangesAsync();
        
        // ThreadTags
        var threadTags =  new List<ThreadTag>();
        foreach (var thread in threads.OrderBy(x => Guid.NewGuid()).Take(100))
        {
            var randomTag = tags.OrderBy(x => Guid.NewGuid()).Take(faker.Random.Int(1, 2));
            foreach (var tag in randomTag)
            {
                threadTags.Add(new ThreadTag { TagId = tag.Id, ThreadId = thread.Id });
            }
        }
        context.ThreadTags.AddRange(threadTags);
        
        // Comments
        var comments = new List<Comment>();
        foreach (var thread in threads)
        {
            var commentCounter = faker.Random.Int(1, 15);
            for (int i = 0; i < commentCounter; i++)
            {
                var commentDate = faker.Date.Between(thread.CreatedAt, DateTime.UtcNow);
                commentDate = DateTime.SpecifyKind(commentDate, DateTimeKind.Utc);
                comments.Add(new Comment
                    {
                        Text = faker.Lorem.Paragraph(),
                        AuthorId = users[faker.Random.Int(0, users.Count - 1)].Id,
                        ThreadId = threads[faker.Random.Int(0, threads.Count - 1)].Id,
                        CreatedAt = commentDate,
                        IsDeleted = false,
                    });
            }
        }
        context.Comments.AddRange(comments);
        
        await context.SaveChangesAsync();
        
        Console.WriteLine($"Test data seeded successfully");
    }
}