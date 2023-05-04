namespace Game.Clases;

interface IPokemons
{
    public void Add(PokemonDTO pokemon);
    public void Delete(int id);
    public void Update(int id, PokemonDTO pokemon);
     List<PokemonDTO> All();
}