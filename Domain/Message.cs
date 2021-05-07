using System;
using System.Collections.Generic;
using System.Linq;
using Repository;
using db = SMSDB;
using System.Linq.Expressions;
using System.Data.Entity.Core.Metadata.Edm;

namespace Domain
{
    public class Message
    {
        private Repository<db.tm_mes_message> _repository = new Repository<db.tm_mes_message>(new db.SMSdb());

        public int Add(Entities.Message objApp)
        {
            var objDB = MapToObjDB(objApp);
            _repository.Add(objDB);
            _repository.Save();
            return objDB.mes_codmessage;
        }

        public Entities.Message getSpecificRecord(int id)
        {
            var _queryDb = _repository.GetOneById(id);
            var _records = MapToObjApp(_queryDb);
            return _records;
        }

        public IEnumerable<Entities.Message> getAllRecordsByQuery(Expression<Func<db.tm_mes_message, bool>> predicate)
        {
            var _queryDb = _repository.Find(predicate).ToList();
            var _records = MapToObjApp(_queryDb);
            return _records;
        }

        private db.tm_mes_message MapToObjDB(Entities.Message objApp)
        {
            var objDB = new db.tm_mes_message();

            objDB.mes_codmessage = objApp.Mes_codmessage;
            objDB.mes_created = objApp.Mes_created;
            objDB.mes_to = objApp.Mes_to;
            objDB.mes_message = objApp.Mes_message;
            objDB.mes_status = objApp.Mes_status;
            objDB.mes_insertuser = objApp.Mes_insertuser;
            objDB.mes_insertdate = objApp.Mes_insertdate;
            objDB.mes_insertterminal = objApp.Mes_insertterminal;
            objDB.mes_updateuser = objApp.Mes_updateuser;
            objDB.mes_updatedate = objApp.Mes_updatedate;
            objDB.mes_updateterminal = objApp.Mes_updateterminal;

            return objDB;

        }
        private Entities.Message MapToObjApp(db.tm_mes_message objDB)
        {
            var objApp = new Entities.Message();

            objApp.Mes_codmessage = objDB.mes_codmessage;
            objApp.Mes_created = objDB.mes_created;
            objApp.Mes_to = objDB.mes_to;
            objApp.Mes_message = objDB.mes_message;
            objApp.Mes_status = objDB.mes_status;
            objApp.Mes_insertuser = objDB.mes_insertuser;
            objApp.Mes_insertdate = objDB.mes_insertdate;
            objApp.Mes_insertterminal = objDB.mes_insertterminal;
            objApp.Mes_updateuser = objDB.mes_updateuser;
            objApp.Mes_updatedate = objDB.mes_updatedate;
            objApp.Mes_updateterminal = objDB.mes_updateterminal;

            return objApp;

        }
        private IEnumerable<Entities.Message> MapToObjApp(IEnumerable<db.tm_mes_message> objsDB)
        {
            var objsApp = new List<Entities.Message>();

            foreach(var objDB in objsDB)
            {
                var objApp = new Entities.Message();

                objApp.Mes_codmessage = objDB.mes_codmessage;
                objApp.Mes_created = objDB.mes_created;
                objApp.Mes_to = objDB.mes_to;
                objApp.Mes_message = objDB.mes_message;
                objApp.Mes_status = objDB.mes_status;
                objApp.Mes_insertuser = objDB.mes_insertuser;
                objApp.Mes_insertdate = objDB.mes_insertdate;
                objApp.Mes_insertterminal = objDB.mes_insertterminal;
                objApp.Mes_updateuser = objDB.mes_updateuser;
                objApp.Mes_updatedate = objDB.mes_updatedate;
                objApp.Mes_updateterminal = objDB.mes_updateterminal;

                objsApp.Add(objApp);
            }

            return objsApp;

        }
    }
}
