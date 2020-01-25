namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Exceptions;

    public class DiLibGridColumnProvider
    {
        public List<string> GetEntityPropertyNames<T>()
        {
            Type type = typeof(T);
            List<PropertyInfo> propertyInfos = new List<PropertyInfo>(type.GetProperties());
            if (propertyInfos.Any())
            {
                List<string> res = propertyInfos
                   .Select(n => n.Name)
                   .ToList();
                return res;
            }

            string msg = $"{nameof(T)} doesn't have any property!";
            throw new DiLibGridColumnProviderNoPropertiesOfTTypeException(msg);
        }

        public List<string> ColumnsToBeDisplayed(List<string> entityProperties, List<string> columnsNotToBeDisplayed)
        {
            if (entityProperties.Any())
            {
                List<string> result = new List<string>();
                foreach (string entityProperty in entityProperties)
                {
                    if (!columnsNotToBeDisplayed.Contains(entityProperty))
                    {
                        result.Add(entityProperty);
                    }
                }

                return result;
            }

            string msg = $"{nameof(entityProperties)} list is empty!";
            throw new DiLibGridColumnProviderNoEntityPropertiesAreProvidedException(msg);
        }

        public List<string> AddEditButtonIfNeeded(List<string> entityProperties, bool rowEditButton)
        {
            if (rowEditButton)
            {
                entityProperties.Add(RowCommandButtonConstants.EditRowCommandButton);
            }

            return entityProperties;
        }

        public List<string> AddDeleteButtonIfNeeded(List<string> entityProperties, bool rowDeleteButton)
        {
            if (rowDeleteButton)
            {
                entityProperties.Add(RowCommandButtonConstants.DeleteRowCommandButton);
            }

            return entityProperties;
        }
    }
}