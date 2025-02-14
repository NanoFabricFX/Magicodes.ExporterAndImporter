﻿// ======================================================================
// 
//           Copyright (C) 2019-2030 湖南心莱信息科技有限公司
//           All rights reserved
// 
//           filename : ImportQuestionBankDto.cs
//           description :
// 
//           created by 雪雁 at  2019-09-26 14:59
//           文档官网：https://docs.xin-lai.com
//           公众号教程：麦扣聊技术
//           QQ群：85318032（编程交流）
//           Blog：http://www.cnblogs.com/codelove/
// 
// ======================================================================

using System.ComponentModel.DataAnnotations;
using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;

namespace Magicodes.ExporterAndImporter.Tests.Models.Import
{
    /// <summary>
    ///     Class Name:QuestionBankSheetDto
    ///     Namespace:Magicodes.Admin.Application.Custom.QuestionBanks.Dto
    ///     Class Function:
    /// </summary>
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for QuestionBankSheetDto
    public class ImportQuestionBankDto
    {
        /// <summary>
        ///     题干
        /// </summary>
        [ImporterHeader(Name = "题干")]
        [Required(ErrorMessage = "题干不能为空")]
        [MaxLength(500, ErrorMessage = "最大长度不能超过500")]
        public string Content { get; set; }

        /// <summary>
        ///     题型
        /// </summary>
        [ImporterHeader(Name = "题型")]
        [Required(ErrorMessage = "题型不能为空")]
        public QuestionTypes Type { get; set; }

        /// <summary>
        ///     难度
        /// </summary>
        [ImporterHeader(Name = "难度")]
        [Required(ErrorMessage = "难度不能为空")]
        public QuestionLevels Level { get; set; }

        /// <summary>
        ///     正确答案
        /// </summary>
        [ImporterHeader(Name = "正确答案")]
        [Required(ErrorMessage = "正确答案不能为空")]
        public string Correct { get; set; }

        /// <summary>
        ///     选项1
        /// </summary>
        [ImporterHeader(Name = "A")]
        [Required(ErrorMessage = "选项A不能为空")]
        public string A { get; set; }

        /// <summary>
        ///     选项2
        /// </summary>
        [ImporterHeader(Name = "B")]
        public string B { get; set; }

        /// <summary>
        ///     选项3
        /// </summary>
        [ImporterHeader(Name = "C")]
        public string C { get; set; }

        /// <summary>
        ///     选项4
        /// </summary>
        [ImporterHeader(Name = "D")]
        public string D { get; set; }

        /// <summary>
        ///     选项5
        /// </summary>
        [ImporterHeader(Name = "E")]
        public string E { get; set; }

        /// <summary>
        ///     选项6
        /// </summary>
        [ImporterHeader(Name = "F")]
        public string F { get; set; }

        /// <summary>
        ///     选项7
        /// </summary>
        [ImporterHeader(Name = "G")]
        public string G { get; set; }

        /// <summary>
        ///     选项8
        /// </summary>
        [ImporterHeader(Name = "H")]
        public string H { get; set; }

        /// <summary>
        ///     选项是否支持乱序
        /// </summary>
        [ImporterHeader(Name = "选项是否支持乱序")]
        [Required(ErrorMessage = "选项是否支持乱序不能为空")]
        [ValueMapping(text: "对", value: true)]
        [ValueMapping(text: "错", value: false)]
        [ValueMapping(text: "是", value: true)]
        [ValueMapping(text: "否", value: false)]
        public bool IsDisorderly { get; set; }

        /// <summary>
        ///     解析
        /// </summary>
        [ImporterHeader(Name = "解析")]
        [MaxLength(2000, ErrorMessage = "最大长度不能超过2000")]
        public string Analyze { get; set; }

        /// <summary>
        ///     知识点
        /// </summary>
        [ImporterHeader(Name = "知识点")]
        [MaxLength(200, ErrorMessage = "最大长度不能超过200")]
        public string Knowledge { get; set; }

        /// <summary>
        ///     关键字
        /// </summary>
        [ImporterHeader(Name = "关键字")]
        [MaxLength(200, ErrorMessage = "最大长度不能超过200")]
        public string KeyWord { get; set; }
    }

    /// <summary>
    ///     问题等级
    /// </summary>
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for QuestionLevel
    public enum QuestionLevels
    {
        /// <summary>
        ///     低
        /// </summary>
        [Display(Name = "低难度")] LowLevel = 0,

        /// <summary>
        ///     中
        /// </summary>
        [Display(Name = "中难度")] MiddleLevel = 1,

        /// <summary>
        ///     高
        /// </summary>
        [Display(Name = "高难度")] HighLevel = 2
    }

    /// <summary>
    ///     问题类型
    /// </summary>
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for QuestionType
    public enum QuestionTypes
    {
        /// <summary>
        ///     单选
        /// </summary>
        [Display(Name = "单选题")] Radio = 1,

        /// <summary>
        ///     多选
        /// </summary>
        [Display(Name = "多选题")] Check = 2,

        /// <summary>
        ///     判断
        /// </summary>
        [Display(Name = "判断题")] Judge = 3
    }
}