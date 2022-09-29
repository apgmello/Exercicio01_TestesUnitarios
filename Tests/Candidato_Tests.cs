using Eleicao;

namespace Tests
{
    public class Candidato_Tests
    {
        [Fact]
        public void AdicionarVoto_Test()
        {
            var candidato = new Candidato("Z�");
            int votos = candidato.Votos;

            candidato.AdicionarVoto();

            Assert.True(candidato.Votos == votos + 1);
        }

        [Fact]
        public void NomeCandidato_Test()
        {
            var nomeCandidato = "Z�";
            var candidato = new Candidato(nomeCandidato);

            Assert.Equal(nomeCandidato, candidato.Nome);
        }
    }
}