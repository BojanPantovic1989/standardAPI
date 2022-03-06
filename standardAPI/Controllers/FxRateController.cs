using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using standardAPI.Database;
using standardAPI.Models;
using System;
using System.Collections.Generic;

namespace standardAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FxRateController : ControllerBase
    {
        private static readonly Func<EfDbContext, IAsyncEnumerable<FxRate>> getCurrencyQuery = EF.CompileAsyncQuery
            ((EfDbContext context) => context.Rates);   

        private readonly EfDbContext dbContext;
        public FxRateController(EfDbContext dbContext)
        {            
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Authorize]
        public IAsyncEnumerable<FxRate> Get()
        {
            return getCurrencyQuery(dbContext);
        }

    }
}
