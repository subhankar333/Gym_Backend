using Demo_Practice.Models;

namespace Demo_Practice.Interfaces
{
    public interface IMemberRepository
    {
        public Task<Member> Add(Member member);
        public Task<Member> Update(Member member);
        public Task<Member> Delete(int memberId);
        public Task<List<Member>> GetAsync();
        public Task<Member> GetAsync(int memberId);
    }
}
