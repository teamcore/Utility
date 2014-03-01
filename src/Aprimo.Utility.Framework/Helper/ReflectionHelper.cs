using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml;

namespace Aprimo.Utility.Framework.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public static class ReflectionHelper
    {
        /// <summary>
        /// Gets the assembly.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static Assembly GetAssembly(Type type)
        {
            string assemblyName = type.Assembly.GetName().Name;
            return Assembly.Load(assemblyName);
        }

        /// <summary>
        /// Extracts an embedded file out of a given assembly.
        /// </summary>
        /// <param name="assemblyName">The namespace of you assembly.</param>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <returns>A stream containing the file data.</returns>
        public static Stream GetEmbeddedFile(string assemblyName, string fileName)
        {
            try
            {
                Assembly a = Assembly.Load(assemblyName);
                Stream str = a.GetManifestResourceStream(assemblyName + "." + fileName);

                if (str == null)
                {
                    throw new Exception("Could not locate embedded resource '" + fileName + "' in assembly '" + assemblyName + "'");
                }

                return str;
            }
            catch (Exception e)
            {
                throw new Exception(assemblyName + ": " + e.Message);
            }
        }

        /// <summary>
        /// Gets the embedded file.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static Stream GetEmbeddedFile(Assembly assembly, string fileName)
        {
            string assemblyName = assembly.GetName().Name;
            return GetEmbeddedFile(assemblyName, fileName);
        }

        /// <summary>
        /// Gets the embedded file.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static Stream GetEmbeddedFile(Type type, string fileName)
        {
            string assemblyName = type.Assembly.GetName().Name;
            return GetEmbeddedFile(assemblyName, fileName);
        }

        /// <summary>
        /// Gets the embedded XML.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static XmlDocument GetEmbeddedXml(Type type, string fileName)
        {
            Stream str = GetEmbeddedFile(type, fileName);
            XmlTextReader tr = new XmlTextReader(str);
            XmlDocument xml = new XmlDocument();
            xml.Load(tr);
            return xml;
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="type">The type.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public static object GetPropertyValue(object entity, string propertyName, object[] index)
        {
            object propertyValue = null;
            Type type = entity.GetType();
            PropertyInfo propertyInfo = type.GetProperty(propertyName);
            if(propertyInfo != null)
            {
                propertyValue = propertyInfo.GetValue(entity, index);
            }

            return propertyValue;
        }

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="propertyValue">The property value.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public static bool SetPropertyValue(object entity, string propertyName, object propertyValue, object[] index)
        {
            Type entityType = entity.GetType();
            PropertyInfo propertyInfo = entityType.GetProperty(propertyName);

            if (propertyInfo == null)
            {
                return false;
            }

            if (!propertyInfo.PropertyType.Equals(propertyValue.GetType()))
            {
                return false;
            }

            propertyInfo.SetValue(entity, propertyValue, index);
            return true;
        }

        /// <summary>
        /// Gets the member info.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static MemberInfo GetMemberInfo<T, U>(Expression<Func<T, U>> expression)
        {
            var member = expression.Body as MemberExpression;
            if (member != null)
                return member.Member;

            throw new ArgumentException("Expression is not a member access", "expression");
        }
    }
}
