using BlazorAO.App.Data.Repositories;
using BlazorAO.Models;
using Dapper.CX.SqlServer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorAO.App.Controllers
{
    public class DemoController : Controller
    {
        private readonly DapperCX<int, UserProfile> _data;

        public DemoController(DapperCX<int, UserProfile> data)
        {
            _data = data;    
        }

        public async Task<IActionResult> Index()
        {
            //var row = await _data.

            return View();
        }
    }
}
