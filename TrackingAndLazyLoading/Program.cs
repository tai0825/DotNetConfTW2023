#region Lazyloading

using (var context = new BlogContext())
{
    context.ChangeTracker.Clear();

    var users = await context.Users.AsNoTracking().ToListAsync();

    Console.WriteLine("Users:");
    for (var i = 0; i < users.Count; i++)
    {
        Console.WriteLine($" ({i + 1}) {users[i].FisrtName} ");
    }

    //Console.WriteLine();
    //Console.Write("選擇一個 user: ");
    //if (int.TryParse(Console.ReadLine(), out var userId))
    //{
    //    Console.WriteLine("Posts:");
    //    foreach (var post in users[userId - 1].Posts)
    //    {
    //        Console.WriteLine($"  {post.Title}");
    //    }
    //}

    foreach (var user in users)
    {
        var postEntry = context.Entry(user).Collection(e => e.Posts);
        await postEntry.LoadAsync();
        if (postEntry.IsLoaded)
        {
            Console.WriteLine($" Posts for User '{user.LastName}' are loaded.");
        }
    }
    Console.ReadLine();
}
#endregion

#region Tracking
//using (var context = new BlogContext())
//{
//    var post = context.Posts.FirstOrDefault();
//    post.Read = 5;
//    context.SaveChanges();
//}

//using (var context = new BlogContext())
//{
//    var post = context.Posts
//                .AsNoTracking()
//                .FirstOrDefault();

//    post.Read = 1;
//    context.SaveChanges();
//}

//using (var context = new BlogContext())
//{
//    var users = await context.Users.ToListAsync();

//    var userEntry = context.Users.Local.FindEntry(1);

//    Console.WriteLine($"Blog '{userEntry.Entity.LastName}'");
//}

//using (var context = new BlogContext())
//{
//    var users = context.Users.ToList();
//    var userEntry = context.Users.Local.FindEntry(2)!;

//    Console.WriteLine($"User: '{userEntry.Entity.LastName}' with key {userEntry.Entity.Id} is tracked in the '{userEntry.State}' state.");
//    Console.Read();
////}

//using (var context = new BlogContext())
//{
//    var users = context.Users.ToList();
//    var userEntry = context.Users.Local.FindEntry(nameof(User.FisrtName), "Reyna")!;

//    Console.WriteLine($"User: '{userEntry.Entity.LastName}' with key {userEntry.Entity.Id} is tracked in the '{userEntry.State}' state.");
//}

//using (var context = new BlogContext())
//{
//    var users = context.Users.ToList();
//    var posts = context.Posts.ToList();
//    var postsEntry = context.Posts.Local.GetEntries(nameof(Post.UserId), 1);
//    var entry = context.ChangeTracker.Entries().Where(a => a.State == EntityState.Unchanged);
//    Console.WriteLine($"Post from user1: {entry.Count()}");

//}

#endregion
