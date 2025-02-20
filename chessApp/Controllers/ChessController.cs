using chessApp.ChessServices;
using Microsoft.AspNetCore.Mvc;

namespace chessApp.Controllers
{
    [ApiController]
    [Route("api/chess")]
    public class ChessController : ControllerBase
    {
        private IChessService chessService;

        public ChessController(IChessService chessService)
        {
            this.chessService = chessService;
        }

        [HttpGet("GetBoard")]
        public IActionResult Get()
        {
            var Data = chessService.GetPieces();
            return Ok(Data);
        }

        [HttpPost("CreateNewBoard")]
        public IActionResult Post()
        {
            chessService.CreateNewBoard();
            var Data = chessService.GetPieces();
            return Ok(Data);

        }
    }
}
