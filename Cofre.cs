namespace Ex02_Cofre
{
    public class Cofre
    {
        // Atributos privados
        private readonly string _dono; // O dono nunca muda
        private string _senha;
        private bool _estaAberto;
        private int _tentativasErradas;
        private bool _estaBloqueado;

        // Construtor
        public Cofre(string dono, string senhaInicial)
        {
            _dono = dono;
            _senha = senhaInicial;
            _estaAberto = false;
            _tentativasErradas = 0;
            _estaBloqueado = false;
        }

        // Propriedades somente leitura para o exterior
        public string Dono => _dono;
        public bool EstaAberto => _estaAberto;       // Leitura apenas
        public int TentativasErradas => _tentativasErradas;
        public bool EstaBloqueado => _estaBloqueado;

        // Método abrir
        public string Abrir(string senhaInformada)
        {
            if (_estaBloqueado)
                return "Cofre Bloqueado! Limite de tentativas atingido. Reinicie o cofre.";

            if (_estaAberto)
                return "O cofre já está aberto.";

            if (senhaInformada == _senha)
            {
                _estaAberto = true;
                _tentativasErradas = 0;
                return "Cofre aberto com sucesso!";
            }
            else
            {
                _tentativasErradas++;
                if (_tentativasErradas >= 3)
                {
                    _estaBloqueado = true;
                    return $"Senha incorreta. Cofre Bloqueado após 3 tentativas erradas!";
                }
                return $"Senha incorreta. Tentativas erradas: {_tentativasErradas}/3.";
            }
        }

        // Método fechar
        public void Fechar()
        {
            if (!_estaAberto)
            {
                Console.WriteLine("O cofre já está fechado.");
                return;
            }
            _estaAberto = false;
            Console.WriteLine("Cofre fechado.");
        }

        // Método alterarSenha: apenas se aberto e senha antiga correta
        public string AlterarSenha(string senhaAntiga, string novaSenha)
        {
            if (!_estaAberto)
                return "O cofre precisa estar aberto para alterar a senha.";

            if (senhaAntiga != _senha)
                return "Senha antiga incorreta.";

            _senha = novaSenha;
            return "Senha alterada com sucesso!";
        }

        // Método de reset (desbloqueio)
        public void Resetar()
        {
            _tentativasErradas = 0;
            _estaBloqueado = false;
            _estaAberto = false;
            Console.WriteLine("Cofre resetado. Tentativas zeradas e cofre desbloqueado.");
        }

        public override string ToString()
        {
            string estado = _estaAberto ? "Aberto" : "Fechado";
            string bloqueio = _estaBloqueado ? " [BLOQUEADO]" : "";
            return $"Cofre de {_dono} | Estado: {estado}{bloqueio} | Tentativas erradas: {_tentativasErradas}";
        }
    }
}
