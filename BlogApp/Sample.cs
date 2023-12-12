namespace BlogApp;

public class Sample
{
    Faker<User> userModelFake;
    Faker<Post> postModelFake;
    public Sample()
    {
        Randomizer.Seed = new Random(20);

        var start = new DateTime(2020, 07, 28, 22, 35, 5);
        var end = DateTime.Now;

        postModelFake = new Faker<Post>()
            .RuleFor(p => p.Id, f => f.Random.Guid())
            .RuleFor(p => p.Content, f => f.Random.Words(100))
            .RuleFor(p => p.CreateAt, f => f.Date.Between(start, end))
            .RuleFor(p => p.UpdateAt, f => f.Date.Between(start, end))
            .RuleFor(p => p.Title, f => f.Random.Words(5));


        userModelFake = new Faker<User>()
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(p => p.CreateAt, f => new DateOnly(2023, f.Random.Int(1,12), f.Random.Int(1, 20)))
                .RuleFor(u => u.FisrtName, f => f.Name.FirstName())
                .RuleFor(u => u.Posts, f=> postModelFake.Generate(1000));
    }

    public List<User> GenerateUser()
    {
        var data = userModelFake.Generate(3);
        return data;
    }

    public List<Post> GeneratePost(int userCount, int postCount)
    {
        postModelFake = new Faker<Post>()
            .RuleFor(p => p.Id, f => f.Random.Guid())
            .RuleFor(p => p.Content, f => f.Random.Words(100))
            .RuleFor(p => p.Title, f => f.Random.Words(10))
            ;

        var data = postModelFake.Generate(postCount);
        return data;
    }
}
