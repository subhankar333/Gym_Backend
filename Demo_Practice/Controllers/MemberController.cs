using Demo_Practice.Interfaces;
using Demo_Practice.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace Demo_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly ILogger<MemberController> _logger;

        public MemberController(IMemberService memberService,  ILogger<MemberController> logger)
        {
            _memberService = memberService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Member>>> GetAllMembers()
        {
            try
            {
                var members = await _memberService.GetAllMembers();
                return Ok(members);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetMember/memberId")]
        public async Task<ActionResult<List<Member>>> GetMemberById(int memberId)
        {
            try
            {
                var member = await _memberService.GetMemberById(memberId);
                return Ok(member);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [Route("AddMember")]
        [HttpPost]

        public async Task<ActionResult<Member>> AddFlight(Member member)
        {
            try
            {
                member = await _memberService.AddMember(member);
                return member;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult<Member>> UpdateMember(Member member)
        {

            try
            {
                var _member = await _memberService.UpdateMember(member);
                return _member;
            }
            catch (Exception ex)

            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }

        }

        [HttpDelete]
        public async Task<ActionResult<Member>> RemoveMember(int memberId)
        {
            try
            {
                var result = await _memberService.RemoveMember(memberId);
                return result;
            }
            catch (Exception ex)

            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }
    }
}
