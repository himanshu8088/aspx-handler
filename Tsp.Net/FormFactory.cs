using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace Tsp.Net
{
    public class FormFactory
    {
        public Form Create(string path)
        {
            Form form = null;
            try
            {                
                FileInfo fi = new FileInfo(path);
                if (fi.Exists && fi.Extension.Equals(".tspx"))
                {
                    form = ConstructForm(fi);                   
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

        private Form ConstructForm(FileInfo fi)
        {
            Form form = new Form();
            WebFormParser parser = new WebFormParser();
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
            return form;
        }        
    }
}




//Type fileInfoType = Type.GetType("System.IO.FileInfo");
//ConstructorInfo fileInfoConstructor = fileInfoType.GetConstructor(new[] { typeof(string)});
//object fileInfoObject = fileInfoConstructor.Invoke(new object[] {path});

//MethodInfo fileInfoMethod = fileInfoType.GetMethod("OpenText");
//object streamReader = fileInfoMethod.Invoke(fileInfoObject, new object[] { });
