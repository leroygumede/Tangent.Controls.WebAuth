using Foundation;
using System;
using Tangent.Controls.IOS.WebViewAuth.Renderers;
using Tangent.Controls.WebViewAuth;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EnhancedWebView), typeof(EnhancedWebViewRenderer))]

namespace Tangent.Controls.IOS.WebViewAuth.Renderers
{
    public partial class WebViewDelegate : WKNavigationDelegate, INSUrlConnectionDataDelegate
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public override void DidReceiveAuthenticationChallenge(WKWebView webView, NSUrlAuthenticationChallenge challenge, Action<NSUrlSessionAuthChallengeDisposition, NSUrlCredential> completionHandler)
        {
            completionHandler(NSUrlSessionAuthChallengeDisposition.UseCredential, new NSUrlCredential(Username, Password, NSUrlCredentialPersistence.ForSession));
            return;
        }
    }

    public class EnhancedWebViewRenderer : ViewRenderer<EnhancedWebView, WKWebView>
    {
        public static void Init()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<EnhancedWebView> e)
        {
            base.OnElementChanged(e);
            var webView = Control as WKWebView;

            if (webView == null)
            {
                var config = new WKWebViewConfiguration();
                webView = new WKWebView(Frame, config);
                SetNativeControl(webView);
            }

            if (e.OldElement != null)
            {
            }
            if (e.NewElement != null)
            {
                UrlWebViewSource source = (Xamarin.Forms.UrlWebViewSource)Element.Source;
                var webRequest = new NSMutableUrlRequest(new NSUrl(source.Url));
                if (Element.CustomHeaders.Count > 0)
                {
                    foreach (string key in Element.CustomHeaders.Keys)
                        webRequest[key] = Element.CustomHeaders[key];
                }
                if (!string.IsNullOrEmpty(Element.Username) && !string.IsNullOrEmpty(Element.Password))
                {
                    WebViewDelegate webViewDelegate = new WebViewDelegate();
                    webViewDelegate.Username = Element.Username;
                    webViewDelegate.Password = Element.Password;
                    webView.NavigationDelegate = webViewDelegate;
                }
                Control.LoadRequest(webRequest);
            }
        }
    }
}