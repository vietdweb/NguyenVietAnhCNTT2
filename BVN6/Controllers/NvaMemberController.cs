using BVN6.Models;
using Microsoft.AspNetCore.Mvc;

namespace BVN6.Controllers
{
    public class NvaMemberController : Controller
    {
        // mock data
        private static readonly List<NvaMember> _nvaMembers = new List<NvaMember>()
        {
            new NvaMember
            {
                NvaMemberId = Guid.NewGuid().ToString(),
                NvaMemberUserName = "tuuananh",
                NvaMemberPassword = "tuuananh@",
                NvaMemberEmail = "tuuananh@gmail.com",
                NvaMemberFullName = "tuuananh"
            },
            new NvaMember
            {
                NvaMemberId = Guid.NewGuid().ToString(),
                NvaMemberUserName = "vietanh",
                NvaMemberPassword = "123456a@",
                NvaMemberEmail = "vietanh@gmail.com",
                NvaMemberFullName = "Nguyễn Việt Anh"
            },
            new NvaMember
            {
                NvaMemberId = Guid.NewGuid().ToString(),
                NvaMemberUserName = "namnguyen",
                NvaMemberPassword = "123456a@",
                NvaMemberEmail = "namnguyen@gmail.com",
                NvaMemberFullName = "Nguyễn Văn Nam"
            },
            new NvaMember
            {
                NvaMemberId = Guid.NewGuid().ToString(),
                NvaMemberUserName = "phuongle",
                NvaMemberPassword = "123456a@",
                NvaMemberEmail = "phuongle@gmail.com",
                NvaMemberFullName = "Lê Thị Phương"
            },
            new NvaMember
            {
                NvaMemberId = Guid.NewGuid().ToString(),
                NvaMemberUserName = "hoangtran",
                NvaMemberPassword = "123456a@",
                NvaMemberEmail = "hoangtran@gmail.com",
                NvaMemberFullName = "Trần Huy Hoàng"
            }
        };
        //get : list
        public IActionResult NvaIndex()
        {
            return View(_nvaMembers);
        }
        public IActionResult NvaCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NvaCreate(NvaMember nvaMember)
        {
            nvaMember.NvaMemberId = Guid.NewGuid().ToString();
            _nvaMembers.Add(nvaMember);
            return RedirectToAction("NvaIndex");
        }
        public IActionResult NvaEdit(string id)
        {
            var nvaMember = _nvaMembers.FirstOrDefault(x=> x.NvaMemberId.Equals(id));
            return View(nvaMember);
        }
        [HttpPost]
        public IActionResult NvaEdit(string id, NvaMember nvaMember)
        {
            for (int i = 0; i < _nvaMembers.Count; i++)
            {
                if (_nvaMembers[i].NvaMemberId == id)
                {
                    _nvaMembers[i].NvaMemberId = nvaMember.NvaMemberId;
                    _nvaMembers[i].NvaMemberUserName = nvaMember.NvaMemberUserName;
                    _nvaMembers[i].NvaMemberPassword = nvaMember.NvaMemberPassword;
                    _nvaMembers[i].NvaMemberEmail = nvaMember.NvaMemberEmail;
                    _nvaMembers[i].NvaMemberFullName = nvaMember.NvaMemberFullName;
                    break;
                }
            }
            return RedirectToAction("NvaIndex");
        }
        public IActionResult NvaGetDetails()
        {
            var nvaMember = new NvaMember()
            {
                NvaMemberId = Guid.NewGuid().ToString(),
                NvaMemberUserName = "Việt Anh",
                NvaMemberPassword = "rtmx@",
                NvaMemberFullName = "Nguyễn Việt Anh",
                NvaMemberEmail = "nvietanh@gmail.com"
            };
            return View(nvaMember);
        }
    }
}
