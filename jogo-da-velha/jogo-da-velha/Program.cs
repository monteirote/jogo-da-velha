class Program
{
    public static void Main(String[] args)
    {
        String[] linha1 = { " ", " ", " " };
        String[] linha2 = { " ", " ", " " };
        String[] linha3 = { " ", " ", " " };

        String jogador1, jogador2, vencedor = "";

        Console.WriteLine("Qual o nome do jogador 1? (X)");
        jogador1 = Console.ReadLine();

        Console.WriteLine("Qual o nome do jogador 2? (O)");
        jogador2 = Console.ReadLine();

        int coluna = 0, linha = 0;

        bool continuarJogo = true;

        do
        {
            imprimirTabuleiro(linha1, linha2, linha3);

            solicitarEMarcarJogada("X", jogador1, ref coluna, ref linha, ref linha1, ref linha2, ref linha3);

            imprimirTabuleiro(linha1, linha2, linha3);

            checarSeJogoAcabou(ref continuarJogo, linha1, linha2, linha3, ref vencedor);


            if (continuarJogo)
            {
                solicitarEMarcarJogada("O", jogador2, ref coluna, ref linha, ref linha1, ref linha2, ref linha3);

                checarSeJogoAcabou(ref continuarJogo, linha1, linha2, linha3, ref vencedor);
            }

        } while (continuarJogo);

        if (vencedor == "X")
        {
            Console.WriteLine("O jogador {0} venceu o jogo!", jogador1);
        }
        else if (vencedor == "O")
        {
            Console.WriteLine("O jogador {0} venceu o jogo!", jogador2);
        }
        else if (vencedor == "empate")
        {
            Console.WriteLine("O jogo acabou em empate");
        }

    }

    static void imprimirLinha(String[] vetorLinha)
    {
        Console.WriteLine("     {0} | {1} | {2}", vetorLinha[0], vetorLinha[1], vetorLinha[2]);
    }

    static void imprimirTabuleiro(String[] linha1, String[] linha2, String[] linha3)
    {
        imprimirLinha(linha1);
        Console.WriteLine("     --|---|--");
        imprimirLinha(linha2);
        Console.WriteLine("     --|---|--");
        imprimirLinha(linha3);
    }

    static void solicitarEMarcarJogada(String simbolo, String jogador, ref int coluna, ref int linha, ref String[] linha1, ref String[] linha2, ref String[] linha3)
    {
        bool posicoesInvalidas;
        do
        {
            posicoesInvalidas = false;
            Console.WriteLine("Jogador {0}, qual coluna você deseja marcar?", jogador);
            coluna = int.Parse(Console.ReadLine());
            Console.WriteLine("E qual linha?");
            linha = int.Parse(Console.ReadLine());


            if (coluna < 1 || coluna > 3 || linha < 1 || linha > 3)
            {
                posicoesInvalidas = true;
                Console.WriteLine("Posições inválidas, por favor digite novamente.");
            }
            else if ((linha == 1 && linha1[coluna - 1] != " ") || (linha == 2 && linha2[coluna - 1] != " ") || (linha == 3 && linha3[coluna - 1] != " "))
            {
                posicoesInvalidas = true;
                Console.WriteLine("Essa posição já foi marcada anteriormente, escolha outra.");
            }
            else 
            {
                marcarPosicao(simbolo, linha, coluna, ref linha1, ref linha2, ref linha3);
            }


        } while (posicoesInvalidas);
    }

    static void marcarPosicao(String simbolo, int linha, int coluna, ref String[] linha1, ref String[] linha2, ref String[] linha3)
    {

        if (linha == 1)
        {
            linha1[coluna - 1] = simbolo;
        }
        else if (linha == 2)
        {
            linha2[coluna - 1] = simbolo;
        }
        else if (linha == 3)
        {
            linha3[coluna - 1] = simbolo;
        }
    }

    static void checarSeJogoAcabou(ref bool continuarJogo, String[] linha1, String[] linha2, String[] linha3, ref String vencedor)
    {


        for (int i = 0; i < 3; i++)
        {
            if (linha1[i] != " ")
            {
                if (linha1[i] == linha2[i] && linha2[i] == linha3[i])
                {
                    continuarJogo = false;
                    vencedor = linha1[i];
                    return;
                }
            }

        }

        if (checarColuna(linha1, ref vencedor) || checarColuna(linha2, ref vencedor) || checarColuna(linha3, ref vencedor))
        {
            continuarJogo = false;
            return;
        }

        if (linha1[0] != " " && (linha1[0] == linha2[1] && linha2[1] == linha3[2]))
        {
            continuarJogo = false;
            vencedor = linha1[0];
            return;
        }

        if (linha1[2] != " " && (linha1[2] == linha2[1] && linha2[1] == linha3[0]))
        {
            continuarJogo = false;
            vencedor = linha1[2];
            return;
        }

        if (checarLinhaCheia(linha1) && checarLinhaCheia(linha2) && checarLinhaCheia(linha3))
        {
            continuarJogo = false;
            vencedor = "empate";
            return;
        }
    }


    static bool checarColuna(String[] vetor, ref String vencedor)
    {
        if (vetor[0] == " ")
        {
            return false;
        }

        if (vetor[0] == vetor[1] && vetor[2] == vetor[1])
        {
            vencedor = vetor[0];
            return true;
        }
        else
        {
            return false;
        }
    }

    static bool checarLinhaCheia(String[] linha)
    {
        for (int i = 0; i < linha.Length; i++)
        {
            if (linha[i] == " ")
            {
                return false;
            }
        }
        return true;
    }
}