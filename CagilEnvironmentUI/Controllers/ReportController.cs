using CagilEnvironmentUI.Models;
using ClosedXML.Excel;
using DataAccessLayer.Context;
using MessagePack;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace CagilEnvironmentUI.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticReport()
        {
            ExcelPackage excelPackage= new ExcelPackage();
            var workbook = excelPackage.Workbook.Worksheets.Add("Dosya1");

            workbook.Cells[1, 1].Value = "Ürün Adı";
            workbook.Cells[1, 2].Value = "Ürün Kategorisi";
            workbook.Cells[1, 3].Value = "Ürün Stok";

            workbook.Cells[2, 1].Value = "AAA Solar Panel";
            workbook.Cells[2, 2].Value = "Solar Panel";
            workbook.Cells[2, 3].Value = "50 adet";

            workbook.Cells[3, 1].Value = "BBB Solar Panel";
            workbook.Cells[3, 2].Value = "Solar Panel";
            workbook.Cells[3, 3].Value = "20 adet";

            workbook.Cells[4, 1].Value = "CCC Solar Panel";
            workbook.Cells[4, 2].Value = "Solar Panel";
            workbook.Cells[4, 3].Value = "30 adet";

            var bytes = excelPackage.GetAsByteArray();

            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SolarPanelRaporu.xlsx");
        }
        public List<ContactModel> ContactList()
        {
            List<ContactModel> contactModels= new List<ContactModel>();
            using(var context = new CagilEnvironmentContext())
            {
                contactModels = context.Contacts.Select(x => new ContactModel{
                    ContactID= x.ContactID,
                    ContactName=x.Name,
                    ContactDate=x.Date,
                    ContactMail=x.Mail,
                    ContactMessage=x.Message,
                }).ToList();
            }
            return contactModels;
        }
        public IActionResult ContactReport()
        {
            using (var workbook = new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add("Mesaj Listesi");
                workSheet.Cell(1, 1).Value = "Mesaj ID";
                workSheet.Cell(1, 2).Value = "Mesaj Gönderen";
                workSheet.Cell(1, 3).Value = "Mail Adresi";
                workSheet.Cell(1, 4).Value = "Mesaj İçeriği";
                workSheet.Cell(1, 5).Value = "Mesaj Tarihi";

                int contactRowCount = 2;
                foreach (var item in ContactList())
                {
                    workSheet.Cell(contactRowCount, 1).Value = item.ContactID;
                    workSheet.Cell(contactRowCount, 2).Value = item.ContactName;
                    workSheet.Cell(contactRowCount, 3).Value = item.ContactMail;
                    workSheet.Cell(contactRowCount, 4).Value = item.ContactMessage;
                    workSheet.Cell(contactRowCount, 5).Value = item.ContactDate;
                    contactRowCount++;
                }

                using(var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content =stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MesajRaporu.xlsx");
                }
            }
        }
        public List<NewsModel> NewsList()
        {
            List<NewsModel> newsModels = new List<NewsModel>();
            using (var context = new CagilEnvironmentContext())
            {
                newsModels = context.AllNews.Select(x => new NewsModel
                {
                    Id = x.NewsID,
                    Status = x.Status,
                    Date = x.Date,
                    Description = x.Description,
                    Title = x.Title,
                }).ToList();
            }
            return newsModels;
        }
        public IActionResult NewsReport()
        {
            using (var workbook = new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add("Duyuru Listesi");
                workSheet.Cell(1, 1).Value = "Duyuru ID";
                workSheet.Cell(1, 2).Value = "Başlık";
                workSheet.Cell(1, 3).Value = "Tarih";
                workSheet.Cell(1, 4).Value = "İçerik";
                workSheet.Cell(1, 5).Value = "Durum";

                int contactRowCount = 2;
                foreach (var item in NewsList())
                {
                    workSheet.Cell(contactRowCount, 1).Value = item.Id;
                    workSheet.Cell(contactRowCount, 2).Value = item.Title;
                    workSheet.Cell(contactRowCount, 3).Value = item.Date.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
                    workSheet.Cell(contactRowCount, 4).Value = item.Description;
                    workSheet.Cell(contactRowCount, 5).Value = item.Status;
                    contactRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DuyuruRaporu.xlsx");
                }
            }
        }
    }
}
