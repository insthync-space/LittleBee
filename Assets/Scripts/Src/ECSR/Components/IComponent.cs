﻿namespace Components
{
    /// <summary>
    /// 组件数据
    /// </summary>
    public interface IComponent
    {
        string EntityId { set; get; }

        bool Enable { set; get; }
        IComponent Clone();
        int GetCommand();
    }

    /// <summary>
    /// 参数可更新
    /// </summary>
    public interface IParamsUpdatable
    {
        void UpdateParams(string[] paramsStrs);
    }
}