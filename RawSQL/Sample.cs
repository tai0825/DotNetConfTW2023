using BenchmarkDotNet.Attributes;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawSQL;

[MemoryDiagnoser]
public class Sample
{
    public Sample() 
    {

    }

    [Benchmark]
    public async Task EFRawSQLFilter()
    {
        using (var db = new BlogContext())
        {
            //var posts = await db.Database.SqlQuery<Post>($"Select * From Posts Where UserId = 1").ToListAsync();
            var posts = await db.Database.SqlQuery<SampleSelect>($"Select Title, Content  From Posts Where UserId = 1").ToListAsync();
        }
    }

    // Select 指定欄位
    public async Task SampleSelect()
    {
        using (var db = new BlogContext())
        {
            var posts = await db.Database.SqlQuery<SampleSelect>($"Select Title, Content From Posts Where UserId = 1").ToListAsync();
        }
    }

    [Benchmark]
    public void EFRawSQL()
    {
        using (var db = new BlogContext())
        {
            var posts = db.Database.SqlQuery<Post>($"Select * From Posts").ToList();
        }
    }

    [Benchmark]
    public void EFQuery()
    {
        using (var db = new BlogContext())
        {
            var posts = db.Posts.ToList();
        }
    }

    [Benchmark]
    public void EFQueryFilter()
    {
        using (var db = new BlogContext())
        {
            var posts = db.Posts.Where(p => p.UserId == 1).ToList();
        }
    }

    [Benchmark]
    public async Task Dapper()
    {
        using (var db = new SqlConnection(""))
        {
            var posts = (await db.QueryAsync<Post>("Select * From Posts")).ToList();
        }
    }

    [Benchmark]
    public void DapperFilter()
    {
        using (var db = new SqlConnection(""))
        {
            var posts = db.Query<Post>("Select * From Posts Where UserId = 1").ToList();
        }
    }
}

