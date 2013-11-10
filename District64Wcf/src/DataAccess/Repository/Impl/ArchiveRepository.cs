using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using District64.District64Wcf.Domain.Entities;
using District64.District64Wcf.Domain.Enums;
using District64.District64Wcf.DataAccess.Dao;
using District64.District64Wcf.Domain.Criterions.Impl;
using District64.District64Wcf.Domain.Criterions;

namespace District64.District64Wcf.DataAccess.Repository.Impl
{
    /// <summary>
    /// Archive Repository pattern implamentation
    /// for managing the Arhive entity pattern
    /// </summary>
    public class ArchiveRepository : IArchiveRepository    {

        private ObjectContext _context;
        private IFileDao _fileDao;
        private System.IO.Stream _stream;
        public System.IO.Stream Stream
        {
            set { _stream = value; }
        }

        private const string ARCHIVE_TABLE_QUERY = "[archive_repos]";
        private const string CONTEXT_SET_NAME = "archive_repos";

        /// <summary>
        /// Default constructor
        /// </summary>
        public ArchiveRepository() { }

        /// <summary>
        /// Parameterized constructor with context injection
        /// </summary>
        /// <param name="context">Context, typically Database context
        /// but could be MOCK or other type of context</param>
        public ArchiveRepository(ObjectContext context, IFileDao fileDao)
        {
            _context = context;
            _fileDao = fileDao;
        }

        #region IRespository<ArchiveItem> Members        

        /// <summary>
        /// Reads unique entity based on ID
        /// </summary>
        /// <param name="id">ID or PK of entity</param>
        /// <returns>Archive Item entity</returns>
        public ArchiveItem Read(long id)
        {
            archive_repos result = _context.CreateQuery<archive_repos>(ARCHIVE_TABLE_QUERY)
                .Where(x => x.archive_repos_id == id).First();

            ArchiveItem item = LoadItem(result, false);

            return item;
        }

        /// <summary>
        /// Saves or Updates Entity to injected context 
        /// and decides insert/update based on provided trasient id
        /// </summary>
        /// <param name="transient">The entity wished to be persisted</param>
        /// <returns>The persisted entity</returns>
        public long SaveOrUpdate(ArchiveItem transient)
        {
            IQueryable<archive_repos> result = _context.CreateQuery<archive_repos>(ARCHIVE_TABLE_QUERY)
                .Where(x => x.archive_repos_id == transient.ArchiveReposId);

            archive_repos aro = null;
            if (result.Count() > 0)
            {
                aro = Update(transient, result.First<archive_repos>());
            }
            else
            {
                aro = Create(transient);
                _context.AddObject(CONTEXT_SET_NAME, aro);
            }

            _context.SaveChanges();

            return aro.archive_repos_id;
        }

        /// <summary>
        /// Finds entity based on provided criterion
        /// </summary>
        /// <param name="criteria">Field filter list</param>
        /// <returns>List of lazy loaded ArchiveItem entities 
        /// *Note* file information is not loaded in this method</returns>
        public List<ArchiveItem> Find(ArchiveCriterion criteria)
        {
            IQueryable<archive_repos> objectQuery = _context.CreateQuery<archive_repos>(ARCHIVE_TABLE_QUERY);


            if (criteria.Type.HasValue)
            {
                int typeId = ArchiveTypeEnum.ConvertFromType(criteria.Type.Value);
                objectQuery = objectQuery.Where(x => x.archive_repos_type_id == typeId);
            }
            if (criteria.BeginYear.HasValue)
                objectQuery = objectQuery.Where(x => x.archive_year >= criteria.BeginYear.Value);
            if (criteria.EndYear.HasValue)
                objectQuery = objectQuery.Where(x => x.archive_year <= criteria.EndYear.Value);
            if (criteria.IsFeatured)
                objectQuery = objectQuery.Where(x => x.featured_item_flag == 1);
            if (criteria.DistrictNumber.HasValue)
                objectQuery = objectQuery.Where(x => x.district_number == criteria.DistrictNumber.Value);
            if (criteria.Description != null && criteria.Description.Trim().Length > 0)
                objectQuery = objectQuery.Where(x=> x.archive_repos_long_desc.ToLower().Contains(criteria.Description.ToLower()) 
                    | x.archive_repos_short_desc.ToLower().Contains(criteria.Description.ToLower()));

            List<ArchiveItem> ret = new List<ArchiveItem>();
            
            foreach (archive_repos ar in objectQuery.ToList())
            {
                ret.Add(LoadItem(ar, true));
            }

            return ret;
        }


