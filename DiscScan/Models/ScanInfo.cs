using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscScan.Models
{
    public class ScanInfo
    {
        public enum InfoTypes { Folder, File };
        //public string Drive { get; set; }
        public InfoTypes InfoType { get; set; }
        public string Path { get; set; }
        public string? Name { get; set; }
        public string? Extension { get; set; }
        public DateTime LastModified { get; set; }
        public long Size { get; set; }

        public ScanInfo( InfoTypes infoType, string path, string? name, string? extension, DateTime lastModified, long size)
        {
            //Drive = drive;
            InfoType = infoType;
            Path = path;
            Name = name;
            Extension = extension;
            LastModified = lastModified;
            Size = size;
        }

        public async void ToCSV(StreamWriter writer)
        {
            await writer.WriteLineAsync(InfoType.ToString() + "," + Path + "," + Name + "," + Extension + "," + LastModified.ToString() + "," + Size.ToString());
        }
    }
}
