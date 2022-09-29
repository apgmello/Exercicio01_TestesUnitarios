using Eleicao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Urna_Tests
    {
        [Fact]
        public void Urna_Constructor_Test()
        {
            var urna = new Urna();

            Assert.NotNull(urna.VencedorEleicao);
            Assert.Equal("", urna.VencedorEleicao);
            Assert.Equal(0, urna.VotosVencedor);
            Assert.NotNull(urna.Candidatos);
            Assert.Empty(urna.Candidatos);
            Assert.False(urna.EleicaoAtiva);
        }

        [Fact]
        public void Urna_IniciarEncerrarEleicao_Test()
        {
            var urna = new Urna();

            var eleicaoAtiva = urna.EleicaoAtiva;
            Assert.False(eleicaoAtiva);
            urna.IniciarEncerrarEleicao();
            Assert.Equal(!eleicaoAtiva, urna.EleicaoAtiva);

            eleicaoAtiva = urna.EleicaoAtiva;
            Assert.True(eleicaoAtiva);
            urna.IniciarEncerrarEleicao();
            Assert.Equal(!eleicaoAtiva, urna.EleicaoAtiva);
        }

        [Theory]
        [InlineData("Zé")]
        [InlineData("Jão")]
        public void Urna_CadastrarCandidato_Test(string nome)
        {
            var urna = new Urna();
            urna.CadastrarCandidato(nome);

            Assert.Equal(nome, urna.Candidatos.Last().Nome);
        }

        [Fact]
        public void Urna_Votar_NaoCadastrado_Test()
        {
            var urna = new Urna();
            urna.CadastrarCandidato("Zé");
            var resultado = urna.Votar("Jão");

            Assert.False(resultado);
        }

        [Fact]
        public void Urna_Votar_Cadastrado_Test()
        {
            var urna = new Urna();
            urna.CadastrarCandidato("Zé");
            var resultado = urna.Votar("Zé");

            Assert.True(resultado);
        }



        [Theory]
        [InlineData("Zé", 10, "Jão", 8)]
        [InlineData("Zé", 8, "Jão", 10)]
        [InlineData("Zé", 10, "Jão", 10)]
        public void Urna_MostraResultadoEleicao_Test(string candidato1, int votos1, string candidato2, int votos2)
        {
            var urna = new Urna();
            urna.CadastrarCandidato(candidato1);
            urna.CadastrarCandidato(candidato2);

            for (int i = 0; i < votos1; i++)
            {
                urna.Votar(candidato1);
            }

            for (int i = 0; i < votos2; i++)
            {
                urna.Votar(candidato2);
            }
            string esperado;

            if (votos1 > votos2)
            {
                esperado = $"Nome vencedor: {candidato1}. Votos: {votos1}";
            }

            else if (votos2 > votos1)
            {
                esperado = $"Nome vencedor: {candidato2}. Votos: {votos2}";
            }
            else
            {
                if (string.Compare(candidato1, candidato2, StringComparison.Ordinal) < 0)
                {
                    esperado = $"Nome vencedor: {candidato1}. Votos: {votos1}";
                }
                else
                {
                    esperado = $"Nome vencedor: {candidato2}. Votos: {votos2}";
                }
            }
            var resultado = urna.MostrarResultadoEleicao();
            Assert.Equal(esperado, resultado);
        }
    }
}
