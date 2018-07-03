namespace EFAutomapperBugRepro.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class ThingTypeController : ControllerBase
    {
        private readonly ReproContext context;
        private readonly IMapper mapper;

        public ThingTypeController(ReproContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<ThingTypeModel> Get()
        {
            return context.ThingTypes.ProjectTo<ThingTypeModel>(this.mapper.ConfigurationProvider);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] ThingTypeModel value)
        {
            var thingType = this.mapper.Map<ThingType>(value);
            this.context.ThingTypes.Add(thingType);
            this.context.SaveChanges();
        }
    }
}