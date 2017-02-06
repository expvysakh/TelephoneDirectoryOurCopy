using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TelephoneDirectoryApplication.Models;
using TelephoneDirectoryApplication.Data_Layer;
using System.Data.Entity.Migrations;

namespace TelephoneDirectoryApplication.Controllers
{
    public class HomeController : ApiController
    {
        private readonly ContactRecordContext _dbContext;

        public HomeController()
        {
            _dbContext = new ContactRecordContext();
        }
        // action to add/edit the directory
        [HttpPost]
        [Route("api/AddDirectory")]
        public Response AddDirectory(DirectoryModel newDirectory)
        {
            var direcdtory = _dbContext.Directories.AsEnumerable();
            //if the directory name  is alredy exist in th directory 
            //table it is  considered as a  duplicate directory 
            var duplicateDirectory = _dbContext.Directories
                .Where(u => u.Name == newDirectory.Name)
                .FirstOrDefault();

            // If the DirectoryId of new directory is same as the 
            // Existing directory the the operation is updation 
            var existingDirectory = _dbContext.Directories
                   .Where(d => d.Id == newDirectory.Id)
                   .FirstOrDefault();

            if(duplicateDirectory!= null && newDirectory.Id<1)
            {
                return new Response
                {
                    IsValid = false,
                    ResponseMessage = "Directory already exist..!"
                };
            }
            if(existingDirectory!= null)
            {             
                 existingDirectory.Name = newDirectory.Name;
                _dbContext.Directories.AddOrUpdate(existingDirectory);
                _dbContext.SaveChanges();
                
                return new Response
                {
                    IsValid = true,
                    ResponseMessage = "Directory name updated successfully..!"
                };
            }
            // When the DirectoryName is not in the table 
            // and DirectoryId is null  then we need to add a new directory 
            else
            {
                var addDirectory = new Directory
                {
                    Name = newDirectory.Name
                };
                _dbContext.Directories.Add(addDirectory);
                _dbContext.SaveChanges();
                return new Response
                {
                    IsValid = true,
                    ResponseMessage = "Directory added successfully..!"
                };
           }
            
        }

        //action to add a new directory record or edit the 
        //existing record

        [HttpPost]
        [Route("api/AddRecord")]
        public Response AddRecord(PhoneNumberModel newRecord)
        {
            var duplicateRecord = _dbContext.PhoneNumbers
                .Where(u => u.TelephoneNumber == newRecord.TelephoneNumber &&
                 u.DirectoryId == newRecord.DirectoryId)
                .FirstOrDefault();

            var existingRecord = _dbContext.PhoneNumbers
                    .Where(pn => pn.RecordId == newRecord.RecordId)
                    .FirstOrDefault();
            if(duplicateRecord != null)
            {
                if (existingRecord != null)
                {
                    existingRecord.Address = newRecord.Address;
                    existingRecord.DirectoryId = newRecord.DirectoryId;
                    existingRecord.FirstName = newRecord.FirstName;
                    existingRecord.LastName = newRecord.LastName;
                    existingRecord.TelephoneNumber = newRecord.TelephoneNumber;

                    _dbContext.PhoneNumbers.AddOrUpdate(existingRecord);
                    _dbContext.SaveChanges();
                }
                return new Response
                {
                    IsValid = true,
                    ResponseMessage= "Record updated Successfully...!"
                };

            }

            if (newRecord.RecordId > 0 && newRecord.DirectoryId!= existingRecord.DirectoryId)
            {
                

                if (existingRecord != null)
                {
                    existingRecord.Address = newRecord.Address;
                    existingRecord.DirectoryId = newRecord.DirectoryId;
                    existingRecord.FirstName = newRecord.FirstName;
                    existingRecord.LastName = newRecord.LastName;
                    existingRecord.TelephoneNumber = newRecord.TelephoneNumber;
                    _dbContext.PhoneNumbers.AddOrUpdate(existingRecord);
                }

            }
            else
            {
                var record = new PhoneNumber
                {
                    Address = newRecord.Address,
                    DirectoryId = newRecord.DirectoryId,
                    FirstName = newRecord.FirstName,
                    LastName = newRecord.LastName,
                    TelephoneNumber = newRecord.TelephoneNumber
                };

                _dbContext.PhoneNumbers.Add(record);
            }

            _dbContext.SaveChanges();
            return new Response
            {
                IsValid = true
            };
        }
        //Control method to search for a record by user name or by mobilke number
        [HttpPost]
        [Route("api/SearchRecord")]
        public IEnumerable<PhoneNumberModel> SearchRecord(FilterCriteria filterCriteria)
        {
            if (filterCriteria.SearchBy == 0)
            {
                var filteredRecords = _dbContext.PhoneNumbers
                .Where(pn => pn.TelephoneNumber == filterCriteria.SearchString);
                var RecordList= from c in filteredRecords
                                select new PhoneNumberModel
                                {
                                    FirstName= c.FirstName,
                                    LastName= c.LastName,
                                    TelephoneNumber= c.TelephoneNumber,
                                    Address= c.Address,
                                    DirectoryName = c.DirectoryList.Name
                                };
                return RecordList;
            }

            if (filterCriteria.SearchBy == 1)
            {
                var filteredRecords = _dbContext.PhoneNumbers
                .Where(pn => pn.FirstName == filterCriteria.SearchString);
                var RecordList = from c in filteredRecords
                                 select new PhoneNumberModel
                                 {
                                     FirstName = c.FirstName,
                                     LastName = c.LastName,
                                     TelephoneNumber = c.TelephoneNumber,
                                     Address = c.Address,
                                     DirectoryName = c.DirectoryList.Name
                                 };
                return RecordList;
            }
            return null;
        }

