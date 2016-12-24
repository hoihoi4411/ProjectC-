using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ProjectCsharp.Animation
{
    public delegate void ChangeOpacityDelegate(double value);
    public class Animation
    {
        public static void FadeIn(Form objectForm)
        {
            while(objectForm.Opacity < 1)
            {
                objectForm.Opacity += 0.1;
                Thread.Sleep(50);
            }
        }
    }
}
