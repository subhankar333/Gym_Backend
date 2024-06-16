using Demo_Practice.Interfaces;
using Demo_Practice.Models;
using Demo_Practice.Repository;

namespace Demo_Practice.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly ILogger<MemberService> _logger;

        public MemberService(IMemberRepository memberRepository, ILogger<MemberService> logger)
        {
            _memberRepository = memberRepository;
            _logger = logger;
        }
        public async Task<Member> AddMember(Member member)
        {
            return await _memberRepository.Add(member);
        }

        public async Task<List<Member>> GetAllMembers()
        {
            return await _memberRepository.GetAsync();
        }

        public async Task<Member> GetMemberById(int memberId)
        {
            return await _memberRepository.GetAsync(memberId);
        }

        public async Task<Member> RemoveMember(int memberID)
        {
            var member = await _memberRepository.GetAsync(memberID);
            if (member != null)
            {
                await _memberRepository.Delete(memberID);
                return member;
            }

            return null;
        }

        public async Task<Member> UpdateMember(Member member)
        {
            var _member = await _memberRepository.GetAsync(member.MemberId);
            if (member != null)
            {
                _member =  await _memberRepository.Update(member);
                return _member;
            }

            return null;
        }
    }
}
