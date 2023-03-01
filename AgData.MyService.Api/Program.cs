
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// TODO: Read from configuration
bool validateIssuer = true;
bool validateAudience = true;
string jwtAudience = "3908e419-32ee-40f2-bcce-752002100fae";
string jwtIssuer = "1ce5c147-3b3c-460a-9d07-0a38aefb568c";
string jwtKey = "3d11352f-d45c-42f2- 9b70-3c6388622d3d";
TimeSpan clockSkew = TimeSpan.Zero;

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
	options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
	options.SaveToken = true;
	options.RequireHttpsMetadata = false;
	options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
	{
		ValidateIssuer = validateIssuer,
		ValidateAudience = validateAudience,
		ValidAudience = jwtAudience,
		ValidIssuer = jwtIssuer,
		ClockSkew = clockSkew,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
	};
});

builder.Services.AddSingleton<IRepository>(m =>
{
	var connectionString = "AccountEndpoint=https://gigitworks-cosmos.documents.azure.com:443/;AccountKey=U4njVXGY3yVrXlB9jffdGsZ9hm9H4fhKGILaQw5Oa38XMdr6pkCOZirdTInXavEnONGudGWAnjv42YmZsmWOCw==;";
	var databaseName = "gigit";
	CosmosClientOptions clientOptions = new()
	{
		ConnectionMode = ConnectionMode.Direct
	};
	var cosmosClient = new CosmosClient(connectionString, clientOptions);

	return new Repository(cosmosClient, databaseName);
});

builder.Services.AddSingleton<RequestValidator>();

builder.Services.AddScoped<AddNameAndAddressCommandHandler>();
builder.Services.AddScoped<DeleteNameAndAddressCommandHandler>();
builder.Services.AddScoped<UpdateNameAndAddressCommandHandler>();
builder.Services.AddScoped<SearchNamesAndAddressesQueryHandler>();

var app = builder.Build();

app.UseCors(cors => cors
.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(origin => true)
.AllowCredentials()
);

app.UseExceptionHandler(handler =>
{
	handler.Run(async context =>
	{
		var httpStatus = HttpStatusCode.InternalServerError;
		var response = new ResponseContextBase()
		{
			StatusMessage = "A critical error occured."
		};

		var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
		if (errorFeature is not null)
		{
			var error = errorFeature.Error.GetBaseException() as UserException;
			if (error is not null)
			{
				httpStatus = error.HttpStatusCode;
				response.StatusMessage = error.Message;
			}
			else
			{
				// TODO: Log everything that is not a UserException to Application Insights

			}

		}

		context.Response.StatusCode = (int)httpStatus;
		context.Response.ContentType = "application/json";
		await context.Response.WriteAsJsonAsync<ResponseContextBase>(response);

	});

});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
