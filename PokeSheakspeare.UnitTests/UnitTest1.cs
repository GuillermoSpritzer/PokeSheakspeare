using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokeSheakspeare.Common;
using System.Threading.Tasks;

namespace PokeSheakspeare.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        static readonly string expectedOutcome = "While it can transform into anything, each Ditto\napparently has its own strengths and\nweaknesses when it comes to transformations.";


        [TestMethod]
        public async Task TestPokemonProvider()
        {
            var provider = new PokeProvider();
            var res = await provider.GetDescriptionAsync("ditto");
            Assert.AreNotEqual(-1, res.IndexOf("While it can transform"));
        }
        [TestMethod]
        public async Task TestShakespeareTranslator()
        {
            var translator = new SheakspeareTranslator();
            var res = await translator.GetTranslationAsync("ditto");
            Assert.AreNotEqual(-1, res.IndexOf("While 't can transform"));
        }
    }
}
