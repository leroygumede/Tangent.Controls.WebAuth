using System;
using System.Drawing;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Tangent.Controls.IOS.WebViewAuth
{
    public class RendererInitializar
    {
        public static void Init()
        {
            Renderers.EnhancedWebViewRenderer.Init();
        }
    }
}