using System;
using System.Collections.Generic;
using System.Linq;
using Repository;
using db = SMSDB;
using System.Linq.Expressions;

namespace Domain
{
    public class Credential
    {
        private Repository<db.tm_cre_credential> _repository = new Repository<db.tm_cre_credential>(new db.SMSdb());

        public Entities.Credential getSpecificRecord(int id)
        {
            var _queryDb = _repository.GetOneById(id);
            var _records = MapToObjApp(_queryDb);
            return _records;
        }

        private Entities.Credential MapToObjApp (db.tm_cre_credential objDB)
        {
            var objApp = new Entities.Credential();

            objApp.Cre_codcredential = objDB.cre_codcredential;
            objApp.Cre_projectid = objDB.cre_projectid;
            objApp.Cre_token = objDB.cre_token;
            objApp.Cre_domain = objDB.cre_domain;
            objApp.Cre_phone = objDB.cre_phone;
            objApp.Cre_status = objDB.cre_status;
            objApp.Cre_insertuser = objDB.cre_insertuser;
            objApp.Cre_insertdate = objDB.cre_insertdate;
            objApp.Cre_insertterminal = objDB.cre_insertterminal;
            objApp.Cre_updateuser = objDB.cre_updateuser;
            objApp.Cre_updatedate = objDB.cre_updatedate;
            objApp.Cre_updateterminal = objDB.cre_updateterminal;

            return objApp;
        }
    }
}
