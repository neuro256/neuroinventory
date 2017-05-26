using System.Collections.Generic;
using System.Windows.Forms;

namespace NeuroInventory
{
    public static class TreeNodeExtension
    {
        public static List<TreeNode> GetAllNodes(this TreeNode p_Self)
        {
            List<TreeNode> nodesList = new List<TreeNode>();
            nodesList.Add(p_Self);
            foreach (TreeNode child in p_Self.Nodes)
            {
                nodesList.AddRange(child.GetAllNodes());
            }
            return nodesList;
        }
    }
}
