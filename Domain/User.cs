using System;
using System.Collections.Generic;
using System.Linq;
using Repository;
using db = SMSDB;
using System.Linq.Expressions;
using System.Data.Entity.Core.Metadata.Edm;

namespace Domain
{
    public class User
    {
        private Repository<db.tm_usr_user> _repository = new Repository<db.tm_usr_user>(new db.SMSdb());

        public IEnumerable<Entities.User> getAllRecordsByQuery(Expression<Func<db.tm_usr_user, bool>> predicate)
        {
            var _queryDb = _repository.Find(predicate).ToList();
            var _records = MapToObjApp(_queryDb);
            return _records;
        }

        private Entities.User MapToObjApp(db.tm_usr_user objDB)
        {
            var objApp = new Entities.User();

            objApp.Usr_username = objDB.usr_username;
            objApp.Usr_pws = objDB.usr_pws;

            return objApp;

        }
        private IEnumerable<Entities.User> MapToObjApp(IEnumerable<db.tm_usr_user> objsDB)
        {
            var objsApp = new List<Entities.User>();

            foreach(var objDB in objsDB)
            {
                var objApp = new Entities.User();

                objApp.Usr_username = objDB.usr_username;
                objApp.Usr_pws = objDB.usr_pws;

                objsApp.Add(objApp);
            }

            return objsApp;

        }
    }
}
