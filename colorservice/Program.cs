
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var mode = System.Environment.GetEnvironmentVariable("MODE") ?? "gray";

app.MapGet("/", () =>
{
    return "Call /getcolor";
});


app.MapGet("/getcolor", () =>
{
    var color = (mode == "color") ? GetRandomColor() : GetRandomGrayScaleColor();
    var host = System.Net.Dns.GetHostName();
    var result = new {color = color, mode = mode, host = host};
    return System.Text.Json.JsonSerializer.Serialize(result);
});

app.Run();


static string GetRandomGrayScaleColor()
{ 
    var rand = new Random();
    var value = rand.Next(0,255);
    return String.Format("#{0:X2}{0:X2}{0:X2}",value);
}

static string GetRandomColor()
{
    var rand = new Random();
    var red = rand.Next(0,255);
    var green = rand.Next(0,255);
    var blue = rand.Next(0,255);
    return String.Format("#{0:X2}{1:X2}{2:X2}", red, green, blue);
}
