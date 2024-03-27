using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWB.Weixin.Work.Models;

namespace WWB.Weixin.Work.Apis.Contact.Dtos
{
    public class GetUserSimpleListResponse : BaseResponse
    {
        public List<UserSimpleInfo> userlist { get; set; }
    }
}