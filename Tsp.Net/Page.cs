using System;
using System.Collections.Generic;
using System.IO;

namespace Tsp.Net
{
    public class Page:Control
    {        
        public Form TspxForm { get; set; }
        public HtmlForm HtmlForm { get; set; }
        public string TspxPath { get; set; }

        public Page()
        {

        }
        
        public Page(string path)
        {
            TspxPath = path;
            TspxForm = CreateForm(new FormParser(), path);            
        }
        
        public event EventHandler PreInit;                

        protected virtual void OnPreInit(EventArgs e)
        {            
            if(PreInit != null)
                PreInit(this,e);   
        }
        
        private Form CreateForm(FormParser parser,string sourcePath)
        {
            Form form = new Form();
            try
            {
                FileInfo fi = new FileInfo(sourcePath);
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
                        foreach (KeyValuePair<string, string> attribute in attributes)
                        {
                            Enum.TryParse(attribute.Key, out AttributeName attributeName);
                            TagAttribute formAttribute = new TagAttribute();
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

        protected internal override void Render(HtmlTextWriter writer)
        {
            OnPreInit(EventArgs.Empty);
            OnInit(EventArgs.Empty);
            FileInfo fi = new FileInfo(TspxPath);
            var htmlTargetPath = Path.Combine(fi.DirectoryName, "index.html");
            writer.Write(TspxForm, htmlTargetPath);
        }

      
    }
}
