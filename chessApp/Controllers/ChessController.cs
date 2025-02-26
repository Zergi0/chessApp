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

        [HttpPost("CreateNewStandardBoard")]
        public IActionResult PostBoard()
        {
            chessService.CreateNewBoard();
            var Data = chessService.GetPieces();
            return Ok(Data);
        }

        [HttpPost("CreateCustomBoard")]
        public IActionResult PostCustomBoard([FromBody] List<PieceImport> pieceImports)
        {
            return Ok();
        }

        [HttpPut("MakeMove")]
        public IActionResult MovePiece([FromBody] MoveRequest move)
        {
            if (move == null) return NotFound();
            try
            {
                Console.WriteLine(move.From + " " + move.To);

                var piece = chessService.MovePiece(move.From, move.To);
                return Ok(piece);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        public class MoveRequest
        {
            public required Location From { get; set; }
            public required Location To { get; set; }
        }
    }
}
