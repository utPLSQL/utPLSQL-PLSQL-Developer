using System.Collections;

namespace ColorProgressBar
{
    internal class ColorProgressBarDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        /// <summary>Clean up some unnecessary properties</summary> 
        protected override void PostFilterProperties(IDictionary Properties)
        {
            Properties.Remove("AllowDrop");
            Properties.Remove("BackgroundImage");
            Properties.Remove("ContextMenu");
            Properties.Remove("FlatStyle");
            Properties.Remove("Image");
            Properties.Remove("ImageAlign");
            Properties.Remove("ImageIndex");
            Properties.Remove("ImageList");
            Properties.Remove("Text");
            Properties.Remove("TextAlign");
        }
    }
}