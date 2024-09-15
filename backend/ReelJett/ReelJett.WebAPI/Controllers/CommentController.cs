using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ReelJett.Application.Services;

namespace ReelJett.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase {

    // Fields

    private readonly ICommentService _commentService;

    // Constructor

    public CommentController(ICommentService commentService) {
        _commentService = commentService;
    }

    // Methods

    [HttpPost("AddComment")]
    public async Task<IActionResult> AddComment([FromQuery] string movieid,string content) {

        var List=await _commentService.AddComment(movieid,content,User.FindFirst(ClaimTypes.Name)?.Value!);
        return Ok(List);
    }

    [HttpGet("GetComments")]
    public async Task<IActionResult> GetComments([FromQuery] string movieid) {

        var list = await _commentService.GetComments(movieid);

        if (list != null) return Ok(list);
        else return BadRequest("Movie not Found");
    }

    [HttpPost("LikeComment")]
    public async Task<IActionResult> LikeComment([FromQuery] string commentid) {

        var result = await _commentService.SetCommentLikeCount(commentid, User.FindFirst(ClaimTypes.Name)?.Value!);
        return Ok(result);
    }

    [HttpDelete("DeleteUnwantedComment")]
    public async Task<IActionResult> DeleteUnwantedComment([FromQuery] string movieid,string commentid)
    {

        await _commentService.DeleteUnwantedComment(movieid, commentid, User.FindFirst(ClaimTypes.Name)?.Value!);
        return Ok();
    }

    [HttpDelete("DeleteComment")]
    public async Task<IActionResult> DeleteComment([FromQuery] string commentid)
    {
        await _commentService.DeleteComment(commentid, User.FindFirst(ClaimTypes.Name)?.Value!);
        return Ok();
    }

}
