using Microsoft.AspNetCore.Mvc;
using ReceptApi.Data;

namespace ReceptApi.Controllers
{
    [Route("api/desszert")]
    public class DesszertController : EtelAlapController
    {
        protected override string Tipus => "desszert";

        public DesszertController(ReceptContext db) : base(db) { }
    }
}