using Markov;
using MarkovTextModel.Models;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

MarkovChain<string> chain = await TrainModel(builder.Environment.ContentRootPath);

builder.Services.AddSingleton<MarkovChain<string>>(chain);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


async Task<MarkovChain<string>> TrainModel(string rootPath)
{
    string folderPath = Path.Combine(rootPath, "Datasets");

    string musicalReviewsPath = Path.Combine(folderPath, "Musical_Instruments_5.json");
    string automotiveReviewsPath = Path.Combine(folderPath, "Automotive_5.json");

    string musicReviews = await File.ReadAllTextAsync(musicalReviewsPath);
    string automotiveReviews = await File.ReadAllTextAsync(automotiveReviewsPath);

    string jsonStrings = string.Concat(musicReviews, automotiveReviews);

    Random random = new Random();

    IEnumerable<string> totalReviews = jsonStrings
        .Split("\n", StringSplitOptions.RemoveEmptyEntries)
        .Select(jsonString => JsonSerializer.Deserialize<AmazonReview>(jsonString).ReviewText)
        .OrderBy(r => random.Next());

    MarkovChain<string> chain = new MarkovChain<string>(4);

    foreach (string review in totalReviews)
    {
        chain.Add(review.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries));
    }

    return chain;
}
