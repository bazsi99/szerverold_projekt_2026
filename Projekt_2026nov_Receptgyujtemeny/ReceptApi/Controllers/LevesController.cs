using Microsoft.AspNetCore.Mvc;
using ReceptApi.Data;

namespace ReceptApi.Controllers
{
    [Route("api/leves")]
    public class LevesController : EtelAlapController
    {
        protected override string Tipus => "leves";

        public LevesController(ReceptContext db) : base(db) { }
    }
}