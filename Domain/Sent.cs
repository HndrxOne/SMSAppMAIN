using System;
using System.Collections.Generic;
using System.Linq;
using Repository;
using db = SMSDB;
using System.Linq.Expressions;

namespace Domain
{
    public class Sent
    {
        private Repository<db.tm_sen_sent> _repository = new Repository<db.tm_sen_sent>(new db.SMSdb());

        public int Add(Entities.Sent objApp)
        {
            var objDB = MapToObjDB(objApp);
            _repository.Add(objDB);
            _repository.Save();
            return objDB.sen_codsent;
        }

        public Entities.Sent getSpecificRecord(int id)
        {
            var _queryDb = _repository.GetOneById(id);
            var _records = MapToObjApp(_queryDb);
            return _records;
        }

        public IEnumerable<Entities.Sent> getAllRecordsByQuery(Expression<Func<db.tm_sen_sent, bool>> predicate)
        {
            var _queryDb = _repository.Find(predicate).ToList();
            var _records = MapToObjApp(_queryDb);
            return _records;
        }

        private db.tm_sen_sent MapToObjDB(Entities.Sent objApp)
        {
            var objDB = new db.tm_sen_sent();

            objDB.sen_codsent = objApp.Sen_codsent;
            objDB.sen_codmessage = objApp.Sen_codmessage;
            objDB.sen_sent = objApp.Sen_sent;
            objDB.sen_twiliocode = objApp.Sen_twiliocode;
            objDB.sen_status = objApp.Sen_status;
            objDB.sen_insertuser = objApp.Sen_insertuser;
            objDB.sen_insertdate = objApp.Sen_insertdate;
            objDB.sen_insertterminal = objApp.Sen_insertterminal;
            objDB.sen_updateuser = objApp.Sen_updateuser;
            objDB.sen_updatedate = objApp.Sen_updatedate;
            objDB.sen_updateterminal = objApp.Sen_updateterminal;

            return objDB;

        }
        private Entities.Sent MapToObjApp(db.tm_sen_sent objDB)
        {
            var objApp = new Entities.Sent();

            objApp.Sen_codsent = objDB.sen_codsent;
            objApp.Sen_codmessage = objDB.sen_codmessage;
            objApp.Sen_sent = objDB.sen_sent;
            objApp.Sen_twiliocode = objDB.sen_twiliocode;
            objApp.Sen_status = objDB.sen_status;
            objApp.Sen_insertuser = objDB.sen_insertuser;
            objApp.Sen_insertdate = objDB.sen_insertdate;
            objApp.Sen_insertterminal = objDB.sen_insertterminal;
            objApp.Sen_updateuser = objDB.sen_updateuser;
            objApp.Sen_updatedate = objDB.sen_updatedate;
            objApp.Sen_updateterminal = objDB.sen_updateterminal;

            return objApp;

        }
        private IEnumerable<Entities.Sent> MapToObjApp(IEnumerable<db.tm_sen_sent> objsDB)
        {
            var objsApp = new List<Entities.Sent>();

            foreach (var objDB in objsDB)
            {
                var objApp = new Entities.Sent();

                objApp.Sen_codsent = objDB.sen_codsent;
                objApp.Sen_codmessage = objDB.sen_codmessage;
                objApp.Sen_sent = objDB.sen_sent;
                objApp.Sen_twiliocode = objDB.sen_twiliocode;
                objApp.Sen_status = objDB.sen_status;
                objApp.Sen_insertuser = objDB.sen_insertuser;
                objApp.Sen_insertdate = objDB.sen_insertdate;
                objApp.Sen_insertterminal = objDB.sen_insertterminal;
                objApp.Sen_updateuser = objDB.sen_updateuser;
                objApp.Sen_updatedate = objDB.sen_updatedate;
                objApp.Sen_updateterminal = objDB.sen_updateterminal;

                objsApp.Add(objApp);
            }

            return objsApp;

        }
    }
}
