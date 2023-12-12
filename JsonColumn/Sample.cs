using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonColumn;

public class Sample
{
    Faker<User> userModelFake;
    Faker<Post> postModelFake;
    public Sample()
    {
        Randomizer.Seed = new Random(20);

        postModelFake = new Faker<Post>()
            .RuleFor(p => p.Content, f => f.Random.Words(100))
            .RuleFor(p => p.Title, f => f.Random.Words(5));


        userModelFake = new Faker<User>()
                .RuleFor(u => u.Id, f => f.Random.Guid())
                .RuleFor(u => u.UserName, f => f.Name.FullName())
                .RuleFor(u => u.Posts, f => postModelFake.Generate(3));
    }

    public List<User> GenerateUser()
    {
        var data = userModelFake.Generate(3);
        return data;
    }

    public List<Post> GeneratePost(int userCount, int postCount)
    {
        postModelFake = new Faker<Post>()
            //.RuleFor(p => p.Id, f => f.Random.Guid())
            .RuleFor(p => p.Content, f => f.Random.Words(100))
            .RuleFor(p => p.Title, f => f.Random.Words(10))
            //.RuleFor(p => p.UserId, f => f.Random.Int(1,userCount))
            ;

        var data = postModelFake.Generate(postCount);
        return data;
    }
}
