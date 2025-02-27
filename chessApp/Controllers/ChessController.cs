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
            try
            {

                var Data = chessService.Pieces;
                return Ok(Data);
            }
            catch (Exception)
            {
                return BadRequest("Could not retrive board!");
            }
        }

        [HttpPost("CreateNewStandardBoard")]
        public IActionResult PostBoard()
        {
            try
            {

                chessService.CreateBaseBoard();
                return Ok(chessService.Pieces);
            }
            catch
            {
                return BadRequest("Couldn't create standard chess board!");
            }
        }

        [HttpPost("CreateCustomBoard")]
        public IActionResult PostCustomBoard([FromBody] List<PieceImport> pieceImports)
        {
            try
            {
                chessService.CreateCustomBoard(pieceImports);
                Console.WriteLine(pieceImports.Count);
                return Ok(chessService.Pieces);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
