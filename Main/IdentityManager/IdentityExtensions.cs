using System.Security.Claims;
using System.Security.Principal;

namespace Main.web.IdentityManager
{
	public static class IdentityExtensions
	{
		public static int GetUserId(this ClaimsPrincipal? claimsPrincipal)
		{
			if (claimsPrincipal == null)
				return 0;

			if (claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier) == null)
				return 0;

			string? userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (string.IsNullOrEmpty(userId))
				return 0;
			else
				return Convert.ToInt32(userId);
		}

		public static int GetUserId(this IPrincipal? principal)
		{
			if (principal == null)
				return 0;

			var user = (ClaimsPrincipal)principal;

			return user.GetUserId();
		}

		public static string GetEmail(this ClaimsPrincipal claimsPrincipal)
		=> claimsPrincipal.FindFirst(ClaimTypes.Email)?.Value;
	}
}
