var sample = new Sample();
Console.WriteLine("Hello");

#region seed
//// SeedData
//await using (var db = new BlogContext())
//{
//    await db.Database.EnsureDeletedAsync();
//    await db.Database.EnsureCreatedAsync();
//    var test = sample.GenerateUser();
//    db.AddRange(test);
//    db.SaveChanges();
//}
#endregion

#region Contains
await using (var context = new BlogContext())
{
    var usersWithPosts = await context.Users
        .Where(b => context.Posts.Select(p => p.UserId).Contains(b.Id))
        .ToListAsync();
    Console.WriteLine($"-----------------------------------------------------");
}


await using (var context = new BlogContext())
{
    var ids = new[] { 1, 2, 3 };
    var usersWithPosts = await context.Users
        .Where(u => ids.Contains(u.Id))
        .ToListAsync();
    Console.WriteLine($"-----------------------------------------------------");
}

#endregion
//await using (var db = new BlogContext())
//{
//    var user = await db.Set<User>()
//        //.Include(u => u.Posts)
//        .FirstOrDefaultAsync(u => u.FisrtName == "Mina");

//    Console.WriteLine($"{user?.LastName} has {user?.Posts.Count} posts");
//    Console.WriteLine($"-----------------------------------------------------");
//}

//await using (var db = new BlogContext())
//{
//    var posts = await db.Set<User>()
//        //.Include(u => u.Posts)
//        .Where(u => u.Posts.Any(p => p.Read > 0))
//        .ToListAsync();
//    Console.WriteLine($"posts count: {posts.Count}");
//    Console.WriteLine($"-----------------------------------------------------");
//}

//await using (var db = new BlogContext())
//{
//    var users = await db.Users.AsNoTracking().ToListAsync();
//    Console.WriteLine($"-----------------------------------------------------");

//}


#region 括弧消除
//await using (var db = new BlogContext())
//{
//    var user = db.Users
//    .Where(u => u.Id * 3 + 2 > 0 && u.FisrtName != null || u.LastName != null)
//    .ToList();
//    Console.WriteLine($"-----------------------------------------------------");
//}
#endregion

Console.WriteLine("done");
Console.ReadKey();
