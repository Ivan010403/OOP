using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab_7
{
    public class CObserver
    {
        public TreeNode tree = new TreeNode();
        public virtual void onSubjectChanged(CFigure who)
        {
            return;
        }
    }

    public class CObserver_curr:CObserver
    {
        private void processnode(TreeNode n, CFigure who)
        {
            if (who is CGroup)
            {
                TreeNode child = new TreeNode();
                child.Text = who.GetType().ToString();

                n.Nodes.Add(child);

                CFigure[] elements = who.getAllElementsGroup();
                for (int i = 0; i < elements.Length; i++)
                {
                    processnode(child, elements[i]);
                }
            }
            else
            {
                n.Nodes.Add(who.GetType().ToString());
            }
        }

        public override void onSubjectChanged(CFigure who)
        {
            tree = new TreeNode();

            if (who is CGroup)
            {
                processnode(tree, who);

            }
            else
            {
                tree.Nodes.Add(who.GetType().ToString());
            }
        }
    }

    
    public class CStickyObserver: CObserver
    {
        public override void onSubjectChanged(CFigure who)
        {
            who.SetStatusClicking(true);
        }
    }
}
