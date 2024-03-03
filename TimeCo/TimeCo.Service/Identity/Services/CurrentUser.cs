using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TimeCo.Common.Contracts;

namespace TimeCo.Service.Identity.Services
{
    internal class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        private Guid? userId;

        public CurrentUser(IHttpContextAccessor? httpContextAccessor = null)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public Guid? Id
        {
            get
            {
                if (!this.userId.HasValue)
                {
                    var rawUserId = this.httpContextAccessor?
                        .HttpContext?
                        .User?
                        .Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?
                        .Value;

                    if (!string.IsNullOrWhiteSpace(rawUserId) && Guid.TryParse(rawUserId, out var parsedUserId))
                    {
                        this.userId = parsedUserId;
                    }
                }

                return this.userId;
            }
        }
    }
}
