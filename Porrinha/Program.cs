// =====================================================
//  PORRINHA – Bar do Seu Zé
//  Comece pelo arquivo blocos/01-variaveis.md
// =====================================================

Console.WriteLine("O Bar do Seu Zé está em construção...");
// =====================================================
//  PORRINHA – Bar do Seu Zé
// =====================================================

const int PALITOS_INICIAIS = 3;
const int JOGADOR = 0;
const int COMPUTADOR = 1;

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

// TODO 1: o vetor de nomes tem o nome lido e o texto "Computador"
string[] nomes = { nomeJogador, "Computador" };
// TODO 2: os dois jogadores começam com PALITOS_INICIAIS
int[] palitos = { PALITOS_INICIAIS, PALITOS_INICIAIS };
int[] escolhas = new int[2];
int[] palpites = new int[2];

int rodada = 1;
bool valido;

Console.WriteLine();
Console.WriteLine($"Olá, {nomes[JOGADOR]}! Hoje você vai enfrentar o {nomes[COMPUTADOR]}.");
Console.WriteLine($"Cada jogador começa com {PALITOS_INICIAIS} palitos.");

// TODO 3: reescreva a condição do while usando o vetor palitos
while (palitos[JOGADOR] > 0 && palitos[COMPUTADOR] > 0)
{
    Console.WriteLine();
    Console.WriteLine($"============== RODADA {rodada} ==============");

    for (int j = 0; j < nomes.Length; j++)
    {
        Console.Write($"{nomes[j]}: ");
        // TODO 4: desenhe um "| " para cada palito do jogador j
        for (int i = 0; i < palitos[j]; i++)
        {
            Console.Write("| ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();

    // ---------- Escolha do jogador (com validação) ----------
    do
    {
        Console.Write($"Quantos palitos você vai esconder na mão (0 a {palitos[JOGADOR]})? ");
        valido = int.TryParse(Console.ReadLine(), out escolhas[JOGADOR])
                 && escolhas[JOGADOR] >= 0 && escolhas[JOGADOR] <= palitos[JOGADOR];
        if (!valido)
        {
            Console.WriteLine($"Valor inválido! Digite um número de 0 a {palitos[JOGADOR]}.");
        }
    } while (!valido);

    escolhas[COMPUTADOR] = Random.Shared.Next(0, palitos[COMPUTADOR] + 1);

    // TODO 5: some todas as posições do vetor palitos em maximoPalpite
    int maximoPalpite = 0;
    for (int j = 0; j < palitos.Length; j++)
    {
        maximoPalpite += palitos[j];
    }

    // ---------- Palpites: quem começa alterna a cada rodada ----------
    if (rodada % 2 == 1)
    {
        do
        {
            Console.Write($"Seu palpite para o total (0 a {maximoPalpite}): ");
            valido = int.TryParse(Console.ReadLine(), out palpites[JOGADOR])
                     && palpites[JOGADOR] >= 0 && palpites[JOGADOR] <= maximoPalpite;
            if (!valido)
            {
                Console.WriteLine($"Palpite inválido! Digite um número de 0 a {maximoPalpite}.");
            }
        } while (!valido);

        // O Computador sorteia de novo enquanto o palpite dele for igual ao do jogador
        do
        {
            palpites[COMPUTADOR] = Random.Shared.Next(0, maximoPalpite + 1);
        } while (palpites[COMPUTADOR] == palpites[JOGADOR]);

        Console.WriteLine($"O {nomes[COMPUTADOR]} chutou {palpites[COMPUTADOR]}.");
    }
    else
    {
        palpites[COMPUTADOR] = Random.Shared.Next(0, maximoPalpite + 1);
        Console.WriteLine($"O {nomes[COMPUTADOR]} chuta primeiro: {palpites[COMPUTADOR]}.");

        do
        {
            Console.Write($"Seu palpite para o total (0 a {maximoPalpite}): ");
            valido = int.TryParse(Console.ReadLine(), out palpites[JOGADOR])
                     && palpites[JOGADOR] >= 0 && palpites[JOGADOR] <= maximoPalpite;
            if (!valido)
            {
                Console.WriteLine($"Palpite inválido! Digite um número de 0 a {maximoPalpite}.");
            }
            else if (palpites[JOGADOR] == palpites[COMPUTADOR])
            {
                Console.WriteLine("Esse palpite já foi dado! Escolha outro.");
                valido = false;
            }
        } while (!valido);
    }

    // TODO 6: some todas as escolhas em total, como foi feito com o maximoPalpite
    int total = 0;
    for (int j = 0; j < escolhas.Length; j++)
    {
        total += escolhas[j];
    }

    Console.WriteLine();
    Console.WriteLine("Mãos abertas!");
    for (int j = 0; j < nomes.Length; j++)
    {
        // TODO 7: mostre "Ana escondeu 2." para cada jogador
        Console.WriteLine($"{nomes[j]} escondeu {escolhas[j]}.");
    }
    Console.WriteLine($"Total na mesa: {total}");

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

    bool alguemAcertou = false;
    for (int j = 0; j < nomes.Length; j++)
    {
        // TODO 8: o jogador j acertou?
        if (palpites[j] == total)
        {
            Console.WriteLine($"{nomes[j]} acertou! Descarta um palito.");
            // TODO 9: tire um palito do jogador j
            palitos[j]--;
            alguemAcertou = true;
        }
    }
    // TODO 10: se ninguém acertou, mostre "Ninguém acertou. Ninguém descarta."
    if (!alguemAcertou)
    {
        Console.WriteLine("Ninguém acertou. Ninguém descarta.");
    }

    rodada++;
}

// ---------- Fim da partida ----------
Console.WriteLine();
Console.WriteLine("==========================================");
if (palitos[JOGADOR] == 0)
{
    Console.WriteLine($"PARABÉNS, {nomes[JOGADOR]}! Você venceu a porrinha!");
}
else
{
    Console.WriteLine($"O {nomes[COMPUTADOR]} venceu desta vez. Bora treinar mais!");
}
Console.WriteLine($"A partida durou {rodada - 1} rodadas.");
Console.WriteLine("==========================================");