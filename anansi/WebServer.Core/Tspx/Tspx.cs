using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsp.Net
{
    public class Tspx
    {
        private string _tspxPath;

        public Tspx(string tspxPath)
        {
            _tspxPath = tspxPath;            
        }
        
        public void RunPage(Page page)
        {           
            page.OnPreInit(EventArgs.Empty);
            page.OnInit(EventArgs.Empty);
            page.OnLoad(EventArgs.Empty);
            page.OnPreRender(EventArgs.Empty);
            page.Render(new HtmlTextWriter());
        }

        public string CreateClassTemplate(string className, Form form)
        {                                                
            CodeBehindTextWriter template = new CodeBehindTextWriter();
            FileInfo fi = new FileInfo(_tspxPath);
            var codeBehindPath = System.IO.Path.Combine(fi.DirectoryName, $"{className}.cs");           
            template.Write(codeBehindPath, form, className);
            return codeBehindPath;
        }

        public Form CreateForm(FormParser parser)
        {
            Form form = new Form();
            try
            {
                FileInfo fi = new FileInfo(_tspxPath);
                if (fi.Exists && fi.Extension.Equals(".tspx"))
                {
                    List<Element> formElements = new List<Element>();
                    List<string> elements = null;

                    using (StreamReader streamReader = fi.OpenText())
                    {
                        elements = parser.ParseElement(streamReader);
                    }

                    foreach (string element in elements)
                    {
                        var tag = element.Substring(0, element.IndexOf(' '));
                        var attributes = parser.ParseAttributes(element);
                        List<TagAttribute> formAttributes = new List<TagAttribute>();
                        TagAttribute formAttribute;
                        foreach (KeyValuePair<string, string> attribute in attributes)
                        {
                            Enum.TryParse(attribute.Key, out AttributeName attributeName);
                            formAttribute = new TagAttribute();
                            formAttribute.Attribute = attributeName;
                            formAttribute.Value = attribute.Value;
                            formAttributes.Add(formAttribute);
                        }
                        Enum.TryParse(tag, out TagName tagName);
                        Element formElement = new Element();
                        formElement.Tag = tagName;
                        formElement.Attributes = formAttributes;
                        formElements.Add(formElement);
                    }

                    form.Elements = formElements;

                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (FileNotFoundException ex)
            {

            }
            catch (Exception ex)
            {

            }
            return form;
        }
    }


}
