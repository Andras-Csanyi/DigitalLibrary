namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using Exceptions;

    public class GenericObjectPropertiesProvider
    {
        public async Task<string> GetPropertyValueOfGenericObject<T>(string propertyName, T o)
        {
            try
            {
                PropertyInfo propertyInfo = await GetProperty(o, propertyName).ConfigureAwait(false);
                string result = propertyInfo.GetValue(o, null).ToString();
                return result;
            }
            catch (Exception e)
            {
                throw new GenericObjectPropertiesProviderException(e.Message, e);
            }
        }

        public async Task<string> GetType<T>()
        {
            return typeof(T).ToString();
        }

        private async Task<PropertyInfo> GetProperty<T>(T o, string propertyName)
        {
            Type type = typeof(T);
            PropertyInfo propertyInfo = type.GetProperty(propertyName);
            return propertyInfo;
        }

        public async Task<List<PropertyInfo>> GetPropertyInfos<T>(List<string> columns)
        {
            Type type = typeof(T);
            List<PropertyInfo> propertyInfos = new List<PropertyInfo>(type.GetProperties()
               .ToList()
               .Where(n => columns.Contains(n.Name))
               .ToList());
            return propertyInfos;
        }
    }
}