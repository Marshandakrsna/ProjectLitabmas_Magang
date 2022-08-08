using Microsoft.AspNetCore.Mvc;

using SiLPPM_New_Version.DAO;
using System.Linq;
using System.Security.Claims;
using System.Dynamic;
using System.IO;

namespace SiLPPM_New_Version.Controllers
{

    public class HistoryController : Controller
    {
        PenelitianDAO penelitianDAO;
        PengabdianDAO myPengabdian;
        dynamic myobj;


        public HistoryController()
        {
            myobj = new ExpandoObject();
            penelitianDAO = new PenelitianDAO();
            myPengabdian = new PengabdianDAO();
        }
        [HttpGet("PreviewFileProposalDisplay/{ID_PROPOSAL}")]
        public ActionResult PreviewFile(int ID_PROPOSAL)
        {
            var preview = penelitianDAO.GetDokumenProposal(ID_PROPOSAL);

            byte[] fileContent = preview;
            MemoryStream pdfStream = new MemoryStream();
            pdfStream.Write(fileContent, 0, fileContent.Length);
            pdfStream.Position = 0;

            return File(fileContent, "application/pdf", "Proposal Penelitian.pdf");
        }
        [HttpGet("PreviewFileDraftPenelitian/{ID_PROPOSAL}")]
        public ActionResult PreviewFileDraft(int ID_PROPOSAL)
        {
            var preview = penelitianDAO.GetDraftPenelitian(ID_PROPOSAL);
          
            byte[] fileContent = preview;
            MemoryStream pdfStream = new MemoryStream();
            pdfStream.Write(fileContent, 0, fileContent.Length);
            pdfStream.Position = 0;

            return File(fileContent, "application/pdf", "Draft Penelitian.pdf");
        }

        [HttpGet("PreviewFileLaporanPenelitian/{ID_PROPOSAL}")]
        public ActionResult PreviewFileLaporan(int ID_PROPOSAL)
        {
            var preview = penelitianDAO.GetLaporanPenelitian(ID_PROPOSAL);

            byte[] fileContent = preview;
            MemoryStream pdfStream = new MemoryStream();
            pdfStream.Write(fileContent, 0, fileContent.Length);
            pdfStream.Position = 0;

            return File(fileContent, "application/pdf", "Laporan Penelitian.pdf");
        }
       

        public IActionResult AdminDisplayHistory(int ID_PROPOSAL)
        {
            var preview = penelitianDAO.GetDataPen(ID_PROPOSAL);
            var preview2 = penelitianDAO.GetDataPenLOLOS(ID_PROPOSAL);
         
            var HistoryPenelitian = penelitianDAO.GetHistoryExec();
            myobj.preview = preview.data;
            myobj.preview2 = preview2.data;
            
            myobj.HistoryPenelitian = HistoryPenelitian.data;
            return View(myobj);
        }
        public IActionResult AdminDisplayHistoryPengabdian()
        {
            var HistoryPengabdian = penelitianDAO.GetHistoryExecPengabdian();
            myobj.HistoryPengabdian = HistoryPengabdian.data;
            return View(myobj);
        }
    }
}
