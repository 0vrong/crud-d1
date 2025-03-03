using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


List<Characters> repo = new List<Characters>() {
    new Characters("potato","loh",14, DateTime.Now)
    };

app.MapGet("/", () => repo);
app.MapPost("/add",(Characters ch) => repo.Add(ch));
app.MapPut("/{id}", (string id, UpdateCharacterDTO dto)=>
{
    Characters buffer = repo.Find(x => x.Name == id);
    buffer.Role = dto.role;
    buffer.Lvl = dto.lvl;
});
app.MapDelete("/delete/{id}",(string id) =>
{
    Characters buffer = repo.Find(x => x.Name == id);
    repo.Remove(buffer);
});
app.Run();

class Characters
{
    public Characters(string name, string role, int lvl, DateTime datenow)
    {
        Name = name;
        Role = role;
        Lvl = lvl;
        DateNow = DateTime.Now;
    }

    public string Name { get; set; }
    public string Role { get; set; }
    public int Lvl { get; set; }
    public DateTime DateNow { get; set; }

}

record class UpdateCharacterDTO (string role, int lvl);