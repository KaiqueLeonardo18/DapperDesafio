using System.Data;
using System.Transactions;
using BaltaDataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$";

//ADO.NET PURO
//using(var connection = new SqlConnection(connectionString))
//{
//    connection.Open();

//    using(var command = new SqlCommand())
//    {
//        command.Connection = connection;
//
//        command.CommandType = System.Data.CommandType.Text;
//        command.CommandText = "SELECT [Id], [Title] FROM [Category]";
//
//        var reader = command.ExecuteReader();
//        while(reader.Read())
//        {
//            Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
//        }
//    }
//}

var category = new Category();
category.Id = Guid.NewGuid();
category.Title = "Amazon AWS";
category.Url = "amazon";
category.Description = "Categoria destinada a serviços na nuvem";
category.Order = 8;
category.Summary = "AWS Cloud";
category.Featured = false;

var insertSql = @"INSERT INTO [Category] 
                VALUES(
                    @Id,
                    @Title,
                    @Url,
                    @Summary,
                    @Order,
                    @Description,
                    @Featured)";


//DAPPER
using (var connection = new SqlConnection(connectionString))
{
    //ListCategories(connection);
    //ExecuteProcedure(connection);
    //ExecuteReadProcedure(connection);
    //ExecuteReadTesteProcedure(connection);
    //ExecuteScalar(connection);
    //ReadView(connection);
    //OneToOne(connection);
    //OneToMany(connection);
    //DeleteMany(connection);
    //UpdateCategory(connection);
    //ListCategories(connection);
    //CreateCategory(connection);
    //CreateManyCategory(connection);
    //SelectIn(connection);
    //Like(connection);
    Transaction(connection);
}

static void ListCategories(SqlConnection connection)
{
    var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
    foreach (var item in categories)
    {
        Console.WriteLine($"{item.Id} - {item.Title}");
    }
}

static void CreateCategory(SqlConnection connection)
{
    var category = new Category();
    category.Id = Guid.NewGuid();
    category.Title = "Amazon AWS";
    category.Url = "amazon";
    category.Description = "Categoria destinada a serviços na nuvem";
    category.Order = 8;
    category.Summary = "AWS Cloud";
    category.Featured = false;

    var insertSql = @"INSERT INTO [Category] 
                VALUES(
                    @Id,
                    @Title,
                    @Url,
                    @Summary,
                    @Order,
                    @Description,
                    @Featured)";

    //DAPPER
    var rows = connection.Execute(insertSql, new
    {
        Id = category.Id,
        Title = category.Title,
        Url = category.Url,
        Summary = category.Summary,
        Order = category.Order,
        Description = category.Description,
        Featured = category.Featured

    });

    Console.WriteLine($"{rows} linhas inseridas");
}

static void UpdateCategory(SqlConnection connection)
{
    var updateQuery = "UPDATE [Category] SET [Title]=@title WHERE [Id] = @id";

    var rows = connection.Execute(updateQuery, new
    {
        id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
        title = "FrontEnd 2024"
    });

    Console.WriteLine($"{rows} linhas inseridas");
}

static void CreateManyCategory(SqlConnection connection)
{
    var category = new Category();
    category.Id = Guid.NewGuid();
    category.Title = "Amazon AWS";
    category.Url = "amazon";
    category.Description = "Categoria destinada a serviços na nuvem";
    category.Order = 8;
    category.Summary = "AWS Cloud";
    category.Featured = false;

    var category2 = new Category();
    category2.Id = Guid.NewGuid();
    category2.Title = "Amazon AWS2";
    category2.Url = "amazon2";
    category2.Description = "Categoria destinada a serviços na nuvem2";
    category2.Order = 2;
    category2.Summary = "AWS Cloud2";
    category2.Featured = true;

    var insertSql = @"INSERT INTO [Category] 
                VALUES(
                    @Id,
                    @Title,
                    @Url,
                    @Summary,
                    @Order,
                    @Description,
                    @Featured)";

    //DAPPER
    var rows = connection.Execute(insertSql, new[]
    {
        new{

        Id = category.Id,
        Title = category.Title,
        Url = category.Url,
        Summary = category.Summary,
        Order = category.Order,
        Description = category.Description,
        Featured = category.Featured
        },
        new
        {
        Id = category2.Id,
        Title = category2.Title,
        Url = category2.Url,
        Summary = category2.Summary,
        Order = category2.Order,
        Description = category2.Description,
        Featured = category2.Featured
        }

    });

    Console.WriteLine($"{rows} linhas inseridas");
}

static void DeleteMany(SqlConnection connection)
{
    var deleteSql = @"DELETE FROM [Category]
                     WHERE ID = @id";

    var rows = connection.Execute(deleteSql, new[]
    {
        new
        {
            Id = "b0e63538-8e3c-40e3-9f9c-350270eb953c"
        },
        new
        {
            Id = "e1c12337-4eda-4e3a-891e-99c489f9932e"
        }

    });
}

static void ExecuteProcedure(SqlConnection connection)
{
    var procedure = "[spDeleteStudent]";
    var pars = new { StudentId = "83538ce5-7472-438d-b223-e307f1550a64" };

    var affectedRows = connection.Execute(procedure, pars, commandType: CommandType.StoredProcedure);

    Console.WriteLine(affectedRows);
}

