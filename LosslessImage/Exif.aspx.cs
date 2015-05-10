using ExifLibrary;
using MadsKristensen.ImageOptimizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LosslessImage
{
    public partial class Exif : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           


        }

        protected void btnRun_Click(object sender, EventArgs e)
        {
            // var path = @"d:\45-banner1-test.jpg";
            var path = txtPath.Text.Trim().Replace("\"", "");
            var tmp = Path.GetFileNameWithoutExtension(Path.GetTempFileName());
            var ext = Path.GetExtension(path);
            var filename = string.Format("{0}-{1}{2}", Path.GetFileNameWithoutExtension(path), tmp, ext);

            var targetFile = Path.Combine(Path.GetDirectoryName(path), filename);


            // Extract exif metadata
            var file = ExifFile.Read(path);
            // Clear metadata
            file.Properties.Clear();
            // Save exif data with the image
            file.Save(targetFile);
        }
    }
}