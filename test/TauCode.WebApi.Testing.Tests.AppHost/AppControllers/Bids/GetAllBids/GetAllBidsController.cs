using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TauCode.Cqrs.Queries;
using TauCode.WebApi.Testing.Tests.AppHost.Core.Features.Bids.GetAllBids;

namespace TauCode.WebApi.Testing.Tests.AppHost.AppControllers.Bids.GetAllBids
{
    [ApiController]
    public class GetAllBidsController : ControllerBase
    {
        private readonly IQueryRunner _queryRunner;

        public GetAllBidsController(IQueryRunner queryRunner)
        {
            _queryRunner = queryRunner;
        }

        [SwaggerOperation(Tags = new[] { "Bids" })]
        [SwaggerResponse(StatusCodes.Status200OK, "All bids", Type = typeof(GetAllBidsQueryResult))]
        [HttpGet]
        [Route("api/bids")]
        public IActionResult GetAllBids()
        {
            var query = new GetAllBidsQuery();
            _queryRunner.Run(query);
            var result = query.GetResult();
            return this.Ok(result);
        }
    }
}
