using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace WopiHost.Services
{
    public class InMemoryStore
    {
        private readonly ConcurrentDictionary<string, FileEntry> _map = new();
        public bool TryGet(string id, out FileEntry entry) => _map.TryGetValue(id, out entry!);
        public void Set(FileEntry entry) => _map[entry.Id] = entry;
        public bool Exists(string id) => _map.ContainsKey(id);
        public IEnumerable<FileEntry> List() => _map.Values.OrderByDescending(f => f.Version);
        public void Remove(string id) => _map.TryRemove(id, out _);
    }

    public class FileEntry
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ContentType { get; set; } = "application/octet-stream";
        public string OwnerId { get; set; } = "user-123";
        public long Version { get; set; }
        public byte[] Bytes { get; set; } = System.Array.Empty<byte>();
    }
}
