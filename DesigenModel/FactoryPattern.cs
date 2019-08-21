using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{

    /*
     * 简单工厂模式
     */

    /// <summary>
    /// 产品抽象 
    /// </summary>
    public interface IProduct
    {
        void Operation();
    }


    /// <summary>
    /// 具体的产品
    /// </summary>
    public class ProductA : IProduct
    {
        public void Operation()
        {
            //A的方法
            throw new NotImplementedException();
        }
    }

    public class ProductB : IProduct
    {
        public void Operation()
        {
            //B的方法
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 工厂类 负责创建对应的对象
    /// </summary>
    public class Factory
    {
        public IProduct Create(string productName)
        {
            switch (productName)
            {
                case "A":
                    return new ProductA();
                case "B":
                    return new ProductB();
                default:
                    return null;
            }
        }
    }



}
