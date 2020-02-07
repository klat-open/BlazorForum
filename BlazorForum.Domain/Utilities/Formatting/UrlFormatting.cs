using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BlazorForum.Domain.Utilities.Formatting
{
    public class UrlFormatting
    {
        private readonly IHttpContextAccessor _accessor;

        public UrlFormatting(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        private static Regex purifyUrlRegex = new Regex("[^-a-zA-Z0-9_ ]", RegexOptions.Compiled);
        private static Regex dashesRegex = new Regex("[-_ ]+", RegexOptions.Compiled);

        public static string PrepareUrlText(string urlText)
        {
            urlText = purifyUrlRegex.Replace(urlText, "");
            urlText = urlText.Trim();
            urlText = dashesRegex.Replace(urlText, "-");  
            return urlText;
        }

        // 301 redirects to correct url if not already there
        // May delete this. Was used in a non-blazor project
        public void CheckRewrittenUrl(int id, string properUrl)
        {
            // get requested URL
            HttpContext context = _accessor.HttpContext;
            string requestedUrl = context.Features.Get<IHttpRequestFeature>().RawTarget;

            // Make sure requested string isn't more than 50 characters longer than the proper string.
            // If so, just reset it to 1 character larger than the proper, so it will redirect.
            // This became an issue when facebook linked to the post and added a long querystring to it
            if (requestedUrl.Length - properUrl.Length > 50)
                requestedUrl = requestedUrl.Substring(0, properUrl.Length + 1);

            // get last part of proper URL
            string properUrlTrunc = properUrl.Substring(Math.Abs(properUrl.Length - requestedUrl.Length));

            // 301 redirect to the proper URL if necessary
            if (requestedUrl != properUrl)
            {
                context.Response.StatusCode = 301;
                context.Response.Headers.Add("Location", properUrl);
            }
        }
    }
}
