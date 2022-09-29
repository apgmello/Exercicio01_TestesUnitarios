namespace Eleicao
{
    public class Candidato
    {
        public string Nome { get; }

        private int votos;
        public int Votos
        {
            get
            {
                return votos;
            }
        }

        public Candidato(string nome, int votos = 0)
        {
            Nome = nome;
            this.votos = votos;
        }

        public void AdicionarVoto()
        {
            votos++;
        }

        public int RetornarVotos()
        {
            return Votos;
        }
    }
}