        [HttpGet]
        [Route("api/ListRecord")]
        public IEnumerable<PhoneNumberModel> ListRecord()
        {
            var contacts = _dbContext.PhoneNumbers.AsEnumerable();
            IEnumerable<PhoneNumberModel> contactList = null;

             contactList = from c in contacts
                   select new PhoneNumberModel
                   {
                       FirstName= c.FirstName,
                       LastName= c.LastName,
                       TelephoneNumber= c.TelephoneNumber,
                       Address= c.Address,
                       DirectoryName= c.DirectoryList.Name,
                       RecordId= c.RecordId
                   };
            return contactList;

        }

        [HttpGet]
        [Route("api/ListDirectory")]
        public IEnumerable<DirectoryModel> ListDirectory()
        {
            var directories = _dbContext.Directories.AsEnumerable();
            IEnumerable<DirectoryModel> directorytList = null;

            directorytList = from c in directories
                             select new DirectoryModel
                             {
                                Name= c.Name,
                                Id= c.Id
                             };
            return directorytList;

        }

        [HttpPost]
        [Route("api/GetDirectoryById")]
        public DirectoryModel GetDirectoryById(DirectoryModel directory)
        {      
            var DirectoryToEdit = _dbContext.Directories.AsEnumerable()
                    .Where(d => d.Id == directory.Id)
                    .FirstOrDefault();
            return new DirectoryModel
            {
                Id = DirectoryToEdit.Id,
                Name= DirectoryToEdit.Name
            };
           
        }

        [HttpPost]
        [Route("api/GetRecordById")]
        public PhoneNumberModel GetRecordById(PhoneNumberModel contact)
        {
            var recordctToEdit = _dbContext.PhoneNumbers.AsEnumerable()
                    .Where(d => d.RecordId == contact.RecordId)
                    .FirstOrDefault();
            return new PhoneNumberModel
            {
                RecordId = recordctToEdit.RecordId,
                FirstName = recordctToEdit.FirstName,
                LastName= recordctToEdit.LastName,
                TelephoneNumber= recordctToEdit.TelephoneNumber,
                Address= recordctToEdit.Address,
                DirectoryName= recordctToEdit.DirectoryList.Name

            };

        }
    }
}
