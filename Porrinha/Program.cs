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

ExibirTitulo();

Console.Write("Qual é o seu nome? ");
string nomeJogador = Console.ReadLine() ?? "";
if (nomeJogador == "")
{
    nomeJogador = "Jogador";
}

int opcao;
do
{
    ExibirMenu();
    // TODO 1: leia a opção do menu com LerInteiro (de 1 a 3)
    opcao = LerInteiro("Escolha uma opção: ", 1, 3);

    switch (opcao)
    {
        case 1:
            JogarPartida(nomeJogador);
            break;
        case 2:
            // TODO 2: mostre as regras
            ExibirRegras();
            break;
        case 3:
            Console.WriteLine("Até sexta que vem no Bar do Seu Zé!");
            break;
    }
} while (opcao != 3);

// =====================================================
//  PROCEDIMENTOS
// =====================================================

static void ExibirTitulo()
{
    // TODO 4: mova para cá as quatro linhas que mostram o título do bar
    Console.WriteLine("==========================================");
    Console.WriteLine("        BEM-VINDO AO BAR DO SEU ZÉ        ");
    Console.WriteLine("==========================================");
    Console.WriteLine();
}

static void ExibirMenu()
{
    Console.WriteLine();
    Console.WriteLine("---------------- MENU ----------------");
    Console.WriteLine("1 - Jogar uma partida");
    Console.WriteLine("2 - Ver as regras");
    Console.WriteLine("3 - Sair");
}

static void ExibirRegras()
{
    Console.WriteLine();
    Console.WriteLine("REGRAS DA PORRINHA");
    Console.WriteLine($"- Cada jogador começa com {PALITOS_INICIAIS} palitos.");
    // TODO 5: complete com as outras regras do jogo (veja o README)
    Console.WriteLine("- A cada rodada, cada jogador esconde na mão fechada de 0 até todos os palitos que ainda tem.");
    Console.WriteLine("- Cada jogador dá um palpite do total de palitos nas duas mãos juntas.");
    Console.WriteLine("- O segundo a chutar não pode repetir o palpite do primeiro.");
    Console.WriteLine("- Quem chuta primeiro alterna a cada rodada.");
    Console.WriteLine("- Quem acertar o total descarta um palito.");
    Console.WriteLine("- Vence quem ficar sem palitos primeiro.");
}

static void ExibirPlacar(string[] nomes, int[] palitos)
{
    // TODO 6: mova para cá o desenho dos palitos de cada jogador
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
}

static void ExibirRevelacao(string[] nomes, int[] escolhas, int total)
{
    // TODO 7: mova para cá a revelação: "Mãos abertas!", o for que mostra
    //         quanto cada jogador escondeu, o total e o switch do Seu Zé
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
}

// Passagem por REFERÊNCIA: a alteração vale para a variável original.
static void DescartarPalito(ref int palitosDoJogador)
{
    // TODO 8: tire um palito
    palitosDoJogador--;
}

static void AnunciarVencedor(string[] nomes, int[] palitos, int rodadas)
{
    // TODO 9: mova para cá o anúncio do vencedor, usando o parâmetro rodadas
    //         no lugar de "rodada - 1"
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
    Console.WriteLine($"A partida durou {rodadas} rodadas.");
    Console.WriteLine("==========================================");
}

static void JogarPartida(string nomeJogador)
{
    string[] nomes = { nomeJogador, "Computador" };
    int[] palitos = { PALITOS_INICIAIS, PALITOS_INICIAIS };
    int[] escolhas = new int[2];
    int[] palpites = new int[2];
    int rodada = 1;

    while (palitos[JOGADOR] > 0 && palitos[COMPUTADOR] > 0)
    {
        Console.WriteLine();
        Console.WriteLine($"============== RODADA {rodada} ==============");
        // TODO 10: chame o procedimento que mostra o placar
        ExibirPlacar(nomes, palitos);

        // TODO 11: mova para cá as escolhas e os palpites (do bloco 06)
        escolhas[JOGADOR] = LerInteiro($"Quantos palitos você vai esconder na mão (0 a {palitos[JOGADOR]})? ", 0, palitos[JOGADOR]);
        escolhas[COMPUTADOR] = Random.Shared.Next(0, palitos[COMPUTADOR] + 1);

        int maximoPalpite = Somar(palitos);

        if (rodada % 2 == 1)
        {
            palpites[JOGADOR] = LerInteiro($"Seu palpite para o total (0 a {maximoPalpite}): ", 0, maximoPalpite);
            palpites[COMPUTADOR] = PalpiteComputador(escolhas[COMPUTADOR], palitos[JOGADOR], palpites[JOGADOR]);
            Console.WriteLine($"O {nomes[COMPUTADOR]} chutou {palpites[COMPUTADOR]}.");
        }
        else
        {
            palpites[COMPUTADOR] = PalpiteComputador(escolhas[COMPUTADOR], palitos[JOGADOR], -1);
            Console.WriteLine($"O {nomes[COMPUTADOR]} chuta primeiro: {palpites[COMPUTADOR]}.");

            palpites[JOGADOR] = LerInteiro($"Seu palpite para o total (0 a {maximoPalpite}): ", 0, maximoPalpite);
            while (palpites[JOGADOR] == palpites[COMPUTADOR])
            {
                Console.WriteLine("Esse palpite já foi dado! Escolha outro.");
                palpites[JOGADOR] = LerInteiro($"Seu palpite para o total (0 a {maximoPalpite}): ", 0, maximoPalpite);
            }
        }

        int total = Somar(escolhas);
        // TODO 12: chame o procedimento da revelação
        ExibirRevelacao(nomes, escolhas, total);

        bool alguemAcertou = false;
        for (int j = 0; j < nomes.Length; j++)
        {
            if (palpites[j] == total)
            {
                Console.WriteLine($"{nomes[j]} acertou! Descarta um palito.");
                // TODO 13: use DescartarPalito para tirar um palito do jogador j
                DescartarPalito(ref palitos[j]);
                alguemAcertou = true;
            }
        }
        if (!alguemAcertou)
        {
            Console.WriteLine("Ninguém acertou. Ninguém descarta.");
        }

        rodada++;
    }

    // TODO 14: anuncie o vencedor
    AnunciarVencedor(nomes, palitos, rodada - 1);
}

// =====================================================
//  FUNÇÕES
// =====================================================

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

static int Somar(int[] valores)
{
    int soma = 0;
    for (int i = 0; i < valores.Length; i++)
    {
        soma += valores[i];
    }
    return soma;
}

static int PalpiteComputador(int escolhaPropria, int palitosAdversario, int palpiteProibido)
{
    int palpite;
    do
    {
        palpite = escolhaPropria + Random.Shared.Next(0, palitosAdversario + 1);
    } while (palpite == palpiteProibido);
    return palpite;
}