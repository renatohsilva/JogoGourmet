using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoGourmet;

public class Node
{
    public string Question { get; set; }
    public Node YesNode { get; set; }
    public Node NoNode { get; set; }

    public Node(string question)
    {
        Question = question;
    }
}
