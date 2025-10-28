using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// mvc setup
builder.Services.AddControllersWithViews();

var app = builder.Build();

// pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


// Minimal Api (Custom Route Handler) Metrics

// Custom Redirect Handler
app.MapGet("/redirect-handler", context =>
{
    context.Response.Redirect("https://medium.com/@nihatydin");
    return Task.CompletedTask;
});

// Custom metrics handler
var appStartTime = DateTime.UtcNow;
int totalRequestsHandler = 0;

app.MapGet("/metrics-handler", async context =>
{
    // Total request
    Interlocked.Increment(ref totalRequestsHandler);
    // Uptime
    var uptime = DateTime.UtcNow - appStartTime;
    // Using memory
    var memoryKB = GC.GetTotalMemory(false) / 1024 ;    

    var data = new
    {
        UptimeSeconds = Math.Round(uptime.TotalSeconds, 2),
        TotalRequests = totalRequestsHandler,
        MemoryKB = memoryKB,
        Time = DateTime.Now
    };

    await context.Response.WriteAsJsonAsync(data);
});



// Metrics endpoints speed testing / controller endpoint vs custom handler

app.MapGet("/test-metrics", async context =>
{
    var client = new HttpClient();

    var sw1 = Stopwatch.StartNew();
    // Controller endpoint
    await client.GetAsync("http://localhost:5256/api/metrics");
    sw1.Stop();

    var sw2 = Stopwatch.StartNew();
    // Custom handler
    await client.GetAsync("http://localhost:5256/metrics-handler"); 
    sw2.Stop();

    var result = new
    {
        ControllerTimeMs = sw1.ElapsedMilliseconds,
        HandlerTimeMs = sw2.ElapsedMilliseconds,
        DifferenceMs = sw1.ElapsedMilliseconds - sw2.ElapsedMilliseconds
    };

    await context.Response.WriteAsJsonAsync(result);
});



// Mvc controller routes

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "contactRoute",
    pattern: "{controller=Contact}/{action=Index}/{name?}/{surname?}/{age?}");

app.Run();
