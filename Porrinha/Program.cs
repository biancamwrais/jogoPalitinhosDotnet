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

// TODO 1: se o nome estiver vazio, use "Jogador" como nome
if (nomeJogador == "")
{
    nomeJogador = "Jogador";
}

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
int escolhaJogador = int.Parse(texto);

// TODO 2: a escolha é inválida se for menor que 0 OU maior que os palitos do jogador
if (escolhaJogador < 0 || escolhaJogador > palitosJogador)
{
    Console.WriteLine("Valor inválido! Vou considerar que você escondeu 0.");
    escolhaJogador = 0;
}

int escolhaComputador = Random.Shared.Next(0, palitosComputador + 1);
int maximoPalpite = palitosJogador + palitosComputador;

Console.Write($"Seu palpite para o total de palitos (0 a {maximoPalpite}): ");
texto = Console.ReadLine() ?? "";
int palpiteJogador = int.Parse(texto);

// TODO 3: o palpite é inválido se for menor que 0 OU maior que maximoPalpite
if (palpiteJogador < 0 || palpiteJogador > maximoPalpite)
{
    Console.WriteLine("Palpite inválido! Vou considerar que você chutou 0.");
    palpiteJogador = 0;
}

int palpiteComputador = Random.Shared.Next(0, maximoPalpite + 1);
Console.WriteLine($"O Computador chutou {palpiteComputador}.");

int total = escolhaJogador + escolhaComputador;

Console.WriteLine();
Console.WriteLine("Mãos abertas!");
Console.WriteLine($"{nomeJogador} escondeu {escolhaJogador} e o Computador escondeu {escolhaComputador}.");
Console.WriteLine($"Total na mesa: {total}");

// TODO 4: complete o switch com um comentário para cada caso
switch (total)
{
    case 0:
        Console.WriteLine("Seu Zé: \"Mão vazia geral! Ninguém arriscou nada.\"");
        break;
    case 1:
        Console.WriteLine("Seu Zé: \"Um palitinho só, jogo tímido!\"");
        break;
    default:
        Console.WriteLine("Seu Zé: \"Olha a mesa cheia de palito!\"");
        break;
}

if (palpiteJogador == total)
{
    Console.WriteLine($"{nomeJogador} acertou! Descarta um palito.");
    // TODO 5: tire um palito do jogador
    palitosJogador = palitosJogador - 1;
}
else if (palpiteComputador == total)
{
    Console.WriteLine("O Computador acertou! Descarta um palito.");
    // TODO 7: tire um palito do Computador
    palitosComputador = palitosComputador - 1;
}
else
{
    Console.WriteLine("Ninguém acertou. Ninguém descarta.");
}

Console.WriteLine();
// TODO 8: mostre o placar no formato "Placar: Ana 2 x 3 Computador"
Console.WriteLine($"Placar: {nomeJogador} {palitosJogador} x {palitosComputador} Computador");