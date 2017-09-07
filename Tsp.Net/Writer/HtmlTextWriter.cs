using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsp.Net
{
    public class HtmlTextWriter
    {        
        public void Write(Form form, string writeToPath)
        {
            FileInfo fi = new FileInfo(writeToPath);

            using (FileStream fs = fi.Create())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<!DOCTYPE html>\n");
                sb.Append("<html>\n<head>\n");
                sb.Append("<meta charset=\"utf - 8\">");
                sb.Append("</head>");
                sb.Append("<body>");
                sb.Append("<form>");

                foreach (Element ele in form.Elements)
                {
                    string id = "", text = "";
                    foreach (TagAttribute attrib in ele.Attributes)
                    {
                        if (attrib.Attribute == AttributeName.text)
                            text = attrib.Value;
                        if (attrib.Attribute == AttributeName.id)
                            id = attrib.Value;
                    }
                    if (ele.Tag == TagName.button)
                    {
                        sb.Append($"<button type=submit id={id} value=\"{text}\">{text}</button>");
                    }
                    else if (ele.Tag == TagName.label)
                    {
                        sb.Append($"<label id={id} value=\"{text}\">{text}</label>");
                    }
                }
                sb.Append("</form>\n");
                sb.Append("</body></html>");
                byte[] buffer = Encoding.ASCII.GetBytes(sb.ToString());
                fs.Write(buffer, 0, buffer.Length);
            }            
        }
    }
}
