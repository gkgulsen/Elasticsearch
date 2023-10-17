using Elasticsearch.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Elasticsearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ECommerceController : BaseController
    {
        private readonly IECommerceService _service;

        public ECommerceController(IECommerceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> TermQuery(string customerFirstName)
        {

            return Ok(await _service.TermQueryAsync(customerFirstName));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> TermsQuery(List<string> customerFirstNameList)
        {

            return Ok(await _service.TermsQueryAsync(customerFirstNameList));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> PrefixQuery(string customerFullName)
        {

            return Ok(await _service.PrefixQueryAsync(customerFullName));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> RangeQuery(double fromPrice, double toPrice)
        {

            return Ok(await _service.RangeQueryAsync(fromPrice, toPrice));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> MatchAllQuery()
        {

            return Ok(await _service.MatchAllQueryAsync());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> PaginationQuery(int page = 1, int pageSize = 10)
        {

            return Ok(await _service.PaginationQueryAsync(page, pageSize));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> WildCardQuery(string customerFullName)
        {

            return Ok(await _service.WildCardQueryAsync(customerFullName));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FuzzyQuery(string customerName)
        {

            return Ok(await _service.FuzzyQueryAsync(customerName));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> MatchQueryFullText(string categoryName)
        {

            return Ok(await _service.MatchQueryFullTextAsync(categoryName));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> MatchBoolPrefixQueryFullText(string customerFullName)
        {

            return Ok(await _service.MatchBoolPrefixQueryFullTextAsync(customerFullName));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> MatchPhraseQueryFullText(string customerFullName)
        {

            return Ok(await _service.MatchPhraseQueryFullTextAsync(customerFullName));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CompoundQuery(string cityName, double taxfulTotalPrice, string categoryName, string manufacturer)
        {

            return Ok(await _service.CompoundQueryAsync(cityName, taxfulTotalPrice, categoryName, manufacturer));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CompoundQueryTwo(string customerFullName)
        {

            return Ok(await _service.CompoundQueryTwoAsync(customerFullName));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> MultiMatchQueryFullText(string name)
        {

            return Ok(await _service.MultiMatchQueryFullTextAsync(name));
        }
    }
}
