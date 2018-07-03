namespace EFAutomapperBugRepro.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.OData.Query;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ThingWithoutTypeController : ControllerBase
    {
        private readonly ReproContext context;
        private readonly IMapper mapper;

        public ThingWithoutTypeController(ReproContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<ThingWithoutTypeModel> Get(ODataQueryOptions<Thing> queryOptions)
        {
            var queryable = this.context.Things.AsQueryable();

            queryable = queryable
                .GroupBy(t => t.TypeId)
                .Select(g => g.First());

            var result = queryOptions.ApplyTo(queryable);

            return result.ProjectTo<ThingWithoutTypeModel>(this.mapper.ConfigurationProvider);
        }
    }
}