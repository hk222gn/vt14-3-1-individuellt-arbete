using BoatRental.Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoatRental.Model
{
    public class Service
    {
        #region Fields
        private KundDAL _kundDAL;
        private BåtplatsDAL _båtplatsDAL;
        private BokningDAL _bokningDAL;
        #endregion

        #region Properties

        //Alla tre initieras bara när det behövs
        private KundDAL KundDAL
        {
            get { return _kundDAL ?? (_kundDAL = new KundDAL()); }
        }

        private BåtplatsDAL BåtplatsDAL
        {
            get { return _båtplatsDAL ?? (_båtplatsDAL = new BåtplatsDAL()); }
        }

        private BokningDAL BokningDAL
        {
            get { return _bokningDAL ?? (_bokningDAL = new BokningDAL()); }
        }
        #endregion

        #region Kund CRUD methods.
        public void DeleteKund(int kundID)
        {
            KundDAL.DeleteKund(kundID);
        }

        public Kund GetKund(int kundID)
        {
            return KundDAL.GetKund(kundID);
        }

        public IEnumerable<Kund> GetKunder()
        {
            return KundDAL.GetKunder();
        }

        public IEnumerable<Kund> GetKundPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return KundDAL.GetKundPageWise(maximumRows, startRowIndex, out totalRowCount);
        }
        public void SaveKund(Kund kund)
        {
            //Kollar så att objektet är godkänt.
            ICollection<ValidationResult> validationResults;

            if (!kund.Validate(out validationResults))
            {
                //Kastar undantag ifall det inte är så.
                var ex = new ValidationException("Objektet gick inte igenom valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;

            }

            //Om KundID = 0, skapa en ny kund, annars updatera en befintlig.
            if (kund.KundID == 0)
            {
                KundDAL.InsertKund(kund);
            }
            else
            {
                KundDAL.UpdateKund(kund);
            }
        }
        #endregion

        #region bokning CRUD methods.
        public void DeleteBokning(int bokningID)
        {
            BokningDAL.DeleteBokning(bokningID);
        }

        public Bokning GetBokning(int bokningID)
        {
            return BokningDAL.GetBokning(bokningID);
        }

        public void SaveBokning(Bokning bokning, int ID)
        {
            //Kollar så att objektet är godkänt.
            ICollection<ValidationResult> validationResults;

            if (!bokning.Validate(out validationResults))
            {
                //Kastar undantag ifall det inte är så.
                var ex = new ValidationException("Objektet gick inte igenom valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;

            }
            //Om BokningID = 0, skapa en ny kund, annars updatera en befintlig.
            if (bokning.BokningID == 0)
            {
                BokningDAL.InsertBokning(bokning, ID);
            }
            else
            {
                BokningDAL.UpdateBokning(bokning);
            }
        }

        public IEnumerable<Bokning> GetBokningPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return BokningDAL.GetBokningPageWise(maximumRows, startRowIndex, out totalRowCount);
        }

        #endregion

        #region båtplats read methods.

        public IEnumerable<Båtplats> GetBåtplatsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return BåtplatsDAL.GetBåtplatsPageWise(maximumRows, startRowIndex, out totalRowCount);
        }

        #endregion
    }
}