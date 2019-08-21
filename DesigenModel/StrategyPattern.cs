using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    /*
     * 策略模式
     */


    /// <summary>
    /// 策略的抽象
    /// </summary>
    public interface IStrategy
    {
        object Operation();
    }


    /// <summary>
    /// 拥有这种策略的类
    /// </summary>
    public class Context
    {
        ///私有的具体的策略对象
        private IStrategy _strategy = null;

        /// <summary>
        /// 执行策略
        /// </summary>
        /// <returns></returns>
        public object Execute()
        {
            return this._strategy.Operation();
        }
    }


}
