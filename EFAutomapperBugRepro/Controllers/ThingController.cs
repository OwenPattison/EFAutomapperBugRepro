using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace EFAutomapperBugRepro.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.OData.Query;

    [Route("api/[controller]")]
    [ApiController]
    public class ThingController : ControllerBase
    {
        private readonly ReproContext context;
        private readonly IMapper mapper;

        public ThingController(ReproContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<ThingModel> Get(ODataQueryOptions<Thing> queryOptions)
        {
            var queryable =  this.context.Things.AsQueryable();

            queryable = queryable
                .GroupBy(t => t.TypeId)
                .Select(g => g.First());

            var result = queryOptions.ApplyTo(queryable);
                
            return result.ProjectTo<ThingModel>(this.mapper.ConfigurationProvider);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] ThingModel value)
        {
            var thing = this.mapper.Map<Thing>(value);
            this.context.Things.Add(thing);
            this.context.SaveChanges();
        }
    }
}