static void ExecuteReadProcedure(SqlConnection connection)
{
    var procedure = "[spGetCoursesByCategory]";

    var pars = new { CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142" };

    var courses = connection.Query(procedure, pars, commandType: CommandType.StoredProcedure);

    foreach (var item in courses)
    {
        Console.WriteLine(item.Id);
    }
}

static void ExecuteReadTesteProcedure(SqlConnection connection)
{
    var procedure = "[spGetCoursesByCategory]";

    var pars = new { CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142" };

    var courses = connection.Query<Courses>(procedure, pars, commandType: CommandType.StoredProcedure);

    foreach (var item in courses)
    {
        Console.WriteLine($"{item.Id.ToString()}, {item.Active}, {item.AuthorId}, {item.CategoryId}, {item.CreateDate}, {item.DurationMinute}, {item.Free}, {item.LastUpdateDate}, {item.Level}, {item.Summary}, {item.Tags}, {item.Tag}, {item.Title}");
    }
}

static void ExecuteScalar(SqlConnection connection)
{
    var category = new Category();
    category.Id = Guid.NewGuid();
    category.Title = "Amazon AWS";
    category.Url = "amazon";
    category.Description = "Categoria destinada a serviços na nuvem";
    category.Order = 8;
    category.Summary = "AWS Cloud";
    category.Featured = false;

    var insertSql = @"
                INSERT INTO 
                    [Category] 
                    OUTPUT inserted.[id]
                VALUES(
                    NEWID(),
                    @Title,
                    @Url,
                    @Summary,
                    @Order,
                    @Description,
                    @Featured) SELECT SCOPE_IDENTITY()";

    //DAPPER
    var rows = connection.ExecuteScalar<Guid>(insertSql, new
    {
        Title = category.Title,
        Url = category.Url,
        Summary = category.Summary,
        Order = category.Order,
        Description = category.Description,
        Featured = category.Featured
    });

    Console.WriteLine($"{rows} linhas inseridas");
}

static void ReadView(SqlConnection connection)
{
    var sql = "SELECT * FROM [vcCourses]";

    var courses = connection.Query(sql);

    foreach (var item in courses)
    {
        Console.WriteLine($"{item.Id} - {item.Title}");
    }
}

static void OneToOne(SqlConnection connection)
{
    var sql = @"SELECT 
                * 
            FROM [CareerItem] 
                INNER JOIN 
                    [Course] ON [CareerItem].[CourseId] = [Course].Id";

    var items = connection.Query<CareerItem, Courses, CareerItem>(sql, (careerItem, courses) =>
    {
        careerItem.Courses = courses;
        return careerItem;
    }, splitOn: "Id");

    foreach (var item in items)
    {
        Console.WriteLine(item.Courses.Title);
    }
}

static void OneToMany(SqlConnection connection)
{
    var sql = @"
                SELECT 
                [Career].[Id],
                [Career].[Title],
                [CareerItem].[CareerId] ,
                [CareerItem].[Title]
                    FROM 
                        [Career] 
                INNER JOIN 
                    [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
                ORDER BY
                    [Career].[Title]";

    var careers = new List<Career>();

    var items = connection.Query<Career, CareerItem, Career>(sql, (career, item) =>
    {
        var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
        if (car == null)
        {
            car = career;
            car.Items.Add(item);
            careers.Add(car);
        }
        else
        {
            car.Items.Add(item);
        }

        return career;
    }, splitOn: "CareerId");

    foreach (var career in careers)
    {
        Console.WriteLine($"{career.Title}");

        foreach (var item in career.Items)
        {
            Console.WriteLine($"- {item.Title}");
        }
    }
}

static void QueryMutiple(SqlConnection connection)
{
    var query = "SELECT * FROM [Category]; SELECT * FROM [Course]";

    using (var multi = connection.QueryMultiple(query))
    {
        var categories = multi.Read<Category>();
        var courses = multi.Read<Courses>();

        foreach (var item in categories)
        {
            Console.WriteLine($"{item.Description} - {item.Title}");
        }

        foreach (var item in courses)
        {
            Console.WriteLine($"{item.Title} - {item.Tags}");
        }
    }
}

static void SelectIn(SqlConnection connection)
{
    var query = @"select * From Career where [Id] IN @Id";

    var items = connection.Query<Career>(query, new
    {
        Id = new[] {
            "01ae8a85-b4e8-4194-a0f1-1c6190af54cb",
            "4327ac7e-963b-4893-9f31-9a3b28a4e72b"
       }
    });

    foreach (var item in items)
    {
        Console.WriteLine($"{item.Id} - {item.Title}");
    }
}

static void Like(SqlConnection connection)
{
    var term = "api";
    var query = @"select * From Course where Title LIKE @exp";

    var items = connection.Query<Courses>(query, new
    {
        exp = $"%{term}%"
    });

    foreach (var item in items)
    {
        Console.WriteLine($"{item.Id} - {item.Title}");
    }
}

static void Transaction(SqlConnection connection)
{
    var category = new Category();
    category.Id = Guid.NewGuid();
    category.Title = "Testeeeeeeeeee";
    category.Url = "amazon";
    category.Description = "Categoria destinada a serviços na nuvem";
    category.Order = 8;
    category.Summary = "AWS Cloud";
    category.Featured = false;

    var insertSql = @"INSERT INTO [Category] 
                VALUES(
                    @Id,
                    @Title,
                    @Url,
                    @Summary,
                    @Order,
                    @Description,
                    @Featured)";

    connection.Open();
    using (var transaction = connection.BeginTransaction())
    {
        //DAPPER
        var rows = connection.Execute(insertSql, new[]
        {
                new{

                Id = category.Id,
                Title = category.Title,
                Url = category.Url,
                Summary = category.Summary,
                Order = category.Order,
                Description = category.Description,
                Featured = category.Featured
                }

        }, transaction);
        transaction.Commit();
        Console.WriteLine($"{rows} linhas inseridas");
    }
}