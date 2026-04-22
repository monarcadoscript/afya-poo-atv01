namespace Ex04_RPG
{
    public class Personagem
    {
        // Atributos privados
        private readonly string _nome;
        private readonly string _classe;
        private int _nivel;
        private int _vidaAtual;
        private int _vidaMaxima;

        // Construtor
        public Personagem(string nome, string classe)
        {
            _nome = nome;
            _classe = classe.ToLower() == "guerreiro" ? "Guerreiro" : "Mago";
            _nivel = 1;

            // Vida máxima depende da classe
            _vidaMaxima = _classe == "Guerreiro" ? 150 : 80;
            _vidaAtual = _vidaMaxima; // Começa com vida cheia
        }

        // Propriedades somente leitura
        public string Nome => _nome;
        public string Classe => _classe;
        public int Nivel => _nivel;
        public int VidaAtual => _vidaAtual;
        public int VidaMaxima => _vidaMaxima;

        // Campo calculado: está vivo?
        public bool EstaVivo => _vidaAtual > 0;

        // Método receberDano
        public void ReceberDano(int pontos)
        {
            if (pontos <= 0) return;

            _vidaAtual -= pontos;
            if (_vidaAtual < 0) _vidaAtual = 0; // Vida mínima = 0

            if (!EstaVivo)
                Console.WriteLine($"{_nome} recebeu {pontos} de dano e morreu!");
            else
                Console.WriteLine($"{_nome} recebeu {pontos} de dano. HP: {_vidaAtual}/{_vidaMaxima}");
        }

        // Método curar
        public void Curar(int pontos)
        {
            if (!EstaVivo)
            {
                Console.WriteLine($"{_nome} está morto e não pode ser curado.");
                return;
            }

            if (pontos <= 0) return;

            _vidaAtual += pontos;
            if (_vidaAtual > _vidaMaxima) _vidaAtual = _vidaMaxima; // Não ultrapassa o máximo

            Console.WriteLine($"{_nome} se curou {pontos} pontos. HP: {_vidaAtual}/{_vidaMaxima}");
        }

        // Método subirNível
        public void SubirNivel()
        {
            if (!EstaVivo)
            {
                Console.WriteLine($"{_nome} está morto e não pode subir de nível.");
                return;
            }

            if (_nivel >= 99)
            {
                Console.WriteLine($"{_nome} já está no nível máximo (99)!");
                return;
            }

            _nivel++;

            // Vida máxima aumenta 10% a cada nível
            _vidaMaxima = (int)Math.Round(_vidaMaxima * 1.10);

            // Vida atual restaurada completamente
            _vidaAtual = _vidaMaxima;

            Console.WriteLine($"{_nome} subiu para o nível {_nivel}! Vida Máxima agora: {_vidaMaxima}. HP totalmente restaurado.");
        }

        // Método ressuscitar (a única forma de voltar da morte)
        public void Ressuscitar()
        {
            if (EstaVivo)
            {
                Console.WriteLine($"{_nome} já está vivo!");
                return;
            }

            _vidaAtual = _vidaMaxima;
            Console.WriteLine($"{_nome} foi ressuscitado! HP: {_vidaAtual}/{_vidaMaxima} | Nível mantido: {_nivel}");
        }

        public override string ToString()
        {
            string status = EstaVivo ? "" : " [MORTO]";
            return $"{_nome} ({_classe}) - Lvl {_nivel} - HP: {_vidaAtual}/{_vidaMaxima}{status}";
        }
    }
}
