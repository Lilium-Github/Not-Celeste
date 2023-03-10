using System.Collections.Generic;

namespace Not_Celeste;

internal abstract class Node
{
    private string _name = "";
    private List<Node> _children = new();
    private Node _parent = null;

}
