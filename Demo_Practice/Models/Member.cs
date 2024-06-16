using System.ComponentModel.DataAnnotations;

namespace Demo_Practice.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }   
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime MembershipExpiry { get; set; }
        public DateTime DOJ { get; set; }

        public Member()
        {
            MemberId = 0;
        }
        public Member(int memberId, string name, string email, string phone, DateTime membershipExpiry, DateTime doj)
        {
            MemberId = memberId;
            Name = name;
            Email = email;
            Phone = phone;
            MembershipExpiry = membershipExpiry;
            DOJ = doj;
        }
    }
}
