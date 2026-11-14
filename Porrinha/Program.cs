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

string[] nomes = { nomeJogador, "Computador" };
int[] palitos = { PALITOS_INICIAIS, PALITOS_INICIAIS };
int[] escolhas = new int[2];
int[] palpites = new int[2];

int rodada = 1;

Console.WriteLine();
Console.WriteLine($"Olá, {nomes[JOGADOR]}! Hoje você vai enfrentar o {nomes[COMPUTADOR]}.");
Console.WriteLine($"Cada jogador começa com {PALITOS_INICIAIS} palitos.");

while (palitos[JOGADOR] > 0 && palitos[COMPUTADOR] > 0)
{
    Console.WriteLine();
    Console.WriteLine($"============== RODADA {rodada} ==============");

    for (int j = 0; j < nomes.Length; j++)
    {
        Console.Write($"{nomes[j]}: ");
        for (int i = 0; i < palitos[j]; i++)
        {
            Console.Write("| ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();

    // ---------- Escolha do jogador (com validação) ----------
    escolhas[JOGADOR] = LerInteiro($"Quantos palitos você vai esconder na mão (0 a {palitos[JOGADOR]})? ", 0, palitos[JOGADOR]);

    escolhas[COMPUTADOR] = Random.Shared.Next(0, palitos[COMPUTADOR] + 1);

    // TODO 6: use a função Somar com o vetor palitos
    int maximoPalpite = Somar(palitos);

    // ---------- Palpites: quem começa alterna a cada rodada ----------
    if (rodada % 2 == 1)
    {
        // TODO 7: leia o palpite do jogador com LerInteiro (de 0 a maximoPalpite)
        palpites[JOGADOR] = LerInteiro($"Seu palpite para o total (0 a {maximoPalpite}): ", 0, maximoPalpite);
        palpites[COMPUTADOR] = PalpiteComputador(escolhas[COMPUTADOR], palitos[JOGADOR], palpites[JOGADOR]);
        Console.WriteLine($"O {nomes[COMPUTADOR]} chutou {palpites[COMPUTADOR]}.");
    }
    else
    {
        // TODO 8: o Computador chuta primeiro, então não há palpite proibido
        palpites[COMPUTADOR] = PalpiteComputador(escolhas[COMPUTADOR], palitos[JOGADOR], -1);
        Console.WriteLine($"O {nomes[COMPUTADOR]} chuta primeiro: {palpites[COMPUTADOR]}.");

        palpites[JOGADOR] = LerInteiro($"Seu palpite para o total (0 a {maximoPalpite}): ", 0, maximoPalpite);
        while (palpites[JOGADOR] == palpites[COMPUTADOR])
        {
            Console.WriteLine("Esse palpite já foi dado! Escolha outro.");
            palpites[JOGADOR] = LerInteiro($"Seu palpite para o total (0 a {maximoPalpite}): ", 0, maximoPalpite);
        }
    }

    // TODO 9: use a função Somar com o vetor escolhas
    int total = Somar(escolhas);

    Console.WriteLine();
    Console.WriteLine("Mãos abertas!");
    for (int j = 0; j < nomes.Length; j++)
    {
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
        if (palpites[j] == total)
        {
            Console.WriteLine($"{nomes[j]} acertou! Descarta um palito.");
            palitos[j]--;
            alguemAcertou = true;
        }
    }
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

// =====================================================
//  FUNÇÕES
// =====================================================

// Lê um número inteiro do teclado e só devolve quando ele
// for válido e estiver entre minimo e maximo.
static int LerInteiro(string mensagem, int minimo, int maximo)
{
    int valor;
    bool valido;
    do
    {
        Console.Write(mensagem);
        valido = int.TryParse(Console.ReadLine(), out valor)
                 && valor >= minimo && valor <= maximo;
        if (!valido)
        {
            Console.WriteLine($"Valor inválido! Digite um número de {minimo} a {maximo}.");
        }
    } while (!valido);
    return valor;
}

// Soma todos os valores de um vetor de inteiros.
static int Somar(int[] valores)
{
    int soma = 0;
    for (int i = 0; i < valores.Length; i++)
    {
        soma += valores[i];
    }
    return soma;
}

// O palpite "à moda do Seu Zé": o Computador sabe quantos palitos
// escondeu e só chuta quantos o adversário pode ter na mão.
// Nunca repete o palpiteProibido (use -1 quando não houver).
static int PalpiteComputador(int escolhaPropria, int palitosAdversario, int palpiteProibido)
{
    int palpite;
    do
    {
        palpite = escolhaPropria + Random.Shared.Next(0, palitosAdversario + 1);
    } while (palpite == palpiteProibido);
    return palpite;
}