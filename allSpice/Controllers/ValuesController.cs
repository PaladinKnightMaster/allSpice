namespace allSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
  [HttpGet]
  public ActionResult<List<string>> Get()
  {
    try
    {
      return Ok(new List<string>() { "Value 1", "Value 2" });
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpPost]
  public ActionResult<List<string>> Create([FromBody] string value)
  {
    try
    {
      return Ok(value);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}
