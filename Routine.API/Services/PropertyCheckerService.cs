using System.Reflection;
using Routine.API.Helpers;

namespace Routine.API.Services
{
    public class PropertyCheckerService : IPropertyCheckerService
    {
        public bool TypeHasProperties<T>(string fields)
        {
            if (string.IsNullOrWhiteSpace(fields))
            {
                return true;
            }

            var fieldsAfterSpilt = fields.Split(',');
            foreach (var field in fieldsAfterSpilt)
            {
                var propertyName = field.Trim();
                var propertyInfo = typeof(T).GetProperty(propertyName,
                    BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance);

                if (propertyInfo ==null)
                {
                    return false;
                }
            }

            return true;

        }
    }
}