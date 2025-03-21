using SimpleRESTApi.Data;
using SimpleRESTApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection
builder.Services.AddSingleton<ICategory,CategoryADO>();
builder.Services.AddSingleton<IInstructor,InstructorADO>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/v1/categories",(ICategory categoryData)=>{
// Category category = new Category();
// category.CategoryId=1;
// category.CategoryName="ASP.NET Core";
// return category;
var categories = categoryData.GetCategories();
return categories;
});

app.MapGet("api/v1/categories/{id}",(ICategory categoryData,int id)=>{
var categories = categoryData.GetCategoryById(id);
return categories;
});

app.MapPost("api/v1/categories",(ICategory categoryData,Category category)=>{
var newCategory = categoryData.AddCategory(category);
return newCategory;
});

app.MapPut("api/v1/categories",(ICategory categoryData,Category category)=>{
var updateCategory = categoryData.UpdateCategory(category);
return updateCategory;
});
app.MapDelete("api/v1/categories/{id}",(ICategory categoryData,int id)=>{
categoryData.DeleteCategory(id);
return Results.NoContent();
});

app.MapGet("api/v1/instructors",(IInstructor instructorData)=>{
var instructors = instructorData.GetInstructors();
return instructors;
});

app.MapGet("api/v1/instructors/{id}",(IInstructor instructorData,int id)=>{
var instructors = instructorData.GetInstructorById(id);
return instructors;
});

app.MapPost("api/v1/instructors",(IInstructor instructorData,Instructor instructor)=>{
var newInstructor = instructorData.AddInstructor(instructor);
return newInstructor;
});

app.MapPut("api/v1/instructors",(IInstructor instructorData,Instructor instructor)=>{
var updateInstructor = instructorData.UpdateInstructor(instructor);
return updateInstructor;
});
app.MapDelete("api/v1/instructors/{id}",(IInstructor instructorData,int id)=>{
instructorData.DeleteInstructor(id);
return Results.NoContent();
});

app.Run();