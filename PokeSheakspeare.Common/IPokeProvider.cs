using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokeSheakspeare.Common
{
    public interface IPokeProvider
    {
        Task<string> GetDescriptionAsync(string PokemonName);
    }
}
