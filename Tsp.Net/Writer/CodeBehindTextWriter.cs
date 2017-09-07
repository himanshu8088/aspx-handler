using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsp.Net
{
    public class CodeBehindTextWriter
    {
        public void Write(string writeToPath, Form form)
        {
            FileInfo fi = new FileInfo(writeToPath);

            using (FileStream fs = fi.Create())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("using System;\n");
                sb.Append("using Tsp.Net.Controls;\n");
                sb.Append("namespace Tsp.Net\n{\n");
                var className = $"Page{ CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fi.Name.Substring(0, fi.Name.IndexOf('.'))) }";
                sb.Append($"public class { className} : Page\n{{\n");                
                int btnCount = 0;
                int lblCount = 0;
                foreach (Element ele in form.Elements)
                {
                    if (ele.Tag == TagName.button)
                    {
                        sb.Append($"Button btn{btnCount} = new Button();\n");
                        btnCount++;
                    }
                    else if (ele.Tag == TagName.label)
                    {
                        sb.Append($"Label lbl{lblCount} = new Label();\n");
                        lblCount++;
                    }
                }
                sb.Append("}\n");
                sb.Append("}");
                byte[] buffer = Encoding.ASCII.GetBytes(sb.ToString());
                fs.Write(buffer, 0, buffer.Length);
            }
        }
    }


}
