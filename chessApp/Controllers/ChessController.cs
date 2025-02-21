using chessApp.ChessServices;
using chessApp.Pieces;
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


        //
        [HttpPut("MakeMove")]
        public IActionResult MovePiece([FromBody] MoveRequest move)
        {
            try
            {
                var piece = chessService.MovePiece(move.From, move.To);
                return Ok(piece);
            } catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);

            } catch (InvalidOperationException ex) {
                return BadRequest(ex.Message);
            }
        }

        public class MoveRequest
        {
            public required Location From { get; set; }
            public required Location To { get; set; }
        }
    }
}
