using Android.Webkit;
using System.Collections.Generic;
using web = global::Android;

namespace Tangent.Controls.Android.WebViewAuth
{
    public class EnhancedWebViewClient : web.Webkit.WebViewClient
    {
        public Dictionary<string, string> Headers { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public EnhancedWebViewClient()
        {
        }

        public override void OnReceivedHttpAuthRequest(WebView view, HttpAuthHandler handler, string host, string realm)
        {
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
                handler.Proceed(Username, Password);
            else base.OnReceivedHttpAuthRequest(view, handler, host, realm);
        }

        public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
        {
            return base.ShouldOverrideUrlLoading(view, request);
        }

        public override void OnPageStarted(web.Webkit.WebView view, string url, web.Graphics.Bitmap favicon)
        {
            base.OnPageStarted(view, url, favicon);
            System.Diagnostics.Debug.WriteLine("Loading website...");
        }

        public override void OnPageFinished(web.Webkit.WebView view, string url)
        {
            base.OnPageFinished(view, url);
            System.Diagnostics.Debug.WriteLine("Load finished.");
        }

        public override void OnReceivedError(web.Webkit.WebView view, IWebResourceRequest request, WebResourceError error)
        {
            base.OnReceivedError(view, request, error);
        }
    }
}