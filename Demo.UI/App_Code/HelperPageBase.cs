using System.Web.Mvc;
using System.Web.WebPages;

// Gabiarra para poder usar os helpers do mvc dentro dos View Helpers
public class HelperPageBase : HelperPage
{
    public new static HtmlHelper Html
    {
        get { return (WebPageContext.Current.Page as WebViewPage).Html; }
    }

    public static UrlHelper Url
    {
        get { return (WebPageContext.Current.Page as WebViewPage).Url; }
    }
}