using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGourmetCore;

/// <summary>
/// Represents the logic of the dish guessing game.
/// Manages the question tree and the game states.
/// </summary>
public class Game
{
    /// <summary>
    /// The current node of the question tree where the game is currently at.
    /// </summary>
    public Node CurrentNode { get; private set; }

    private readonly Node root; // The root node of the question tree

    /// <summary>
    /// Initializes a new instance of the <see cref="Game"/> class.
    /// Creates the initial tree with a question and two dish options.
    /// </summary>
    public Game()
    {
        root = new Node("pasta")
        {
            YesNode = new Node("lasagna"),
            NoNode = new Node("chocolate cake")
        };
        CurrentNode = root;
    }

    /// <summary>
    /// Moves the current node to the child node corresponding to the affirmative answer.
    /// </summary>
    public void MoveToYesNode()
    {
        CurrentNode = CurrentNode.YesNode;
    }

    /// <summary>
    /// Moves the current node to the child node corresponding to the negative answer.
    /// </summary>
    public void MoveToNoNode()
    {
        CurrentNode = CurrentNode.NoNode;
    }

    /// <summary>
    /// Checks if a given node is a terminal (or leaf) node.
    /// A terminal node has no children.
    /// </summary>
    /// <param name="node">The node to check.</param>
    /// <returns>True if the node is terminal; otherwise, false.</returns>
    public static bool IsTerminalNode(Node node)
    {
        return node.YesNode == null && node.NoNode == null;
    }

    /// <summary>
    /// Updates the question tree with a new dish and a new question.
    /// The current node will be updated to reflect the new information.
    /// </summary>
    /// <param name="node">The current node to be updated.</param>
    /// <param name="newDish">The new dish to be added.</param>
    /// <param name="newQuestion">The new question that differentiates the new dish from the current one.</param>
    public static void UpdateGameTree(Node node, string newDish, string newQuestion)
    {
        var yesNode = new Node(newDish);
        var noNode = new Node(node.Question);

        node.Question = newQuestion;
        node.YesNode = yesNode;
        node.NoNode = noNode;
    }

    /// <summary>
    /// Resets the game, setting the current node back to the root of the tree.
    /// </summary>
    public void Reset()
    {
        CurrentNode = root;
    }
}
