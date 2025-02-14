// ======================================================================
// 
//           Copyright (C) 2019-2030 湖南心莱信息科技有限公司
//           All rights reserved
// 
//           filename : ExcelExporter_Tests.cs
//           description :
// 
//           created by 雪雁 at  2019-09-11 13:51
//           文档官网：https://docs.xin-lai.com
//           公众号教程：麦扣聊技术
//           QQ群：85318032（编程交流）
//           Blog：http://www.cnblogs.com/codelove/
// 
// ======================================================================

using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;
using Magicodes.ExporterAndImporter.Excel.Builder;
using Magicodes.ExporterAndImporter.Tests.Models;
using Shouldly;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Magicodes.ExporterAndImporter.Tests.Models.Export;
using Xunit;

namespace Magicodes.ExporterAndImporter.Tests
{
    public class ExcelExporter_Tests : TestBase
    {
        [Fact(DisplayName = "特性导出")]
        public async Task AttrsExport_Test()
        {
            IExporter exporter = new ExcelExporter();

            var filePath = GetTestFilePath($"{nameof(AttrsExport_Test)}.xlsx");

            DeleteFile(filePath);

            var result = await exporter.Export(filePath,
                GenFu.GenFu.ListOf<ExportTestDataWithAttrs>());
            result.ShouldNotBeNull();
            File.Exists(filePath).ShouldBeTrue();
        }

        [Fact(DisplayName = "ExportAsByteArray_Test")]
        public async Task ExportAsByteArray_Test()
        {
            IExporter exporter = new ExcelExporter();

            var filePath = GetTestFilePath($"{nameof(ExportAsByteArray_Test)}.xlsx");

            DeleteFile(filePath);

            var result = await exporter.ExportAsByteArray(GenFu.GenFu.ListOf<ExportTestDataWithAttrs>());
            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(0);
            await File.WriteAllBytesAsync(filePath, result);
            File.Exists(filePath).ShouldBeTrue();
        }

        [Fact(DisplayName = "ExportHeaderAsByteArrayWithItems_Test")]
        public async Task ExportHeaderAsByteArrayWithItems_Test()
        {
            IExporter exporter = new ExcelExporter();

            var filePath = GetTestFilePath($"{nameof(ExportHeaderAsByteArrayWithItems_Test)}.xlsx");

            DeleteFile(filePath);

            var result = await exporter.ExportHeaderAsByteArray(new string[] { "Name1", "Name2", "Name3", "Name4", "Name5", "Name6", }, "Test");
            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(0);
            await File.WriteAllBytesAsync(filePath, result);
            File.Exists(filePath).ShouldBeTrue();
            //TODO:Excel读取并验证
        }

        [Fact(DisplayName = "ExportHeaderAsByteArray_Test")]
        public async Task ExportHeaderAsByteArray_Test()
        {
            IExporter exporter = new ExcelExporter();

            var filePath = GetTestFilePath($"{nameof(ExportHeaderAsByteArray_Test)}.xlsx");

            DeleteFile(filePath);

            var result = await exporter.ExportHeaderAsByteArray<ExportTestDataWithAttrs>(GenFu.GenFu.New<ExportTestDataWithAttrs>());
            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(0);
            await File.WriteAllBytesAsync(filePath, result);
            File.Exists(filePath).ShouldBeTrue();
        }

        [Fact(DisplayName = "多语言特性导出")]
        public async Task AttrsLocalizationExport_Test()
        {
            IExporter exporter = new ExcelExporter();
            ExcelBuilder.Create().WithColumnHeaderStringFunc(key =>
            {
                if (key.Contains("文本"))
                {
                    return "Text";
                }

                return "未知语言";
            }).Build();

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "testAttrsLocalization.xlsx");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            var data = GenFu.GenFu.ListOf<AttrsLocalizationTestData>();
            var result = await exporter.Export(filePath, data);
            result.ShouldNotBeNull();
            File.Exists(filePath).ShouldBeTrue();
        }

        [Fact(DisplayName = "大量数据导出Excel")]
        public async Task Export_Test()
        {
            IExporter exporter = new ExcelExporter();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), nameof(Export_Test) + ".xlsx");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            var result = await exporter.Export(filePath, GenFu.GenFu.ListOf<ExportTestData>(100000));
            result.ShouldNotBeNull();
            File.Exists(filePath).ShouldBeTrue();
        }

        [Fact(DisplayName = "动态列导出Excel")]
        public async Task DynamicExport_Test()
        {
            IExporter exporter = new ExcelExporter();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), nameof(DynamicExport_Test) + ".xlsx");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            List<ExportTestDataWithAttrs> exportDatas = GenFu.GenFu.ListOf<ExportTestDataWithAttrs>(1000);

            DataTable dt = new DataTable();
            //2.创建带列名和类型名的列(两种方式任选其一)
            dt.Columns.Add("Text", System.Type.GetType("System.String"));
            dt.Columns.Add("Name", System.Type.GetType("System.String"));
            dt.Columns.Add("Number", System.Type.GetType("System.Decimal"));
            dt = EntityToDataTable<ExportTestDataWithAttrs>(dt, exportDatas);

            var result = await exporter.Export<ExportTestDataWithAttrs>(filePath,dt);
            result.ShouldNotBeNull();
            File.Exists(filePath).ShouldBeTrue();
        }

        [Fact(DisplayName = "大数据动态列导出Excel")]
        public async Task LargeDataDynamicExport_Test()
        {
            IExporter exporter = new ExcelExporter();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), nameof(LargeDataDynamicExport_Test) + ".xlsx");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            List<ExportTestDataWithAttrs> exportDatas = GenFu.GenFu.ListOf<ExportTestDataWithAttrs>(1200000);

            DataTable dt = new DataTable();
            //创建带列名和类型名的列
            dt.Columns.Add("Text", System.Type.GetType("System.String"));
            dt.Columns.Add("Name", System.Type.GetType("System.String"));
            dt.Columns.Add("Number", System.Type.GetType("System.Decimal"));
            dt = EntityToDataTable<ExportTestDataWithAttrs>(dt, exportDatas);

            var result = await exporter.Export<ExportTestDataWithAttrs>(filePath, dt);
            result.ShouldNotBeNull();
            File.Exists(filePath).ShouldBeTrue();
        }

        /// <summary>
        /// 将entities直接转成DataTable
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="entities">entity集合</param>
        /// <returns>将Entity的值转为DataTable</returns>
        private static DataTable EntityToDataTable<T>(DataTable dt, IEnumerable<T> entities)
        {
            if (entities.Count() == 0)
            {
                return dt;
            }

            var properties = typeof(T).GetProperties();

            foreach (var entity in entities)
            {
                var dr = dt.NewRow();

                foreach (var property in properties)
                {
                    if (dt.Columns.Contains(property.Name))
                    {
                        dr[property.Name] = property.GetValue(entity, null);
                    }
                }

                dt.Rows.Add(dr);
            }

            return dt;
        }
    }
}