# afya-poo-atv01
## Atividade Prática — Programação Orientada a Objetos
**Centro Universitário Afya São Lucas** | Ciência da Computação / Engenharia da Computação  
**Docente:** Prof. Liluyoud Cury de Lacerda  
**Linguagem:** C# (.NET 8)

---

## 📂 Estrutura do Repositório

```
afya-poo-atv01/
├── Ex01_Lampada/
│   ├── Lampada.cs
│   ├── Program.cs
│   └── Ex01_Lampada.csproj
├── Ex02_Cofre/
│   ├── Cofre.cs
│   ├── Program.cs
│   └── Ex02_Cofre.csproj
├── Ex03_Conta/
│   ├── ContaCorrente.cs
│   ├── Program.cs
│   └── Ex03_Conta.csproj
├── Ex04_RPG/
│   ├── Personagem.cs
│   ├── Program.cs
│   └── Ex04_RPG.csproj
└── README.md
```

---

## 📝 Exercícios

### Ex01 — Lâmpada Inteligente
Classe `Lampada` com encapsulamento básico, estado binário (ligada/desligada), controle de brilho (0–100%) e tecnologia imutável.
- `Alternar()` — liga/desliga
- `AjustarBrilho(int)` — só funciona com a lâmpada ligada

### Ex02 — Cofre Digital
Classe `Cofre` com senha, bloqueio após 3 tentativas erradas e controle de estado (`EstaAberto` somente leitura externamente).
- `Abrir(string)` — valida senha e conta tentativas
- `Fechar()` — fecha o cofre
- `AlterarSenha(string, string)` — exige cofre aberto
- `Resetar()` — desbloqueia após 3 erros

### Ex03 — Conta Corrente Universitária
Classe `ContaCorrente` com campos calculados (`SaldoTotal`, `StatusConta`), número de conta imutável e titular editável.
- `Depositar(double)` — apenas valores positivos
- `Sacar(double)` — permite uso do cheque especial

### Ex04 — Personagem de RPG
Classe `Personagem` com classes Guerreiro (HP 150) e Mago (HP 80), sistema de vida/morte e progressão de nível.
- `ReceberDano(int)` — vida mínima = 0
- `Curar(int)` — não ultrapassa vida máxima; bloqueado se morto
- `SubirNivel()` — +10% vida máxima; restaura HP; bloqueado se morto
- `Ressuscitar()` — único método que revive; mantém o nível

---

## ✅ Checklist de Critérios

| Critério | Status |
|---|---|
| Encapsulamento (atributos `private`) | ✅ |
| Construtores para inicializar o estado | ✅ |
| Campos somente leitura (`readonly` / `get` only) | ✅ |
| Campos calculados (propriedades sem armazenamento) | ✅ |
| Sobrescrita de `ToString()` | ✅ |
| Lógica de negócio com validações internas | ✅ |

---