        #endregion 

        #region internals       

        internal ArchiveItem LoadItem(archive_repos result, bool lazyLoad)
        {
            ArchiveItem item = new ArchiveItem();
            item.ArchiveReposId = result.archive_repos_id;
            item.ArchiveReposShortDesc = result.archive_repos_short_desc;
            item.ArchiveReposLongDesc = result.archive_repos_long_desc;
            item.Year = result.archive_year;
            item.IsFeaturedItem = result.featured_item_flag == 1;
            item.IsValidStatus = result.status_flag == 1;
            item.DistrictNumber = result.district_number;
            item.FilePath = result.file_path;

            if (!lazyLoad)
            {
                result.file_repositoryReference.Load();

                if (result.file_repositoryReference.IsLoaded && result.file_repository != null)
                {
                    ArchiveFile archiveFile = new ArchiveFile()
                    {
                        ByteArray = result.file_repository.file_blob,
                        FileId = result.file_repository.file_repository_id,
                        FileName = result.file_repository.file_name
                    };

                    item.File = archiveFile;
                }
            }

            if (!lazyLoad && result.file_path != null && result.file_path.Trim().Length > 0)
            {                
                String path = result.file_path;
                if (!System.IO.File.Exists(path)) { throw new ApplicationException("File does not exist!  >>>>>>>> " + result.file_path + " <<<<<<<<"); }
                if (_stream == null) { _stream = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read); }
                item.File = _fileDao.ReadFile(_stream, path);
                try
                {
                    _stream.Close();
                }
                catch (Exception)
                {
                }
            }

            ArchiveTypeEnum.ArchiveType type = ArchiveTypeEnum.ConvertFromCode(result.archive_repos_type_id);
            item.ArchiveType = type;
            return item;
        }

        internal archive_repos Update(ArchiveItem transient, archive_repos archiveRepos)        {            
                
                archiveRepos.archive_repos_long_desc = transient.ArchiveReposLongDesc;
                archiveRepos.archive_repos_short_desc = transient.ArchiveReposShortDesc;
                archiveRepos.archive_repos_type_id = ArchiveTypeEnum.ConvertFromType(transient.ArchiveType);
                archiveRepos.archive_year = transient.Year;
                archiveRepos.featured_item_flag = transient.IsFeaturedItem ? 1 : 0;
                archiveRepos.row_updated_by_user_id = transient.User;
                archiveRepos.district_number = transient.DistrictNumber;
                archiveRepos.file_path = transient.FilePath;

                archiveRepos.file_repositoryReference.Load();

                if (archiveRepos.file_repositoryReference.IsLoaded && archiveRepos.file_repository != null)
                {
                    archiveRepos.file_repository.file_name = transient.File.FileName;
                    archiveRepos.file_repository.file_blob = transient.File.ByteArray;
                }                

                return archiveRepos;
        }

        internal archive_repos Create(ArchiveItem transient)
        {
            archive_repos archiveRepos = new archive_repos()
            {
                archive_repos_long_desc = transient.ArchiveReposLongDesc,
                archive_repos_short_desc = transient.ArchiveReposShortDesc,
                archive_repos_type_id = ArchiveTypeEnum.ConvertFromType(transient.ArchiveType),
                archive_year = transient.Year,
                district_number = transient.DistrictNumber,
                file_path = transient.FilePath,
                featured_item_flag = transient.IsFeaturedItem ? 1 : 0,
                status_flag = transient.IsValidStatus ? 1 : 0,
                row_updated_by_user_id = transient.User,
                row_created_by_user_id = transient.User,
                row_created = DateTime.Now,
                row_updated = DateTime.Now
            };            

            if (transient.File != null)
            {
                file_repository fileRepository = new file_repository()
                {
                    file_blob = transient.File.ByteArray,
                    file_name = transient.File.FileName,
                    row_created = DateTime.Now,
                    row_created_by_user_id = transient.User,
                    row_updated = DateTime.Now,
                    row_updated_by_user_id = transient.User,
                    status_flag = 1
                };

                archiveRepos.file_repository = fileRepository;
            }

            return archiveRepos;

        }

        #endregion
    }
}
