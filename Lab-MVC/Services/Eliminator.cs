using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Lab_MVC.Services
{
    public class Eliminator
    {
        /// <summary>
        /// 消除空白
        /// </summary>
        /// <param name="obj">物件</param>
        public T EliminateSpace<T>(T obj)
        {
            if (obj != null)
            {
                PropertyInfo[] properites = obj.GetType().GetProperties();
                foreach (var property in properites)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        if (property.GetValue(obj) != null)
                        {
                            var value = property.GetValue(obj).ToString();
                            property.SetValue(obj, value.Trim());
                        }
                    }
                }
                return obj;
            }
            else
            {
                return default(T);
            }
        }
    }
}