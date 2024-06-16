using Demo_Practice.Context;
using Demo_Practice.Interfaces;
using Demo_Practice.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_Practice.Repository
{
    public class MemberRepository:IMemberRepository
    {
        private readonly GymDbContext _context;
        private readonly ILogger<MemberRepository> _logger;

        public MemberRepository(GymDbContext context, ILogger<MemberRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Member> Add(Member member)
        {
            _context.Add(member);
            _context.SaveChanges();
            _logger.LogInformation("Member added with MemberId " + member.MemberId);
            return member;
        }

        public async Task<Member> Delete(int memberId)
        {
            var member = await GetAsync(memberId);
            if (member != null)
            {
                _context.Remove(member);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Member removed with MemberId {memberId}");
                return member;
            }
            throw new Exception("Member not found");
        }


        public async Task<Member> GetAsync(int memberId)
        {
            var members = await GetAsync();
            var member = members.FirstOrDefault(e => e.MemberId == memberId);
            if (member != null)
            {
                return member;
            }
            throw new Exception();
        }

        public async Task<List<Member>> GetAsync()
        {
            var members = _context.Members.ToList();
            return members;
        }

        public async Task<Member> Update(Member item)
        {
            var member = await GetAsync(item.MemberId);
            if (member != null)
            {
                _context.Entry(member).CurrentValues.SetValues(item);
                _context.SaveChanges();
                _logger.LogInformation($"Member updated with memberId {item.MemberId}");
                return member;
            }
            throw new Exception();
        }
    }
}
