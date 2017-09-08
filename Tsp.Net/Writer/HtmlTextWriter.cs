
using System.IO;
using System.Text;


namespace Tsp.Net
{
    public class HtmlTextWriter
    {
        public void Write(string writeToPath, Control[] control)
        {
            StringBuilder sb = new StringBuilder();
            sb = AppendHtmlStart(sb);
            for (int i = 0; i < control.Length; i++)
            {
                sb.Append(control[i].ToString());
            }
            sb.Append(AppendHtmlEnd(sb));
            FileInfo fi = new FileInfo(writeToPath);
            if (fi.Exists)
                fi.Delete();
            using (FileStream fs = fi.Create())
            {
                byte[] buffer = Encoding.ASCII.GetBytes(sb.ToString());
                fs.Write(buffer, 0, buffer.Length);
            }
        }

        public void Write(Form form, string writeToPath)
        {
            FileInfo fi = new FileInfo(writeToPath);

            using (FileStream fs = fi.Create())
            {
                StringBuilder sb = new StringBuilder();

                sb = AppendHtmlStart(sb);
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
                        sb.Append($"<Button id= {id} >{text}</button>");
                    }
                    else if (ele.Tag == TagName.label)
                    {
                        sb.Append($"<Label id= {id} >{text}</Label>");
                    }
                }
                sb.Append(AppendHtmlEnd(sb));
                byte[] buffer = Encoding.ASCII.GetBytes(sb.ToString());
                fs.Write(buffer, 0, buffer.Length);
            }
        }

        private StringBuilder AppendHtmlStart(StringBuilder sb)
        {
            sb.Append("<!DOCTYPE html>\n");
            sb.Append("<html>\n<head>\n");
            sb.Append("<meta charset=\"utf - 8\">");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append("<form>");
            return sb;
        }

        private StringBuilder AppendHtmlEnd(StringBuilder sb)
        {
            sb.Append("</form>\n");
            sb.Append("</body></html>");
            return sb;
        }
    }
}
