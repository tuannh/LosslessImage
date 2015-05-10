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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRun_Click(object sender, EventArgs e)
        {
            var path = txtPath.Text.Trim().Replace("\"", "");
            var lst = File.ReadAllLines(path);

            var result = "";
            var count = 0;
            foreach (var filePath in lst)
            {
                var tmpPath = filePath.Trim().Replace("\"", "");
                var tmpResult = Run(tmpPath);

                if (tmpResult == string.Empty)
                    count++;
                else
                    result += tmpResult + "<br/>";
            }

            lblSuccess.Text = count.ToString();
            lblError.Text = result;
        }

        protected string Run(string path)
        {
            try
            {
                var ext = Path.GetExtension(path);
                var targetFile = Path.ChangeExtension(Path.GetTempFileName(), ext);

                var toolPath = Page.Server.MapPath("~/ImageOptimizer/Tools/");
                var compress = new Compressor();
                dynamic result = compress.CompressFile(path, targetFile, toolPath);

                File.Delete(path);
                File.Move(targetFile, path);

                return string.Empty;
            }
            catch (Exception exp)
            {
                return path;
            }
        }
    }
}