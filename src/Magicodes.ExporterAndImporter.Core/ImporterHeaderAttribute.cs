﻿// ======================================================================
// 
//           Copyright (C) 2019-2030 湖南心莱信息科技有限公司
//           All rights reserved
// 
//           filename : ImporterHeaderAttribute.cs
//           description :
// 
//           created by 雪雁 at  2019-09-11 13:51
//           文档官网：https://docs.xin-lai.com
//           公众号教程：麦扣聊技术
//           QQ群：85318032（编程交流）
//           Blog：http://www.cnblogs.com/codelove/
// 
// ======================================================================

using System;

namespace Magicodes.ExporterAndImporter.Core
{
    /// <summary>
    /// 导入头部特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ImporterHeaderAttribute : Attribute
    {
        /// <summary>
        ///     显示名称
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        ///     批注
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        ///     作者
        /// </summary>
        public string Author { set; get; } = "麦扣";

        /// <summary>
        ///     自动过滤空格，默认启用
        /// </summary>
        public bool AutoTrim { get; set; } = true;

        /// <summary>
        ///     处理掉所有的空格，包括中间空格
        /// </summary>
        public bool FixAllSpace { get; set; }

        /// <summary>
        ///     列索引，如果为0则自动计算
        /// </summary>
        public int ColumnIndex { get; set; }

        /// <summary>
        /// 是否允许重复
        /// </summary>
        public bool IsAllowRepeat { get; set; } = true;

        /// <summary>
        ///     是否忽略
        /// </summary>
        public bool IsIgnore { get; set; }
    }
}