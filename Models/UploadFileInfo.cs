using System;

namespace fileupload.Models
{
    public class UploadFileInfo
    {
        public string Category { get; set; }
        public string Name { get; set; }

        public long Size { get; set; }

        public string Hash { get; set; }

        public int? Chunks { get; set; }

        public int? Chunk { get; set; }

        public int? ChunkSize { get; set; }
        public string ChunkHash { get; set; }
    }
}
