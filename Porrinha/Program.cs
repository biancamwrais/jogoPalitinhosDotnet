// =====================================================
//  PORRINHA – Bar do Seu Zé
//  Comece pelo arquivo blocos/01-variaveis.md
// =====================================================

Console.WriteLine("O Bar do Seu Zé está em construção...");
// =====================================================
//  PORRINHA – Bar do Seu Zé
// =====================================================

const int PALITOS_INICIAIS = 3;

Console.WriteLine("==========================================");
Console.WriteLine("        BEM-VINDO AO BAR DO SEU ZÉ        ");
Console.WriteLine("==========================================");
Console.WriteLine();

Console.Write("Qual é o seu nome? ");
string nomeJogador = Console.ReadLine() ?? "";

int palitosJogador = PALITOS_INICIAIS;
int palitosComputador = PALITOS_INICIAIS;

Console.WriteLine();
Console.WriteLine($"Olá, {nomeJogador}! Hoje você vai enfrentar o Computador.");
Console.WriteLine($"Cada jogador começa com {PALITOS_INICIAIS} palitos.");
Console.WriteLine();

// ---------- Rodada ----------
Console.WriteLine();
Console.WriteLine("============== RODADA 1 ==============");
Console.WriteLine($"{nomeJogador}: {palitosJogador} palitos");
Console.WriteLine($"Computador: {palitosComputador} palitos");
Console.WriteLine();

Console.Write($"Quantos palitos você vai esconder na mão (0 a {palitosJogador})? ");
string texto = Console.ReadLine() ?? "";
// TODO 1: converta o texto para número
int escolhaJogador = int.Parse(texto);

// TODO 2: sorteie quantos palitos o Computador esconde: de 0 até palitosComputador
int escolhaComputador = Random.Shared.Next(0, palitosComputador + 1);

// TODO 3: o maior total possível é a soma dos palitos dos dois jogadores
int maximoPalpite = palitosJogador + palitosComputador;

Console.Write($"Seu palpite para o total de palitos (0 a {maximoPalpite}): ");
texto = Console.ReadLine() ?? "";
int palpiteJogador = int.Parse(texto);

// TODO 4: o Computador chuta um número de 0 até maximoPalpite
int palpiteComputador = Random.Shared.Next(0, maximoPalpite + 1);
Console.WriteLine($"O Computador chutou {palpiteComputador}.");

// TODO 5: calcule o total de palitos nas duas mãos
int total = escolhaJogador + escolhaComputador;

Console.WriteLine();
Console.WriteLine("Mãos abertas!");
Console.WriteLine($"{nomeJogador} escondeu {escolhaJogador} e o Computador escondeu {escolhaComputador}.");
Console.WriteLine($"Total na mesa: {total}");