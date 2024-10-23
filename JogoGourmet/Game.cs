using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoGourmet;

public class Game
{
    public Node Node { get; private set; }
    public Game()
    {
        Node = new Node("massa");
        Node.YesNode = new Node("lasanha");
        Node.NoNode = new Node("bolo de chocolate");
    }


}
