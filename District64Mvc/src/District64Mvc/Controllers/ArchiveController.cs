using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using District64.District64Mvc.Models;
using District64.District64Mvc.Models.Archive;
using District64.District64Mvc.Models.Archive.Domain;
using MVC.Controls;
using MVC.Controls.Grid;



namespace District64.District64Mvc.Controllers
{
    public class ArchiveController : Controller    {
        
        IArchiveModel _archiveModel;

        /// <summary>
        /// Default Constructor
        /// injects a new ArchiveModel
        /// </summary>
        public ArchiveController() : this(new ArchiveModel())
        {
        }

        /// <summary>
        /// Parameterized Constructor
        /// mainly used for UNIT testing
        /// </summary>
        /// <param name="model">Injected Model</param>
        public ArchiveController(IArchiveModel model)
        {
            _archiveModel = model;
        }

        #region Actions

        /// <summary>
        /// Index Action call for archive route
        /// </summary>
        /// <returns>Default View</returns>
        [HttpGet]
        public ActionResult Index()
        {
            LoadTypeList();
            LoadSearchCookies();
            return View(); 
        }

        /// <summary>
        /// Archive Search *Post*
        /// </summary>
        /// <param name="search">Search Model</param>
        /// <returns>Index View with possible provided searches</returns>
        [HttpPost]
        [District64Mvc.Models.Attributes.DistrictCustomerAuthorization]
        public ActionResult Search(ArchiveSearch search)
        {
            if (ModelState.IsValid)
            {
                //ViewData[District64MvcConstants.VIEW_DATA_ARCHIVE_LIST] = _archiveModel.GetArchiveItemList(search);
                ViewData["SearchParams"] = search;
                DoSearchCookies(search);
            }
            
            LoadTypeList();
            return View("Index");

        }

        /// <summary>
        /// This action sole purpose is to provide data
        /// to the MVC grid control based on the selected 
        /// posted query info
        /// </summary>
        /// <param name="search">The Search Param</param>
        /// <param name="page">which page the current grid is displaying</param>
        /// <param name="rows">number of rows</param>
        /// <param name="sidx"></param>
        /// <param name="sord">Sort order</param>
        /// <returns>Json action result</returns>
        [HttpGet]
        public ActionResult List(ArchiveSearch search, int page, int rows, string sidx, string sord)
        {
            List<ArchiveItem> archiveItems = _archiveModel.GetArchiveItemList(search);
            var model = archiveItems.AsQueryable().OrderBy(sidx + " " + sord);
            return Json(model.ToGridData(page, rows, null, "", new[] { "ArchiveReposIdField", "ArchiveReposLongDescField", "ArchiveReposShortDescField", "ArchiveTypeName", "DistrictNumberField" }), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// PDFView returns a memory stream with the 
        /// service provided byte array
        /// </summary>
        /// <param name="archiveId">The ArchiveId for the provided search selection</param>
        /// <returns>FileStream for File Byte Array</returns>
        [HttpGet]
        public FileStreamResult PDFView(long archiveId)
        {
            ArchiveItem item = _archiveModel.GetArchiveItemFile(archiveId);

            Stream fileStream = new MemoryStream(item.FileByteArray);

            HttpContext.Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", item.FileName));

            return new FileStreamResult(fileStream, "application/pdf");
        }

        /// <summary>
        /// Get the Archive Id inteded to be used
        /// in the embeded pdf reader data route
        /// </summary>
        /// <param name="archiveId">Provided Id from selection to be returned for new View</param>
        /// <returns>Embbeded PDF View</returns>
        [HttpPost]
        public ActionResult PDFEmbededView(long archiveId)
        {
            ViewData[District64MvcConstants.VIEW_DATA_ARCHIVE_ID] = archiveId;
            return View();            
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Loads Type list to be used by multiple views
        /// </summary>
        private void LoadTypeList()
        {
            ViewData[District64MvcConstants.VIEW_DATA_TYPE_LIST] = new SelectList(_archiveModel.GetArchiveTypeVOList(), 
                District64MvcConstants.OJBECT_PROP_ARCHIVE_VALUE, District64MvcConstants.OBJECT_PROP_ARCHIVE_NAME);
        }

        /// <summary>
        /// Loads the stored Cookies for Search Fields
        /// </summary>
        private void LoadSearchCookies()
        {
            CookieFactory factory = new CookieFactory();
            ArchiveSearch search = new ArchiveSearch();

            search.ArchiveType = factory.ReadInt32Cookie(District64MvcConstants.COOKIE_ARCHIVE_TYPE, Request);
            search.Description = factory.ReadCookie(District64MvcConstants.COOKIE_DESCRIPTION, Request);
            search.District = factory.ReadInt32Cookie(District64MvcConstants.COOKIE_DISTRICT_NUMBER, Request);
            search.FromYear = factory.ReadCookie(District64MvcConstants.COOKIE_FROM_YEAR, Request);
            search.ToYear = factory.ReadCookie(District64MvcConstants.COOKIE_TO_YEAR, Request);
            ViewData.Model = search;
        }

        /// <summary>
        /// Method to store search cookies on client 
        /// *Note* if using localhost must provided url in the System32/driver/ect/hosts
        /// this will allow the local devel to provide a none "localhost:9999" domain name
        /// *example*
        /// 127.0.0.1 localhost
        /// 127.0.0.1 test1.District64.com
        /// </summary>
        /// <param name="search">ArchiveSearch Model posted from client</param>
        private void DoSearchCookies(ArchiveSearch search)
        {
            CookieFactory factory = new CookieFactory();

            Response.AppendCookie(factory.GenerateCookie(District64MvcConstants.COOKIE_ARCHIVE_TYPE, search.ArchiveType));
            Response.AppendCookie(factory.GenerateCookie(District64MvcConstants.COOKIE_DESCRIPTION, search.Description));
            Response.AppendCookie(factory.GenerateCookie(District64MvcConstants.COOKIE_DISTRICT_NUMBER, search.District));
            Response.AppendCookie(factory.GenerateCookie(District64MvcConstants.COOKIE_FROM_YEAR, search.FromYear));
            Response.AppendCookie(factory.GenerateCookie(District64MvcConstants.COOKIE_TO_YEAR, search.ToYear));

        }

        #endregion
    }
}
