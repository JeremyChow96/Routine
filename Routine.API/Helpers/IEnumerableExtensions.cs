﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace Routine.API.Helpers
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<ExpandoObject> ShapeData<TSource>(this IEnumerable<TSource> source, string fields)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
           
            var expandObjectList = new List<ExpandoObject>(source.Count());

            var propertyInfoList = new  List<PropertyInfo>();

            if (string.IsNullOrWhiteSpace(fields))
            {
                var propertyInfos = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                propertyInfoList.AddRange(propertyInfos);
            }
            else
            {
                var fieldsAfterSplit = fields.Split(',');
                foreach (var field in fieldsAfterSplit)
                {
                    var propertyName = field.Trim();
                    var propertyInfo = typeof(TSource).GetProperty(propertyName,
                        BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (propertyInfo ==null)
                    {
                        throw  new Exception($"Property :{propertyName} 没有找到:{typeof(TSource)}");
                    }
                    propertyInfoList.Add(propertyInfo);
                }
            }


            foreach (var obj in source)
            {
                var shapedObj = new ExpandoObject();
                foreach (var propertyInfo in propertyInfoList)
                {
                    var propertyValue = propertyInfo.GetValue(obj);
                    ((IDictionary<string, object>) shapedObj).Add(propertyInfo.Name, propertyValue);
                }
                expandObjectList.Add(shapedObj);
            }

            return expandObjectList;
        }
    }
}