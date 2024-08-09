using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeTCindyAutoInstallerGUI
{
    public class ReleaseObject
    {
        public string url { get; set; }
        public string name { get; set; }
        public string tag_name { get; set; }
        public string zipball_url { get; set; }
        public List<AssetsObject> assets { get; set; }
    }

    public class AssetsObject
    {
        public string name { get; set; }
        public string browser_download_url { get; set; }
    }
}
