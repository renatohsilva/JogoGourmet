// Estrutura inicial de dados (pratos e suas características)
using JogoGourmet;
using System.Xml.Linq;

Node root = new Node("massa");
root.YesNode = new Node("lasanha");
root.NoNode = new Node("bolo de chocolate");

// Loop principal do jogo
while (true)
{
    Console.WriteLine("Pense em um prato e eu vou tentar adivinhar!");
    PlayGame(root);

    Console.WriteLine("Deseja jogar novamente? (s/n)");
    string playAgain = Console.ReadLine().ToLower();
    if (playAgain != "s")
        break;
}

static void PlayGame(Node node)
{
    // Pergunta se o prato é uma massa
    if (AskQuestion($"O prato que você pensou é uma {node.Question}?"))
    {
        if (node.YesNode == null)
        {
            Console.WriteLine("Acertei! :)");
        }
        else
        {
            PlayGame(node.YesNode); // Continua o jogo para a próxima pergunta
        }
    }
    else
    {
        if (node.NoNode == null)
        {
            // Se o nó "não" não existe, significa que erramos e temos que aprender
            LearnNewDish(node);
        }
        else
        {
            PlayGame(node.NoNode); // Continua o jogo para a próxima pergunta
        }
    }
}

static void LearnNewDish(Node node)
{
    // Pergunta qual prato o usuário pensou
    Console.WriteLine("Qual prato você pensou?");
    string newDish = Console.ReadLine();

    // Pergunta uma característica que diferencia o novo prato do prato atual
    Console.WriteLine($"O que diferencia {newDish} de {node.Question}? Complete a frase: \"{newDish} é ___ mas {node.Question} não é.\"");
    string newQuestion = Console.ReadLine();

    // Cria novos nós para a árvore
    Node yesNode = new Node(newDish);
    Node noNode = new Node(node.Question);

    // Atualiza o nó atual com a nova pergunta
    node.Question = newQuestion;
    node.YesNode = yesNode;
    node.NoNode = noNode;
}

static bool AskQuestion(string question)
{
    Console.WriteLine(question + " (s/n)");
    string answer = Console.ReadLine().ToLower();
    return answer == "s";
}