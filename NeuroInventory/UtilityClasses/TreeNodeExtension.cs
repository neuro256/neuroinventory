using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Метод-расширение класса TreeView. Возвращает потомков указанного узла
        /// </summary>
        /// <param name="tNode"></param>
        /// <returns></returns>
        public static IEnumerable<TreeNode> Descendants(this TreeNodeCollection tNode)
        {
            foreach (var node in tNode.OfType<TreeNode>())
            {
                yield return node;

                foreach (var child in node.Nodes.Descendants())
                {
                    yield return child;
                }
            }
        }
    }
}
