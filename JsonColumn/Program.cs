var sample = new Sample();

await using (var context = new BlogContext())
{
    await context.Database.EnsureDeletedAsync();
    await context.Database.EnsureCreatedAsync();
    var test = sample.GenerateUser();
    context.AddRange(test);
    context.SaveChanges();
}

await using (var context = new BlogContext())
{
    var user = await context.Users
        .FirstOrDefaultAsync(u => u.UserName == "Larue Rogahn");
    Console.WriteLine($"{user?.UserName} has {user?.Posts?.Count} posts");
}

Console.WriteLine("done");
Console.ReadKey();
