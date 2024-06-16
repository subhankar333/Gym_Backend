using Demo_Practice.Models;

namespace Demo_Practice.Interfaces
{
    public interface IMemberService
    {
        public Task<Member> AddMember(Member member);
        public Task<Member> RemoveMember(int memberId);
        public Task<Member> GetMemberById(int memberId);
        public Task<List<Member>> GetAllMembers();
        public Task<Member> UpdateMember(Member member);
       
    }
}
