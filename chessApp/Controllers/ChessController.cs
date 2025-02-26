using chessApp.ChessServices;
using chessApp.Pieces;
using Microsoft.AspNetCore.Http.HttpResults;
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
            try
            {
                Console.WriteLine(move.From + " " + move.To);

                var piece = chessService.MovePiece(move.From, move.To);
                return Ok(piece);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("EmptyBoard")]
        public IActionResult EmptyBoard()
        {
            try
            {
                chessService.EmptyTheBoard();
                return Ok("Board successfully emptied!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        public class MoveRequest
        {
            public required Location From { get; set; }
            public required Location To { get; set; }
        }
    }
}
