namespace GameGourmetCore;

public class Node(string question)
{
    public string Question { get; set; } = question;
    public Node YesNode { get; set; }
    public Node NoNode { get; set; }
}
