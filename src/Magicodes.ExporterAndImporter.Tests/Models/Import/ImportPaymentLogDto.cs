﻿using System;
using System.ComponentModel.DataAnnotations;
using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;

namespace Magicodes.ExporterAndImporter.Tests.Models.Import
{
    /// <summary>
    /// 缴费日志导入Dto
    /// </summary>
    /// <autogeneratedoc />
    [ExcelImporter(IsLabelingError = true)]
    public class ImportPaymentLogDto
    {
        /// <summary>
        /// 学生姓名
        /// </summary>
        [ImporterHeader(Name = "学生姓名")]
        [Required(ErrorMessage = "学生姓名为必填项")]
        [MaxLength(30,ErrorMessage = "学生姓名不能超过15位")]
        public string Name { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        [ImporterHeader(Name = "身份证号码")]
        [Required(ErrorMessage = "身份证号码为必填项")]
        [MaxLength(18,ErrorMessage = "身份证号码不能超过18位")]
        [MinLength(18,ErrorMessage = "身份证号码不能小于18位")]
        public string IdCard { get; set; }

        /// <summary>
        /// 缴费类型
        /// </summary>
        [ImporterHeader(Name = "缴费类型")]
        [Required(ErrorMessage = "缴费类型为必填项")]
        public string CostType { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [ImporterHeader(Name = "金额")]
        [Range(0.01, 1000000, ErrorMessage = "收费金额区间为1~100万")]
        [Required(ErrorMessage = "金额为必填项")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 缴费日期
        /// </summary>
        [ImporterHeader(Name = "缴费日期")]
        [MaxLength(8,ErrorMessage = "缴费日期不能超过8位")]
        [RegularExpression("\\d{6,8}",ErrorMessage = "缴费日期只能输入6到8位数字例如201908/20190815")]
        public string PayDate { get; set; }

        /// <summary>
        /// 收据编号
        /// 多个使用逗号分隔，仅线下收据
        /// </summary>
        [ImporterHeader(Name = "收据编号")]
        [MaxLength(200,ErrorMessage = "收据编号不能超过200位")]
        public string ReceiptCodes { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [ImporterHeader(Name = "备注")]
        [MaxLength(500,ErrorMessage = "备注不能超过500位")]
        public string Remarks { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [ImporterHeader(IsIgnore = true)]
        public DateTime? CreationTime { get; set; }

        /// <summary>
        /// 收费项目id
        /// </summary>
        [ImporterHeader(IsIgnore = true)]
        public int? ChargeProjectId { get; set; }

        /// <summary>
        /// 班级Id
        /// </summary>
        [ImporterHeader(IsIgnore = true)]
        public Guid? ClassId { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        [ImporterHeader(IsIgnore = true)]
        public string ClassName { get; set; }

        /// <summary>
        /// 年级Id
        /// </summary>
        [ImporterHeader(IsIgnore = true)]
        public Guid? GradeId { get; set; }
        /// <summary>
        /// 年级信息
        /// </summary>
        [ImporterHeader(IsIgnore = true)]
        public string GradeName { get; set; }

        /// <summary>
        /// 专业Id
        /// </summary>
        [ImporterHeader(IsIgnore = true)]
        public Guid? MajorId { get; set; }

        /// <summary>
        /// 专业信息
        /// </summary>
        [ImporterHeader(IsIgnore = true)]
        public string MajorName { get; set; }

        /// <summary>
        /// 校区Id
        /// </summary>
        [ImporterHeader(IsIgnore = true)]
        public Guid? CampusId { get; set; }

        /// <summary>
        /// 校区名称
        /// </summary>
        [ImporterHeader(IsIgnore = true)]
        public string CampusName { get; set; }

        /// <summary>
        /// 学校Id
        /// </summary>
        [ImporterHeader(IsIgnore = true)]
        public Guid? SchoolId { get; set; }

        /// <summary>
        /// 学校信息
        /// </summary>
        [ImporterHeader(IsIgnore = true)]
        public string SchoolName { get; set; }
    }
}
