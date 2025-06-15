using Microsoft.AspNetCore.Mvc;
using SCHESS.Controllers.Frontend;

namespace SCHESS.Extensions
{
    public static class UrlExtension
    {
        public static string EmailConfirmationLink(this IUrlHelper urlHelper, Guid userId, string code, string scheme)
        {
            if (urlHelper == null || userId == Guid.Empty
                || string.IsNullOrEmpty(code)
                || string.IsNullOrEmpty(scheme)) return string.Empty;

            return urlHelper.Action(
                action: nameof(AppUsersController.ConfirmEmail),
                controller: "AppUsers",
                values: new { userId, code },
                protocol: scheme);
        }
    }
}
