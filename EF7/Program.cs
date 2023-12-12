// See https://aka.ms/new-console-template for more information

await using (var db = new BlogContext())
{
    var posts = await db.Set<User>()
        //.Include(u => u.Posts)
        .Where(u => u.Posts.Any(p => p.Read > 0))
        .ToListAsync();
    Console.WriteLine($"posts count: {posts.Count}");
}

await using (var db = new BlogContext())
{
    var blogsWithPosts = await db.Users
    .Where(b => db.Posts.Select(p => p.UserId).Contains(b.Id))
    .ToListAsync();
}

await using (var db = new BlogContext())
{
    var ids = new[] { 1, 2, 3 };
    var usersWithPosts = await db.Users
        .Where(u => ids.Contains(u.Id))
        .ToListAsync();
    Console.WriteLine($"-----------------------------------------------------");
}

using (var db = new BlogContext())
{
    var user = db.Users
        .Where(u => u.Id * 3 + 2 > 0 && u.FisrtName != null || u.LastName != null)
        .ToList();
}
Console.ReadKey();