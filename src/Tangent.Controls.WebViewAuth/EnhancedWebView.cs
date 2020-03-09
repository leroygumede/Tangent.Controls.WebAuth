using System.Collections.Generic;
using Xamarin.Forms;

namespace Tangent.Controls.WebViewAuth
{
    public class EnhancedWebView : WebView
    {
        public static readonly BindableProperty CustomHeadersProperty = BindableProperty.Create(
             propertyName: nameof(CustomHeaders),
             returnType: typeof(Dictionary<string, string>),
             declaringType: typeof(EnhancedWebView),
             defaultValue: default(Dictionary<string, string>)
         );

        public Dictionary<string, string> CustomHeaders
        {
            get => (Dictionary<string, string>)GetValue(CustomHeadersProperty);
            set => SetValue(CustomHeadersProperty, value);
        }

        public static readonly BindableProperty UsernameProperty = BindableProperty.Create(
           propertyName: nameof(Username),
           returnType: typeof(string),
           declaringType: typeof(EnhancedWebView),
           defaultValue: default(string)
       );

        public string Username
        {
            get => (string)GetValue(UsernameProperty);
            set => SetValue(UsernameProperty, value);
        }

        public static readonly BindableProperty PasswordProperty = BindableProperty.Create(
         propertyName: nameof(Password),
         returnType: typeof(string),
         declaringType: typeof(EnhancedWebView),
         defaultValue: default(string)
        );

        public string Password
        {
            get => (string)GetValue(PasswordProperty);
            set => SetValue(PasswordProperty, value);
        }
    }
}