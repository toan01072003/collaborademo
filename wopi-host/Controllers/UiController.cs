using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Web;
using WopiHost.Services;

namespace WopiHost.Controllers
{
    public class UiController : Controller
    {
        private readonly IConfiguration _cfg;
        private readonly InMemoryStore _store;

        public UiController(IConfiguration cfg, InMemoryStore store)
        {
            _cfg = cfg; _store = store;
        }

        public IActionResult Index()
        {
            ViewBag.AppBase = _cfg["App:BaseUrl"] ?? "";
            ViewBag.Collabora = _cfg["Collabora:BaseUrl"] ?? "";
            var files = _store.List().ToList();
            return View(files);
        }

        [HttpPost]
public IActionResult Open(string id, string mode)
{
    var appBase = (_cfg["App:BaseUrl"] ?? "").TrimEnd('/');
    var collaboraBase = (_cfg["Collabora:BaseUrl"] ?? "").TrimEnd('/');
    var wopiSrc = HttpUtility.UrlEncode($"{appBase}/wopi/files/{id}");
    var editorUrl = $"{collaboraBase}/browser/0b39b/cool.html?WOPISrc={wopiSrc}";

    // Gán token rõ ràng
    ViewBag.EditorUrl = editorUrl;
    ViewBag.AccessToken = mode == "edit" ? "edit" : "view";
    return View("Editor");
}

    }
}
