using System.Collections.Generic;
using Game.Clases;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<PokemonDTO> Memory = new List<PokemonDTO>();

app.MapGet("/api/v1/pokemon", () => {
    return Results.Ok(Memory);
});

app.MapPost("/api/v1/pokemon/crear",(PokemonDTO pokemon)=>{
    Memory.Add(pokemon);
    return Results.Ok(Memory);
});

app.MapPut("/api/v1/pokemon/{Id}",(int Id , PokemonDTO pokemon)=>{
    PokemonDTO ActuUpdate = (Memory.Single(pokemon => pokemon.Id == Id));
    ActuUpdate.Nombre = pokemon.Nombre;
    ActuUpdate.Tipo = pokemon.Tipo;
    ActuUpdate.Set = pokemon.Set;
    ActuUpdate.defensa = pokemon.defensa;
    return Results.Ok(Memory);
});

app.MapDelete("/api/v1/pokemon/{id}",(int Id)=>{
    return Results.Ok(Memory.RemoveAll(pokemon => pokemon.Id == Id));
});

app.MapPost("/api/v1/pokemon/multiples",(List<PokemonDTO> pokemon) =>{ 
    foreach(PokemonDTO poke in pokemon){
         Memory.Add(poke);
    }

    return Results.Ok(Memory);
});

app.MapGet("/api/v1/pokemon/{Id}", (int Id)=>
{
    return Results.Ok(Memory.Single(pokemon => pokemon.Id ==Id));
});

app.MapGet("/api/v1/pokemon/todos/{tipo}",(string tipo) =>
{
    return Results.Ok(Memory.Where(pokemon => pokemon.Tipo == tipo));
});

app.MapGet("/api/v1/pokemon/menor/{defensa}", (double Defensa)=>{ 
    return Results.Ok(Memory.Where( pokemon => pokemon.defensa <= Defensa)); 
});


//Se crea endpoint para que busque los pokemones con mayor defensa 
app.MapGet("/api/v1/pokemon/todos/{tipo}",(string tipo) =>
{
    return Results.Ok(Memory.Where(pokemon => pokemon.Tipo == tipo));
});

//se crea endpoint para que filtre por letra inicial del nombre del pokemon

app.MapGet("/api/v1/pokemon/inicial/{letra}",(string letra) =>
{
    return Results.Ok(Memory.Where(pokemon => pokemon.Nombre.StartsWith(letra)));
});



app.Run();
