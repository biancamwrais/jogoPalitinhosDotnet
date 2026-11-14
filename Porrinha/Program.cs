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
if (nomeJogador == "")
{
    nomeJogador = "Jogador";
}

int palitosJogador = PALITOS_INICIAIS;
int palitosComputador = PALITOS_INICIAIS;
// TODO 1: crie o contador de rodadas, começando em 1
int rodada = 1;
bool valido;

Console.WriteLine();
Console.WriteLine($"Olá, {nomeJogador}! Hoje você vai enfrentar o Computador.");
Console.WriteLine($"Cada jogador começa com {PALITOS_INICIAIS} palitos.");

// TODO 2: a partida continua enquanto OS DOIS jogadores ainda tiverem palitos
while (palitosJogador > 0 && palitosComputador > 0)
{
    Console.WriteLine();
    Console.WriteLine($"============== RODADA {rodada} ==============");

    // Desenha um "|" para cada palito do jogador
    Console.Write($"{nomeJogador}: ");
    for (int i = 0; i < palitosJogador; i++)
    {
        Console.Write("| ");
    }
    Console.WriteLine();

    // TODO 3: faça o mesmo desenho para os palitos do Computador
    Console.Write("Computador: ");
    for (int i = 0; i < palitosComputador; i++)
    {
        Console.Write("| ");
    }
    Console.WriteLine();
    Console.WriteLine();

    // ---------- Escolha do jogador (com validação) ----------
    int escolhaJogador;
    do
    {
        Console.Write($"Quantos palitos você vai esconder na mão (0 a {palitosJogador})? ");
        valido = int.TryParse(Console.ReadLine(), out escolhaJogador)
                 && escolhaJogador >= 0 && escolhaJogador <= palitosJogador;
        if (!valido)
        {
            Console.WriteLine($"Valor inválido! Digite um número de 0 a {palitosJogador}.");
        }
    } while (!valido);

    int escolhaComputador = Random.Shared.Next(0, palitosComputador + 1);

    int maximoPalpite = palitosJogador + palitosComputador;
    int palpiteJogador;
    int palpiteComputador;

    // ---------- Palpites: quem começa alterna a cada rodada ----------
    // TODO 4: o jogador chuta primeiro nas rodadas ímpares
    if (rodada % 2 == 1)
    {
        // TODO 5: leia o palpite do jogador com validação, como foi feito
        //         com a escolha lá em cima (o palpite vai de 0 a maximoPalpite)
        do
        {
            Console.Write($"Seu palpite para o total (0 a {maximoPalpite}): ");
            valido = int.TryParse(Console.ReadLine(), out palpiteJogador)
                     && palpiteJogador >= 0 && palpiteJogador <= maximoPalpite;
            if (!valido)
            {
                Console.WriteLine($"Palpite inválido! Digite um número de 0 a {maximoPalpite}.");
            }
        } while (!valido);

        // O Computador sorteia de novo enquanto o palpite dele for igual ao do jogador
        do
        {
            palpiteComputador = Random.Shared.Next(0, maximoPalpite + 1);
        } while (palpiteComputador == palpiteJogador);

        Console.WriteLine($"O Computador chutou {palpiteComputador}.");
    }
    else
    {
        palpiteComputador = Random.Shared.Next(0, maximoPalpite + 1);
        Console.WriteLine($"O Computador chuta primeiro: {palpiteComputador}.");

        do
        {
            Console.Write($"Seu palpite para o total (0 a {maximoPalpite}): ");
            valido = int.TryParse(Console.ReadLine(), out palpiteJogador)
                     && palpiteJogador >= 0 && palpiteJogador <= maximoPalpite;
            if (!valido)
            {
                Console.WriteLine($"Palpite inválido! Digite um número de 0 a {maximoPalpite}.");
            }
            else if (palpiteJogador == palpiteComputador)
            {
                Console.WriteLine("Esse palpite já foi dado! Escolha outro.");
                valido = false;
            }
        } while (!valido);
    }

    int total = escolhaJogador + escolhaComputador;

    Console.WriteLine();
    Console.WriteLine("Mãos abertas!");
    Console.WriteLine($"{nomeJogador} escondeu {escolhaJogador} e o Computador escondeu {escolhaComputador}.");
    Console.WriteLine($"Total na mesa: {total}");

    // Cole aqui o seu switch com os comentários do Seu Zé (do bloco 03)
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
        palitosJogador--;
    }
    else if (palpiteComputador == total)
    {
        Console.WriteLine("O Computador acertou! Descarta um palito.");
        palitosComputador--;
    }
    else
    {
        Console.WriteLine("Ninguém acertou. Ninguém descarta.");
    }

    // TODO 8: passe para a próxima rodada
    rodada++;
}

// ---------- Fim da partida ----------
Console.WriteLine();
Console.WriteLine("==========================================");
// TODO 9: se o jogador ficou sem palitos, ele venceu; senão, o Computador venceu
if (palitosJogador == 0)
{
    Console.WriteLine($"PARABÉNS, {nomeJogador}! Você venceu a porrinha!");
}
else
{
    Console.WriteLine("O Computador venceu desta vez. Bora treinar mais!");
}
Console.WriteLine($"A partida durou {rodada - 1} rodadas.");
Console.WriteLine("==========================================");