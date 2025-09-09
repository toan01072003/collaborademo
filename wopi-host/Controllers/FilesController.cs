using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using WopiHost.Services;

namespace WopiHost.Controllers
{
    [Route("files")]
    public class FilesController : Controller
    {
        private readonly InMemoryStore _store;
        public FilesController(InMemoryStore store) { _store = store; }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0) return BadRequest("No file");
            await using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var entry = new FileEntry
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = file.FileName,
                ContentType = file.ContentType ?? "application/octet-stream",
                Bytes = ms.ToArray(),
                Version = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            };
            _store.Set(entry);
            return RedirectToAction("Index", "Ui");
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(string id)
        {
            _store.Remove(id);
            return RedirectToAction("Index", "Ui");
        }
    }
}
