namespace Ex01_Lampada
{
    public class Lampada
    {
        // Atributos privados (Encapsulamento)
        private string _marca;
        private readonly string _tecnologia; // Imutável após criação
        private bool _estaLigada;
        private int _brilho;

        // Construtor: marca e tecnologia obrigatórios
        public Lampada(string marca, string tecnologia)
        {
            _marca = marca;
            _tecnologia = tecnologia;
            _estaLigada = false; // Começa desligada
            _brilho = 100;       // Brilho inicial em 100%
        }

        // Propriedades de leitura
        public string Marca => _marca;
        public string Tecnologia => _tecnologia; // Somente leitura (readonly field)
        public bool EstaLigada => _estaLigada;
        public int Brilho => _brilho;

        // Método alternar: liga/desliga
        public void Alternar()
        {
            _estaLigada = !_estaLigada;
            string estado = _estaLigada ? "ligada" : "desligada";
            Console.WriteLine($"Lâmpada {_marca} ({_tecnologia}) agora está {estado}.");
        }

        // Método ajustarBrilho: só funciona se ligada e valor entre 0 e 100
        public void AjustarBrilho(int novoBrilho)
        {
            if (!_estaLigada)
            {
                Console.WriteLine("Não é possível ajustar o brilho: lâmpada desligada.");
                return;
            }

            if (novoBrilho < 0 || novoBrilho > 100)
            {
                Console.WriteLine("Brilho inválido. Informe um valor entre 0 e 100.");
                return;
            }

            _brilho = novoBrilho;
            Console.WriteLine($"Brilho ajustado para {_brilho}%.");
        }

        public override string ToString()
        {
            string estado = _estaLigada ? "Ligada" : "Desligada";
            return $"Lâmpada: {_marca} | Tecnologia: {_tecnologia} | Estado: {estado} | Brilho: {_brilho}%";
        }
    }
}
