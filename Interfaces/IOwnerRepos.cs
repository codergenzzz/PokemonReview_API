using PokemonReview.Models;

namespace PokemonReview.Interfaces
{
    public interface IOwnerRepos
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        ICollection<Owner> GetOwnerOfAnPokemon(int pokeId);
        ICollection<Pokemon> GetPokemonsByOwner(int ownerID);
        bool OwnersExists(int ownerId);
        bool CreateOwner(Owner owner);
        bool UpdateOwner(Owner owner);
        bool DeleteOwner(Owner owner);
        bool Save();
    }
}
