using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INFINITTechTest.Data;

namespace INFINITTechTest.Repositories
{
    public static class TreeBuilderHelper
    {
        
        public static TreeNodeCollection BuildTreeFromNodes(IList<RepoTreeNode> nodes)
        {
            TreeNode root = new TreeNode();

            if (nodes == null || nodes.Count == 0)
            {
                return root.Nodes;
            }

            foreach (RepoTreeNode node in nodes)
            {
                TreeNode newNode = new TreeNode();
                newNode.Name = node.Path;
                newNode.Text = node.Path;
                newNode.Tag = node;
                if (node.Type == "tree")
                {
                    foreach (TreeNode childNodes in BuildTreeFromNodes(node.SubFiles))
                    {
                        newNode.Nodes.Add(childNodes);
                    }
                }
                root.Nodes.Add(newNode);
            }
            return root.Nodes;
        }
    }
}
