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
    public partial class SingleFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           


        }

        protected void btnRun_Click(object sender, EventArgs e)
        {
            // var path = @"d:\45-banner1-test.jpg";
            var path = txtPath.Text.Trim();
            var tmp = Path.GetFileNameWithoutExtension(Path.GetTempFileName());
            var filename = Path.GetFileName(path);

            var targetFile = Path.GetPathRoot(path) + (tmp + filename);

            var toolPath = Page.Server.MapPath("~/ImageOptimizer/Tools/");
            var compress = new Compressor();
            dynamic result = compress.CompressFile(path, targetFile, toolPath);
        }
    }
}