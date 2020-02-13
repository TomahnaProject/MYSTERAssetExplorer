using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MYSTERAssetExplorer.App
{
    public class BorderlessToolstripRenderer : ToolStripSystemRenderer
    {
        public BorderlessToolstripRenderer() { }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //base.OnRenderToolStripBorder(e);
        }
    }
}
