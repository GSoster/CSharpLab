using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace Xml
{
    public class XmlWriter
    {
        public XDocument MapClassToXmlDocPropAsElement(object instance, bool createPropertiesAsAttribute = false)
        {
            var document = CreateRootElement(instance);

            AddProperties(instance, ref document, createPropertiesAsAttribute);

            return document;
        }

        public void AddProperties(object instance, ref XDocument document, bool createPropertiesAsAttribute = false)
        {
            foreach (var property in instance.GetType().GetProperties())
            {
                //specific to IEnumerable
                if (property.PropertyType.GetInterfaces().Contains(typeof(IEnumerable)))
                {
                    //create nodo to type
                    var elem = new XElement(property.Name + Guid.NewGuid().ToString());
                    //iterate over each property from the type.
                    foreach (var item in (IEnumerable)property.GetValue(instance))
                    {
                        AddPropertiesToXElement(instance, ref elem);
                    }
                    //add it to the nodo
                    document.Root.Add(elem);
                    //add noto to the current document
                }

                if (createPropertiesAsAttribute)
                    AddPropertyAsAttribute(instance, property, document.Root);
                else
                    AddPropertyAsElement(instance, property, document.Root);
            }
        }

        public void AddPropertiesToXElement(object instance, ref XElement element)
        {
            foreach (var property in instance.GetType().GetProperties())
            {
                AddPropertyAsAttribute(instance, property, element);
            }
        }

        public void AddPropertyAsAttribute(object instance, PropertyInfo property, XElement elementContainer)
        {
            var value = property.GetValue(instance);
            var propertyElement = new XAttribute(property.Name, value);
            elementContainer.Add(propertyElement);
        }

        public void AddPropertyAsElement(object instance, PropertyInfo property, XElement elementContainer)
        {
            var value = property.GetValue(instance);
            var propertyElement = new XElement(property.Name, value);
            elementContainer.Add(propertyElement);
        }

        public void AddPropertiesAsAttributes(object instance, ref XDocument document)
        {
            foreach (var property in instance.GetType().GetProperties())
            {
                var value = property.GetValue(instance);
                var propertyElement = new XAttribute(property.Name, value);
                document.Root.Add(propertyElement);
            }
        }

        public XDocument CreateRootElement(object instance)
        {
            var document = new XDocument();
            var instanceType = instance.GetType();
            var element = new XElement(instanceType.Name);
            document.Add(element);
            return document;
        }
    }
}