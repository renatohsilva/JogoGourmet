using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoGourmetCore;

/// <summary>
/// Representa a lógica do jogo de adivinhação de pratos.
/// Gerencia a árvore de perguntas e os estados do jogo.
/// </summary>
public class Game
{
    /// <summary>
    /// O nó atual da árvore de perguntas em que o jogo se encontra.
    /// </summary>
    public Node CurrentNode { get; private set; }

    private readonly Node root;// O nó raiz da árvore de perguntas

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Game"/>.
    /// Cria a árvore inicial com uma pergunta e duas opções de pratos.
    /// </summary>
    public Game()
    {
        root = new Node("massa")
        {
            YesNode = new Node("lasanha"),
            NoNode = new Node("bolo de chocolate")
        };
        CurrentNode = root;
    }

    /// <summary>
    /// Move o nó atual para o nó filho correspondente à resposta afirmativa.
    /// </summary>
    public void MoveToYesNode()
    {
        CurrentNode = CurrentNode.YesNode;
    }

    /// <summary>
    /// Move o nó atual para o nó filho correspondente à resposta negativa.
    /// </summary>
    public void MoveToNoNode()
    {
        CurrentNode = CurrentNode.NoNode;
    }

    /// <summary>
    /// Verifica se um determinado nó é um nó terminal (ou folha).
    /// Um nó terminal não possui filhos.
    /// </summary>
    /// <param name="node">O nó a ser verificado.</param>
    /// <returns>Verdadeiro se o nó for terminal, caso contrário, falso.</returns>
    public static bool IsTerminalNode(Node node)
    {
        return node.YesNode == null && node.NoNode == null;
    }

    /// <summary>
    /// Atualiza a árvore de perguntas com um novo prato e uma nova pergunta.
    /// O nó atual será atualizado para refletir a nova informação.
    /// </summary>
    /// <param name="node">O nó atual a ser atualizado.</param>
    /// <param name="newDish">O novo prato a ser adicionado.</param>
    /// <param name="newQuestion">A nova pergunta que diferencia o novo prato do atual.</param>
    public static void UpdateGameTree(Node node, string newDish, string newQuestion)
    {
        var yesNode = new Node(newDish);
        var noNode = new Node(node.Question);

        node.Question = newQuestion;
        node.YesNode = yesNode;
        node.NoNode = noNode;
    }

    /// <summary>
    /// Reinicia o jogo, definindo o nó atual de volta para a raiz da árvore.
    /// </summary>
    public void Reset()
    {
        CurrentNode = root;
    }
}
