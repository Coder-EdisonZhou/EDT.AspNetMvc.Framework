using System.Collections.Generic;

namespace Manulife.Web.Mvc.Models
{
    public class MemberStub
    {
        public IList<Member> GetMemberList()
        {
            IList<Member> memberList = new List<Member>();
            for (int i = 0; i < 10; i++)
            {
                Member model = new Member();
                model.Id = 1000 + i;
                model.Name = "Member-" + model.Id.ToString();

                memberList.Add(model);
            }

            return memberList;
        }
    }
}
