using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Text;

/**************************************************************************
*
*   CLR 版本    ：4.0.30319.42000
*   系统版本    ：V1.0.0
*   创 建 者    ：詹建妹 (JameZhan@aliyun.com)
*   功能描述    ：
*  
***************************************************************************/
namespace TPCOMMGER.Framework
{
    /// <summary>
    /// 动态实体
    /// </summary>
    public sealed class DynamicEntity : DynamicObject, INotifyPropertyChanged
    {
        public Dictionary<string, object> DynamicValues;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DynamicEntity()
        {
            DynamicValues = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 取值/赋值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[string key]
        {
            set
            {
                SetPropertyValue(key, value);
            }
            get
            {
                return GetPropertyValue(key);
            }
        }

        /// <summary>
        /// 键集合
        /// </summary>
        public IEnumerable<string> Keys => DynamicValues.Keys;

        /// <summary>
        /// 值集合
        /// </summary>
        public IEnumerable<object> Values => DynamicValues.Values;

        /// <summary>
        /// 数量
        /// </summary>
        public int Count => DynamicValues.Count;

        /// <summary>
        /// 是否包含键
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public bool ContainsKey(string propertyName) => DynamicValues.ContainsKey(propertyName);

        /// <summary>
        /// 是否包含值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsValue(object value) => DynamicValues.ContainsValue(value);

        /// <summary>
        /// 移除数据
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public bool Remove(string propertyName) => DynamicValues.Remove(propertyName);

        //public bool Remove(string propertyName, out object value) => DynamicValues.Remove(propertyName, out value);

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="ordinalIgnoreCase">是否忽略大小写：默认忽略</param>
        /// <returns></returns>
        private object GetPropertyValue(string propertyName)
        {
            if (DynamicValues.ContainsKey(propertyName) == true)
                return DynamicValues[propertyName];
            else
                return null;
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        private void SetPropertyValue(string propertyName, object obj)
        {
            if (DynamicValues.ContainsKey(propertyName) == true)
            {
                DynamicValues[propertyName] = obj;
            }
            else
            {
                DynamicValues.Add(propertyName, obj);
            }
            RaisePropertyChanged(propertyName);
        }

        #region 重写

        /// <summary>
        /// 实现动态对象属性成员访问的方法，得到返回指定属性的值
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = GetPropertyValue(binder.Name);
            return result != null;
        }

        /// <summary>
        /// 实现动态对象属性值设置的方法。
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            SetPropertyValue(binder.Name, value);
            return true;
        }

        /// <summary>
        /// 动态对象动态方法调用时执行的实际代码
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="args"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            DelegateObj theDelegateObj = GetPropertyValue(binder.Name) as DelegateObj;
            if (theDelegateObj == null || theDelegateObj.CallMethod == null)
            {
                result = null;
                return false;
            }
            result = theDelegateObj.CallMethod(this, args);
            return true;
        }

        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            return base.TryInvoke(binder, args, out result);
        }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
