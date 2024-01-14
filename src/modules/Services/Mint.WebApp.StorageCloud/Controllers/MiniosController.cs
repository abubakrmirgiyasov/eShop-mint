using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Mint.WebApp.StorageCloud.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Mint.WebApp.StorageCloud.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class MiniosController(IStorageCloudService storageService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetSingleImage(
        [FromQuery, Required] string bucket,
        [FromQuery, Required] string name,
        CancellationToken cancellationToken = default)
    {
        return Ok(await storageService.GetFileLinkAsync(name, bucket, cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult> Create(
        [FromForm] Models.StorageCloud storageCloud,
        CancellationToken cancellationToken = default)
    {
        await storageService.UploadFileAsync(storageCloud.File, storageCloud.Bucket, cancellationToken);
        return NoContent();
    }

    [HttpGet("{age:int}")]
    public FileResult CreateSimpleExcel(int age)
    {
        var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Home");
        var worksheet2 = workbook.Worksheets.Add("Example");

        worksheet.Cell("A1").Value = "FirstName";
        worksheet.Cell("B1").Value = "Last Name";
        worksheet.Cell("C1").Value = "Middle Name";
        worksheet.Cell("D1").Value = "Age";

        worksheet.Cell("A2").Value = "Ivanov";
        worksheet.Cell("B2").Value = "Ivan";
        worksheet.Cell("D2").Value = "23";

        worksheet.Cell("D2").Style.Fill.BackgroundColor = age > 18 ? XLColor.GreenPigment : XLColor.RedPigment;
        worksheet.Cell("D2").Style.Font.FontColor = XLColor.White;

        worksheet.Columns().AdjustToContents();

        var range = worksheet2.Range("A1:G" + 10);
        range.Style.Border.RightBorder = XLBorderStyleValues.Thin;
        range.Style.Border.BottomBorder = XLBorderStyleValues.Thin;

        using var stream = new MemoryStream();

        workbook.SaveAs(stream);
        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Base.xlsx");
    }
}
