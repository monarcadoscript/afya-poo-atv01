namespace Ex03_Conta
{
    public class ContaCorrente
    {
        // Atributos privados
        private readonly string _numeroConta; // Nunca muda
        private string _titular;              // Pode mudar (ex: casamento)
        private double _saldo;
        private double _limite;

        // Construtor
        public ContaCorrente(string numeroConta, string titular)
        {
            _numeroConta = numeroConta;
            _titular = titular;
            _saldo = 0.0;
            _limite = 500.0;
        }

        // Propriedades
        public string NumeroConta => _numeroConta; // Somente leitura
        public string Titular
        {
            get => _titular;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _titular = value;
            }
        }
        public double Saldo => _saldo;   // Saldo não é alterado diretamente
        public double Limite => _limite;

        // Campo calculado: SaldoTotal = saldo + limite
        public double SaldoTotal => _saldo + _limite;

        // Campo calculado: StatusConta
        public string StatusConta => _saldo < 0 ? "Negativo" : "Positivo";

        // Método depositar
        public bool Depositar(double valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Valor de depósito deve ser positivo.");
                return false;
            }
            _saldo += valor;
            Console.WriteLine($"Depósito de R$ {valor:F2} realizado. Novo saldo: R$ {_saldo:F2}");
            return true;
        }

        // Método sacar
        public bool Sacar(double valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Valor de saque deve ser positivo.");
                return false;
            }

            if (valor > SaldoTotal)
            {
                Console.WriteLine($"Saldo insuficiente. Saldo total disponível: R$ {SaldoTotal:F2}");
                return false;
            }

            _saldo -= valor;
            Console.WriteLine($"Saque de R$ {valor:F2} realizado. Novo saldo: R$ {_saldo:F2}");

            if (_saldo < 0)
                Console.WriteLine($"Atenção: você está usando o cheque especial! Limite utilizado.");

            return true;
        }

        public override string ToString()
        {
            return $"Conta: {_numeroConta} | Titular: {_titular} | Saldo: R$ {_saldo:F2} | Limite: R$ {_limite:F2}";
        }
    }
}
